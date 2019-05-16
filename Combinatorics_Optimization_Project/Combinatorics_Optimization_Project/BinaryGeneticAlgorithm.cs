using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics_Optimization_Project
{
    class BinaryGeneticAlgorithm : GASolver
    {
        ///////////////////////////////////////////////////////////////////////////////////
        //Binary部分所會使用到的屬性
        ///////////////////////////////////////////////////////////////////////////////////
        public enum BinaryCrossoverMode { OnePointCut, TwoPointCut };
        BinaryCrossoverMode BinaryCrossTypeValue = BinaryCrossoverMode.TwoPointCut;
        //目前二元GA僅支援單點及雙點交配，預設為單點交配

        [Category("GA Operation Modes"), Description("交配運算模式，提供單點與雙點交配。")]
        public BinaryCrossoverMode BinaryCrossoverType
        {
            get { return BinaryCrossTypeValue; }
            set { BinaryCrossTypeValue = value; }
        }

        public BinaryGeneticAlgorithm(int num, ObjectiveFunctionDelegate objFunction, double[] mins, double[] maxs)
        {
            NumberOfVariables = num;
            COPGetObjectiveValue = objFunction;
            lowerBounds = mins;
            upperBounds = maxs;
        }

        ///////////////////////////////////////////////////////////////////////////////////
        //Binary部分所會使用到的屬性
        ///////////////////////////////////////////////////////////////////////////////////

        Random RandomGenerator = new Random();

        int[][] crossoverChromosomes;

        //丟進來一條染色體，計算出其目標式函數值(染色體代表的是自LowerBound往上增加的增量)
        protected override double GetObjectiveValue(int[] chromosome)
        {
            //先將染色體拆解成許多區塊，每個區塊代表一個變數的值
            String[][] VariableValue = new String[NumberOfVariables][];
            //記錄目前從此條染色體的第幾個位置往後數
            int PosCount = 0;
            //記錄十進位的各個變數值
            double[] DecimalSolution = new double[NumberOfVariables];
            

            for (int i = 0; i < 2; i++)
            {
                string tempString = "";
                VariableValue[i] = new string[VariableLength[i]];
                //Console.Out.WriteLine(VariableLength[i]);
                int PosCounter = PosCount;
                for (int j = 0; j < VariableLength[i]; j++)
                {
                    VariableValue[i][j] = Convert.ToString(chromosome[PosCounter]);
                    tempString += VariableValue[i][j];
                    PosCounter++;
                }
                DecimalSolution[i]= Convert.ToInt32(tempString, 2)+lowerBounds[i];
                //將二進位的字串解碼成十進位之整數

                //若超出邊界則以邊界為變數值
                if (DecimalSolution[i] >= upperBounds[i])
                {
                    DecimalSolution[i] = upperBounds[i];
                }
                PosCount += VariableLength[i];
            }
            return COPGetObjectiveValue(DecimalSolution);
            //以外部提供之函數進行目標值運算並回傳之
        }

        //初始化物件，設定好所有需要用到的染色體及相關參數(當代最佳、全域最佳等)
        public override void Initialize()
        {
            VariableLength = new int[NumberOfVariables];
            for (int i = 0; i < NumberOfVariables; i++)
            {
                int tempGap = Convert.ToInt32((upperBounds[i] - lowerBounds[i]) * Math.Pow(10, Percision));
                String tempBinGap = Convert.ToString(tempGap, 2);
                //將上下界的間隔乘上精密度後取整數，再轉成二進位看此變數佔用的格數為多少
                //其涵義為將上下界之間隔換算成二進位碼，以染色體表示自LowerBound往上的增量，若為最大值則代表達到UpperBound
                VariableLength[i] = tempBinGap.Length;
                //每個變數佔用的基因數皆不同，以VariableLength[i]表示
                totalLength += VariableLength[i];
                //染色體總長度計算，初始化染色體時要用到
            }

            CurrentIteration = 0;
            SoFarTheBestObjective = double.MaxValue;
            //全域最佳解的目標函式值
            BinChromosome = new int[PopulationSize * 4][];
            //分配記憶體空間，染色體總共分成三大塊，包括目前的母體、交配出來的子代(數量不可超過母體)和待突變的子代，還有一個其他備用空間

            Fitness = new double[PopulationSize * 4];

            for (int i = 0; i < BinChromosome.GetLength(0); i++)
            {
                BinChromosome[i] = new int[totalLength];
                //每條染色體長度為上下界之間隔轉換為二進位碼
            }

            crossoverChromosomes = new int[PopulationSize][];
            for (int i = 0; i < PopulationSize; i++)
            {
                crossoverChromosomes[i] = new int[totalLength];
            }
            //初始化交配用之染色體

            InitializePopulation();
        }

        //初始化母體運算
        public override void InitializePopulation()
        {
            Objective = new double[PopulationSize * 4];
            tempObjs = new double[PopulationSize * 4];
            tempIDs = new int[PopulationSize * 4];
            //初始化交配相關要用之資料結構

            BinGenerationBestSolution = new int[totalLength];
            SoFarTheBestSolutionBinary = new int[totalLength];
            //初始化當代最佳解以及全域最佳解

            // 產生起始解
            for (int r = 0; r < PopulationSize; r++)
            {
                //Console.Write("目前是第"+r+"條染色體\n");
                for (int c = 0; c < totalLength; c++)
                {
                    //Console.Write("目前是第"+c+ "個基因:\n ");
                    BinChromosome[r][c] = RandomGenerator.Next() % 2 == 0 ? (int)1 : (int)0;
                    //Console.Write(BinChromosome[r][c]);
                    //產生隨機數，若能整除則為1，否則為零
                }
                Objective[r] =  GetObjectiveValue(BinChromosome[r]);
                tempObjs[r] = Objective[r];
                SetFitness(r, Objective[r]);
                //計算各染色體的目標值函數和適應值
            }

            // 在起始解中尋找表現最好的，並根據其值排列序號
            for (int i = 0; i < tempIDs.Length; i++) tempIDs[i] = i;
            //tempID指的是原始的流水號
            Array.Sort(tempObjs, tempIDs, 0, PopulationSize); // 0 sort 到 population size
            //內建排序功能，根據 1.物件 2.各物件內容對應到的Index 4.陣列大小 作排序
            IterationBestObjective = Objective[tempIDs[0]]; // so-far-the best value
            for (int c = 0; c < totalLength; c++)
            {
                BinGenerationBestSolution[c] = BinChromosome[tempIDs[0]][c]; // so-far-the best solution
                SoFarTheBestSolutionBinary[c] = BinGenerationBestSolution[c];
            }
            SoFarTheBestObjective = IterationBestObjective;
            //第一次初始化染色體，排序後位於最上端者即為最好者

        }

        //交配運算
        public override void CrossOver()
        {
            // determind crossover size
            if (Convert.ToInt32(PopulationSize * CrossoverRate) % 2 == 0) CrossoverPoolSize = Convert.ToInt32(PopulationSize * CrossoverRate);
            else CrossoverPoolSize = CrossoverPoolSize = Convert.ToInt32(PopulationSize * CrossoverRate) - 1;
            //計算到底要交配出多少子代，若母體乘上交配率為偶數則沒問題，若為奇數則-1(因為子代只會成對出現)

            // crossover
            switch (BinaryCrossTypeValue)
            {
                case BinaryCrossoverMode.OnePointCut:
                    //若要進行單點交配

                    int crossoverPoint = RandomGenerator.Next(totalLength - 1);
                    //隨機產生一個交配點
                    for (int i = 0; i < CrossoverPoolSize; i = i + 2)
                    {
                        //每次成對挑選母代進行交配
                        for (int j = 0; j < crossoverPoint; j++)
                        {
                            //到第一個交配切點前的處理，將母代-1提取出來
                            crossoverChromosomes[i][j] = BinChromosome[i][j];
                            crossoverChromosomes[i + 1][j] = BinChromosome[i + 1][j];
                        }
                        for (int k = crossoverPoint; k < BinChromosome[i].Length; k++)
                        {
                            //到第一個交配切點前的處理，將母代-2提取出來
                            crossoverChromosomes[i][k] = BinChromosome[i + 1][k];
                            crossoverChromosomes[i + 1][k] = BinChromosome[i][k];
                        }
                    }
                    break;

                case BinaryCrossoverMode.TwoPointCut:
                    //若要進行雙點交配

                    int[] rndPoints = new int[2];
                    //雙點交配，用來儲存兩個隨機切點

                    rndPoints[0] = RandomGenerator.Next(totalLength - 1);
                    rndPoints[1] = RandomGenerator.Next(totalLength - 1);

                    int crossoverPoint1 = Math.Min(rndPoints[0], rndPoints[1]);
                    int crossoverPoint2 = Math.Max(rndPoints[0], rndPoints[1]);
                    //分別將切點儲存至crossoverPoint1&crossoverPoint2

                    for (int i = 0; i < CrossoverPoolSize; i = i + 2)
                    {//產生子代，每次成對產生
                        for (int j = 0; j < crossoverPoint1; j++)
                        {
                            crossoverChromosomes[i][j] = BinChromosome[i][j];
                            crossoverChromosomes[i + 1][j] = BinChromosome[i + 1][j];
                        }
                        for (int k = crossoverPoint1; k <= crossoverPoint2; k++)
                        {
                            crossoverChromosomes[i][k] = BinChromosome[i + 1][k];
                            crossoverChromosomes[i + 1][k] = BinChromosome[i][k];
                        }
                        for (int l = crossoverPoint2 + 1; l < BinChromosome[i].Length; l++)
                        {
                            crossoverChromosomes[i][l] = BinChromosome[i][l];
                            crossoverChromosomes[i + 1][l] = BinChromosome[i + 1][l];
                        }
                        //子代產生方法：根據母代做交替交換，左邊:母代1換子代1、中間:母代1換子代2、右邊:母代1換子代1
                    }
                    break;
            }

            for (int i = PopulationSize; i < PopulationSize + CrossoverPoolSize; i++)
            {
                BinChromosome[i] = crossoverChromosomes[i - PopulationSize];
            }
            //將第二塊部分以BinChromosome空間儲存

            for (int i = 0; i < PopulationSize + CrossoverPoolSize; i++)
            {
                Objective[i] = GetObjectiveValue(BinChromosome[i]);
                tempObjs[i] = Objective[i];
            }
            //tempObjs是排序用的物件儲存空間

        }

        //突變運算
        public override void Mutate()
        {
            int mutationGeneSize = Convert.ToInt32(MutationRate * PopulationSize * totalLength);
            int[] mutationIndex = new int[mutationGeneSize];
            int[] mutationGeneID = new int[PopulationSize * totalLength];
            for (int i = 0; i < mutationGeneID.Length; i++) mutationGeneID[i] = i;

            // random choosing index of mutationGenes
            for (int i = 0; i < mutationGeneSize; i++)
            {
                int rndGene = RandomGenerator.Next(mutationGeneID.Max());
                int t = mutationGeneID[i];
                mutationGeneID[i] = mutationGeneID[rndGene];
                mutationGeneID[rndGene] = t;
            }
            for (int i = 0; i < mutationGeneSize; i++) mutationIndex[i] = mutationGeneID[i];
            Array.Sort(mutationIndex);

            // mutation
            int j = -1, lastr = -1;
            for (int i = 0; i < mutationGeneSize; i++)
            {
                int r = 0, c = mutationIndex[i];
                while (c >= totalLength)
                {
                    c = c - totalLength;
                    r++;
                }

                if (r == lastr)
                {
                    if (BinChromosome[PopulationSize + CrossoverPoolSize + j][c] == 0)
                    {
                        BinChromosome[PopulationSize + CrossoverPoolSize + j][c] = 1;
                    }
                    else if (BinChromosome[PopulationSize + CrossoverPoolSize + j][c] == 1)
                    {
                        BinChromosome[PopulationSize + CrossoverPoolSize + j][c] = 0;
                    }
                }
                else if (r >= lastr)
                {
                    j++;
                    // mutationChromosomes[j] = chromosomes[r] (不可用) <-- 會更改記憶體指標
                    for (int x = 0; x < BinChromosome[r].Length; x++)
                    {
                        BinChromosome[PopulationSize + CrossoverPoolSize + j][x] = BinChromosome[r][x]; // copy
                    }

                    if (BinChromosome[r][c] == 0)
                    {
                        BinChromosome[PopulationSize + CrossoverPoolSize + j][c] = 1;
                    }
                    else if (BinChromosome[r][c] == 1)
                    {
                        BinChromosome[PopulationSize + CrossoverPoolSize + j][c] = 0;
                    }
                }
                lastr = r;
            }

            MutationPoolSize = j + 1; // for mainform
            // 
            for (int r = 0; r < PopulationSize + CrossoverPoolSize + MutationPoolSize; r++)
            {
                Objective[r] = GetObjectiveValue(BinChromosome[r]);
                tempObjs[r] = Objective[r];
            }

            this.UpdateSolutionAndObjective();
        }

        //適應值計算
        public override void SetFitness(int FitnessIndex, double Objective)
        {
            Fitness[FitnessIndex] = Math.Pow(Objective, -1);
            //適應值為目標式函式之倒數
        }

        //淘汰運算
        public override void Eliminate()
        {

            int[][] tempChromosomes = new int[PopulationSize][];
            for (int i = 0; i < tempChromosomes.GetLength(0); i++)
            {
                tempChromosomes[i] = new int[totalLength];
            }

            switch (SelectType)
            {
                case SelectionMode.Deterministic:
                    //若為確定型Selection：

                    int[] rndID = new int[PopulationSize];
                    for (int i = 0; i < PopulationSize; i++) rndID[i] = tempIDs[i];

                    for (int i = 0; i < PopulationSize; i++)
                    {
                        int rndids = RandomGenerator.Next(PopulationSize - 1);
                        int temp = rndID[i];
                        rndID[i] = rndID[rndids];
                        rndID[rndids] = temp;
                    }
                    //將現有的Indices陣列內順序打亂 - 藉由產生一個亂序的rndids來對rndID陣列亂序化

                    for (int i = 0; i < PopulationSize; i++)
                    {
                        for (int j = 0; j < totalLength; j++)
                        {
                            tempChromosomes[i][j] = BinChromosome[rndID[i]][j];
                        }
                    }
                    //將目前的Indice順序編碼與染色體同步，即第1個Indice值會對應到第1條染色體，依此類推...

                    for (int i = 0; i < PopulationSize; i++)
                    {
                        for (int j = 0; j < totalLength; j++)
                        {
                            BinChromosome[i][j] = tempChromosomes[i][j];
                        }
                    }
                    //將此同步化後的Chromosome存回至BinChromosome

                    for (int r = 0; r < PopulationSize; r++)
                    {
                        Objective[r] = GetObjectiveValue(BinChromosome[r]);
                        SetFitness(r, Objective[r]);
                    }
                    //根據篩選過後的Chromosome去計算Objective和Fitness

                    for (int n = PopulationSize; n < BinChromosome.GetLength(0); n++)
                    {
                        BinChromosome[n] = new int[totalLength];
                    }
                    break;

                case SelectionMode.Stochastic:
                    //若為隨機型Selection：

                    double totalf = 0.0;
                    double[] Fitness = new double[PopulationSize + CrossoverPoolSize + MutationPoolSize];
                    //Fitness陣列
                    Probabilities = new double[PopulationSize + CrossoverPoolSize + MutationPoolSize];
                    //產生一個累積機率陣列

                    for (int i = 0; i < Fitness.Length; i++)
                    {
                        Fitness[i] = Math.Pow(Objective[i], -1);
                        //適應值算法為目標函式的倒數，函數值越大則適應值相較越小
                        totalf += Fitness[i];
                    }
                    for (int i = 0; i < Fitness.Length; i++) Probabilities[i] = Fitness[i] / totalf;
                    //算第i條的染色體佔多少比例機率被選到

                    //進行機率加總
                    double sum = 0.0;
                    for (int i = 0; i < Probabilities.Length; i++) sum += Probabilities[i];

                    //計算累積到各條染色體時的累積機率
                    double[] cumulative = new double[Probabilities.Length];
                    cumulative[0] = Probabilities[0];
                    for (int i = 1; i < Probabilities.Length; i++)
                    {
                        cumulative[i] = cumulative[i - 1] + Probabilities[i];
                    }

                    //進行飛鏢投擲
                    int[] hitOne = new int[PopulationSize];
                    //查看到底哪些染色體被跳過，直到找到被選到的那一個
                    for (int k = 0; k < PopulationSize; k++)
                    {
                        bool determind = false;
                        double dart = RandomGenerator.NextDouble() * sum;
                        for (int i = 0; i < cumulative.Length; i++)
                        {
                            if (cumulative[i] >= dart)
                            {
                                //被記錄為Ture的代表都被計算過，但沒有被選到
                                hitOne[k] = i;
                                determind = true;
                                break;
                            }
                        }
                        if (determind == false) hitOne[k] = cumulative.Length - 1;
                        //找到第一個為false代表被飛鏢投擲射中
                    }

                    for (int i = 0; i < PopulationSize; i++)
                    {
                        for (int j = 0; j < totalLength; j++)
                        {
                            tempChromosomes[i][j] = BinChromosome[hitOne[i]][j];
                        }
                    }
                    //先備份一份暫時用的染色體，以被選到的那條為基礎去備份

                    for (int i = 0; i < PopulationSize; i++)
                    {
                        for (int j = 0; j < totalLength; j++)
                        {
                            BinChromosome[i][j] = tempChromosomes[i][j];
                        }
                    }
                    //將被選到的染色體存回原本母體染色體中

                    for (int r = 0; r < PopulationSize; r++)
                    {
                        Objective[r] = GetObjectiveValue(BinChromosome[r]);
                    }
                    //重新計算Objective

                    break;
            }
        }

        //進行一代的運算
        public override void RunOneIteration()
        {
            CrossOver();
            Mutate();
            Eliminate();
            CurrentIteration++;
        }

        //進行全域求解
        public override void RunToEnd()
        {
            while (CurrentIteration < MaxIteration)
            {
                CrossOver();
                Mutate();
                Eliminate();
                CurrentIteration++;
            }
        }

        //更新目前的全域最佳解、當代最佳解和當代解平均
        public override void UpdateSolutionAndObjective()
        {
            String[][] VariableValue = new String[NumberOfVariables][];
            for (int i = 0; i < tempIDs.Length; i++) tempIDs[i] = i;
            Array.Sort(tempObjs, tempIDs, 0, PopulationSize + CrossoverPoolSize);
            //根據目標值的大小對TempID做排序

            //先將染色體拆解成許多區塊，每個區塊代表一個變數的值
            ChromosomeSolution = new double[PopulationSize][];
            //記錄目前從此條染色體的第幾個位置往後數
                    
            //記錄十進位的各個變數值
            double[] DecimalSolution ;
            
            //將各個染色體所代表的變數轉換成十進位變數，組織成能夠被繪圖物件圖示化的資料結構
            for (int i = 0; i < PopulationSize; i++)
            {
                int PosCount = 0;    
                DecimalSolution = new double[NumberOfVariables];
                //十進位的各變數解
                for (int j = 0; j < NumberOfVariables; j++)
                {
                    string tempString = "";
                    //由於C#有提供內建文字二進位轉十進位，故先將二進位碼轉換成文字
                    VariableValue[j] = new string[VariableLength[j]];
                    int PosCounter = PosCount;
                    for(int k =0;k<VariableLength[j]; k++)
                    {
                        VariableValue[j][k] = Convert.ToString(BinChromosome[tempIDs[i]][PosCounter]);
                        //將染色體的二進位碼依照變數佔用基因數以迴圈隔開，並抽出來存成String
                        tempString += VariableValue[j][k];
                        PosCounter++;
                    }
                    DecimalSolution[j] = Convert.ToInt32(tempString, 2) + lowerBounds[j];
                    //將其值解碼，染色體代表的是自LowerBound往上增加的增量，故要再加回LowerBound
                    PosCount += VariableLength[j];
                }
                ChromosomeSolution[i] = DecimalSolution;
            }

            IterationBestObjective = Objective[tempIDs[0]];
            //當代最好的就是最小的
            for (int c = 0; c < totalLength; c++)
            {
                BinGenerationBestSolution[c] = BinChromosome[tempIDs[0]][c];
            }
            //將當代最好的染色體存起來，其編號為tempIDs[0]的值

            //若當代最佳比過去最佳還要好則進行取代
            if (IterationBestObjective < SoFarTheBestObjective)
            {
                NonImproveCounter = 0;
                //將未改善計數器歸零
                SoFarTheBestObjective = IterationBestObjective;
                for (int c = 0; c < totalLength; c++)
                {
                    SoFarTheBestSolutionBinary[c] = BinGenerationBestSolution[c]; // so-far-the best solution
                }
            }
            else
            {
                NonImproveCounter++;
            }
            //計算當代平均值
            double sum = 0.0;
            for (int i = 0; i < PopulationSize + CrossoverPoolSize + MutationPoolSize; i++)
            {
                sum += Objective[i];
            }
            IterationAverage = sum / (PopulationSize + CrossoverPoolSize + MutationPoolSize);
        }

    }
}
