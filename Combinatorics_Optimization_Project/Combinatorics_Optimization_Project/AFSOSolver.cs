using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Combinatorics_Optimization_Project
{
    class AFSOSolver
    {
        AFSOObjectiveFunctionDelegate GetObjectiveValue;

        /// <summary>
        /// 記錄變數維度數量
        /// </summary>
        int numberOfVariables;

        /// <summary>
        /// 記錄每個變數的上下界，避免魚跑出可行解區塊
        /// </summary>
        double[] lowerBounds, upperBounds;

        Random RandomGenerator = new Random();

        /// <summary>
        /// 記錄目前的迭代次數
        /// </summary>
        int IterationCountVlue = 0;
        [Browsable(false)]
        public int IterationCount
        {
            get { return IterationCountVlue; }
            set { IterationCountVlue = value; }
        }

        /// <summary>
        /// 演算限制次數
        /// </summary>
        int IterationLimitValue = 500;
        [Category("Execution"), Description("演算限制迭代次數 Iteration Limited Times ")]
        public int IterationLimitTimes
        {
            get { return IterationLimitValue; }
            set { IterationLimitValue = value; }
        }

        /// <summary>
        /// 連續無改善次數，若達此條件則直接收斂
        /// </summary>
        private int iterationWithoutImprove = 100;
        [Category("Execution"), Description("連續未求得改善解之演化代次上限 Non-Improved Iteration Limit")]
        public int IterationWithoutImprove
        {
            get { return iterationWithoutImprove; }
            set { if (value >= 0) iterationWithoutImprove = value; }
        }

        //現行解連續未改善次數的計數器
        public int NonImproveCounter = 0;

        /// <summary>
        /// 此魚群的規模數量大小
        /// </summary>
        int NumberOfFishsValue = 20;
        [Category("AFSO Setting"), Description("現存魚群之魚隻數 Number of Fishs ")]
        public int NumberOfFishs
        {
            get { return NumberOfFishsValue; }
            set { NumberOfFishsValue = value; }
        }

        /// <summary>
        /// 魚隻之視覺範圍
        /// </summary>
        double SightValue = 10;
        [Category("AFSO Setting"), Description("魚隻之視覺範圍 InitialSight of Each Fish ")]
        public double InitialSight
        {
            get { return SightValue; }
            set { SightValue = value; }
        }

        //目前的Sight值
        public double Sight = 0;
        //視線範圍限制之最小值
        public double MinSight = 0.5;

        /// <summary>
        /// 魚隻之步伐大小，會直接影響到整體收斂速度，若步伐很大則探索能力強，但不易收斂
        /// </summary>
        double StepValue = 3.0;
        [Category("AFSO Setting"), Description("魚隻之步伐大小 Size of One InitialStep ")]
        public double InitialStep
        {
            get { return StepValue; }
            set { StepValue = value; }
        }

        //目前的Step值
        public double Step = 0;
        //步伐限制之最小值
        public double MinStep = 0.5;

        /// <summary>
        /// 魚隻簇擁與追隨時可接受之壅塞程度
        /// </summary>
        double CongestionValue = 0.2;
        [Category("AFSO Setting"), Description("魚隻簇擁與追隨時可接受之壅塞程度 Congestion Degree ")]
        public double CongestionDegree
        {
            get { return CongestionValue; }
            set { CongestionValue = value; }
        }

        /// <summary>
        /// 紀錄魚隻周遭魚群的名單，簇擁時名單為視覺範位內的魚群，追隨時則為視覺範圍內前(夥伴名單)皆進的魚群名單
        /// 前面陣列維度為名單中魚隻數，簇擁時為視覺範位內的魚群數，追隨時則為夥伴名單的數量
        /// 後面陣列維度為變數維度
        /// </summary>
        double[][] FishCrowListValue;
        [Browsable(false)]
        public double[][] FishCrowList
        {
            get
            { return FishCrowListValue; }
            set
            { FishCrowListValue = value; }
        }

        /// <summary>
        /// 紀錄每隻魚接下來要前往的位置，因為時間為離散，且移動位置與其他魚之現行位置有關，故需要分別紀錄
        /// 前面陣列維度魚群大小，後面陣列維度為變數維度
        /// </summary>
        double[][] FishNextSolutionValue;
        [Browsable(false)]
        public double[][] FishNextSolution
        {
            get
            { return FishNextSolutionValue; }
            set
            { FishNextSolutionValue = value; }
        }

        /// <summary>
        /// 紀錄每隻魚接下來要採用的行動，0為簇擁，1為追隨，2為捕食，3為隨機移動
        /// </summary>
        int[] FishNextMoveValue;
        [Browsable(false)]
        public int[] FishNextMove
        {
            get
            { return FishNextMoveValue; }
            set
            { FishNextMoveValue = value; }
        }

        /// <summary>
        /// 魚隻在視線範圍內定義之友好數量，會直接影響到簇擁與追隨的效能，若視覺很遠則容易跳脫區域最佳但不易收斂
        /// </summary>
        int FriendSizeValue = 5;
        [Category("AFSO Setting"), Description("魚隻在視線範圍內定義之友好數量 Friend List Size ")]
        public int FriendSize
        {
            get { return FriendSizeValue; }
            set { FriendSizeValue = value; }
        }

        /// <summary>
        /// 魚隻在捕食時進行嘗試的獵捕次數
        /// </summary>
        int TrialTimesValue = 3;
        [Category("AFSO Setting"), Description("魚隻在捕食時進行嘗試的獵捕次數 Trial Times for Prey ")]
        public int TrialTimes
        {
            get { return TrialTimesValue; }
            set { TrialTimesValue = value; }
        }

        /// <summary>
        /// 若要後段要使用傳統粒子群以利於收斂的話，仍需要下列傳統PSO參數
        /// </summary>

        /// <summary>
        /// 參考魚群中當下帶有最好解之魚位置的權重
        /// </summary>
        double SocialLearningFactorValue = 2;
        [Category("AFSO Setting"), Description("魚隻間彼此速度影響之係數 Social Factor ")]
        public double SocialLearningFactor
        {
            get { return SocialLearningFactorValue; }
            set { SocialLearningFactorValue = value; }
        }

        /// <summary>
        /// 參考魚本身最佳解之位置的權重
        /// </summary>
        double SelfLearningFactorValue = 2;
        [Category("AFSO Setting"), Description("魚隻參考本身最佳位置記憶之係數 Self Factor ")]
        public double SelfLearningFactor
        {
            get { return SelfLearningFactorValue; }
            set { SelfLearningFactorValue = value; }
        }

        /// <summary>
        /// 參考前次速度的權重
        /// </summary>
        double InteriaFactorValue = 1;
        [Category("AFSO Setting"), Description("魚隻本身慣性速度影響之係數 Interia Factor ")]
        public double InteriaFactor
        {
            get { return InteriaFactorValue; }
            set { InteriaFactorValue = value; }
        }

        /// <summary>
        /// 紀錄所有魚隻所帶的解，前面陣列維度為魚隻數，後面陣列維度為變數維度
        /// </summary>
        double[][] FishSolutionValue;
        [Browsable(false)]
        public double[][] FishSolution
        {
            get
            { return FishSolutionValue; }
            set
            { FishSolutionValue = value; }
        }

        int[] indicesOfFish;

        /// <summary>
        /// 目前紀錄魚隻所帶的解的目標函數值
        /// </summary>
        double[] FishObjectiveValue;
        [Browsable(false)]
        public double[] FishObjective
        {
            get
            { return FishObjectiveValue; }
            set
            { FishObjectiveValue = value; }
        }

        /// <summary>
        /// 記錄每隻魚前一次維持的速度(即各個維度與前一次的差異)
        /// </summary>
        double[][] VelocityValue;
        [Browsable(false)]
        public double[][] Velocity
        {
            get
            { return VelocityValue; }
            set
            { VelocityValue = value; }
        }

        /// <summary>
        /// 記錄魚隻自身過去以來曾經到過之最佳位置
        /// </summary>
        double[][] SelftBestPositionValue;
        [Browsable(false)]
        public double[][] SelftBestPosition
        {
            get
            { return SelftBestPositionValue; }
            set
            { SelftBestPositionValue = value; }
        }

        /// <summary>
        /// 記錄魚隻自身過去以來曾經到過之最佳位置之目標函數值
        /// </summary>
        double[] SelfBestObjectiveValue;
        [Browsable(false)]
        public double[] SelfBestObjective
        {
            get
            { return SelfBestObjectiveValue; }
            set
            { SelfBestObjectiveValue = value; }
        }

        /// <summary>
        /// 截至目前為止的最佳解
        /// </summary>
        double[] SoFarTheBestSolutionValue;
        [Browsable(false)]
        public double[] SoFarTheBestSolution
        {
            get { return SoFarTheBestSolutionValue; }
            set { SoFarTheBestSolutionValue = value; }
        }

        /// <summary>
        /// 記錄截至目前為止最佳解的目標函數值
        /// </summary>
        double SoFarTheBestObjectiveValue;
        [Browsable(false)]
        public double SoFarTheBestObjective
        {
            get { return SoFarTheBestObjectiveValue; }
            set { SoFarTheBestObjectiveValue = value; }
        }

        /// <summary>
        /// 紀錄當代最佳解之目標函數值
        /// </summary>
        double IterationBestObjectiveValue = 0;
        [Browsable(false)]
        public double IterationBestObjective
        {
            get { return IterationBestObjectiveValue; }
            set { IterationBestObjectiveValue = value; }
        }

        /// <summary>
        /// 紀錄當代最佳解
        /// </summary>
        double[] IterationBestSolutionValue;
        [Browsable(false)]
        public double[] IterationBestSolution
        {
            get { return IterationBestSolutionValue; }
            set { IterationBestSolutionValue = value; }
        }

        /// <summary>
        /// 紀錄當代目標值函數之平均值
        /// </summary>
        double IterationObjectiveAverageValue = 0;
        [Browsable(false)]
        public double IterationObjectiveAverage
        {
            get { return IterationObjectiveAverageValue; }
            set { IterationObjectiveAverageValue = value; }
        }

        /// <summary>
        /// 是否要進行參數更新
        /// </summary>
        public bool UpdateParameter = true;

        /// <summary>
        /// 是否要以PSO做為快速收斂之轉換條件
        /// </summary>
        public bool TurnToPso = true;

        /// <summary>
        /// 定義進行多少次數比例的迭代才轉換至PSO
        /// </summary>
        public double PropotionOfTurn = 0;

        //利用建構子載入運算需要用的資料及外來函式
        public AFSOSolver(int num, AFSOObjectiveFunctionDelegate objFunction, double[] mins, double[] maxs,bool Update_Parameters,bool AFSO_PSOEnd, double AFSO_PSOEnd_Bar)
        {
            numberOfVariables = num;
            GetObjectiveValue = objFunction;
            SoFarTheBestSolution = new double[numberOfVariables];
            lowerBounds = mins;
            upperBounds = maxs;
            UpdateParameter = Update_Parameters;

            TurnToPso = AFSO_PSOEnd;
            PropotionOfTurn = AFSO_PSOEnd_Bar;
        }

        /// <summary>
        /// 重置物件，將相關資料陣列重新宣告並呼叫初始化方法產生起始資料
        /// </summary>
        virtual public void Reset()
        {
            if (FishSolution == null || FishSolution.Length != NumberOfFishs)
            {
                //宣告魚群與適應值陣列
                FishSolution = new double[NumberOfFishs][];
                for (int i = 0; i < NumberOfFishs; i++)
                    FishSolution[i] = new double[numberOfVariables];
                FishObjective = new double[NumberOfFishs];

                //宣告下一步位置之陣列
                FishNextSolution = new double[NumberOfFishs][];
                for (int i = 0; i < NumberOfFishs; i++)
                    FishNextSolution[i] = new double[numberOfVariables];

                //宣告自身記憶陣列
                SelftBestPosition = new double[NumberOfFishs][];
                for (int i = 0; i < NumberOfFishs; i++)
                    SelftBestPosition[i] = new double[numberOfVariables];
                SelfBestObjective = new double[NumberOfFishs];

                //宣告速度陣列
                Velocity = new double[NumberOfFishs][];
            }

            Initialization();
            UpdateTheBestPositions();
            IterationCount = 0;
            NonImproveCounter = 0;

        }

        /// <summary>
        /// 產生起始資料
        /// </summary>
        virtual public void Initialization()
        {
            // Randomly initialize values to both FishSolution and individualBestSolutions
            // Evaluate object values as set so far the best solution and value.

            //初始化魚群下一步動作的陣列
            FishNextMove = new int[NumberOfFishs];

            for (int i = 0; i < NumberOfFishs; i++)
            {
                FishNextMove[i] = 4;
                //初始化資料陣列，包括速度、魚群中每個魚的解
                FishSolution[i] = new double[numberOfVariables];
                FishNextSolution[i] = new double[numberOfVariables];
                Velocity[i] = new double[numberOfVariables];
                SelftBestPosition[i] = new double[numberOfVariables];

                for (int j = 0; j < numberOfVariables; j++)
                {
                    //定義魚初代位置及速度，但傳統人工魚群並不會用到速度
                    FishSolution[i][j] = FishSolution[i][j] = lowerBounds[j] + (upperBounds[j] - lowerBounds[j]) * RandomGenerator.NextDouble();
                    SelftBestPosition[i][j] = FishSolution[i][j];
                    Velocity[i][j] = (upperBounds[j] - lowerBounds[j]) * RandomGenerator.NextDouble();
                }
                SelfBestObjective[i] = FishObjective[i] = GetObjectiveValue(FishSolution[i]);
            }

            //最小化問題：起始值為可用最大值
            for (int i = 0; i < NumberOfFishs; i++)
                SelfBestObjective[i] = double.MaxValue;
            SoFarTheBestObjective = double.MaxValue;
            IterationBestObjective = double.MaxValue;
            Sight = InitialSight;
            Step = InitialStep;
        }

        bool[] ActionArray;
        /// <summary>
        /// 進行一次迭代
        /// </summary>
        virtual public void RunOneIteration()
        {
            if (TurnToPso == true)
            {
                double temp2 = IterationCount;
                double temp3 = IterationLimitTimes;
                double CurrentPropotion = 1-(double)(temp2 / temp3);
                if (PropotionOfTurn / 100 <= CurrentPropotion)
                {
                    //隨機決定魚群採用簇擁或是追隨
                    ActionArray = new bool[NumberOfFishs];
                    for (int i = 0; i < NumberOfFishs; i++)
                    {
                        Double temp = RandomGenerator.NextDouble();
                        int booleanConvert = (int)Math.Round(temp, 0);
                        if (booleanConvert == 0)
                            ActionArray[i] = true;
                        else
                            ActionArray[i] = false;
                    }
                    // Move to new positions
                    Swarm();
                    Follow();
                    Action();
                    if (UpdateParameter == true)
                        UpdateParameters();
                }
                else
                {
                    MoveFishsToNewPositions();
                }
            }


            // Evaluate objectives, update self, iteraton best, and so far the best solution.
            UpdateTheBestPositions();
            // Forward iteration counter
            IterationCount++;
        }

        /// <summary>
        /// 魚群簇擁行為涵式：魚群群聚在一起以避免危險；魚隻將由向其他視覺範圍內之幾何中心Xc
        /// </summary>
        virtual public void Swarm()
        {
            //計算每隻魚視線範圍內的魚群，i為計算中心點以Sight展開半徑搜尋其他魚隻
            for (int i = 0; i < NumberOfFishs; i++)
            {
                if (ActionArray[i] == true)
                {
                    //紀錄對i魚隻來說在視線範圍內的幾何中心位置，初始化歸零
                    double[] CrowCenter = new double[numberOfVariables];
                    for (int k = 0; k < numberOfVariables; k++)
                        CrowCenter[k] = 0;

                    //紀錄哪些魚群在此魚之視線範圍內，j為判定目標
                    int tempCounter = 0;

                    for (int j = 0; j < NumberOfFishs; j++)
                    {
                        //若j魚在i魚的視線範圍內，則將其納入計算幾何中心之考量範圍
                        if (NeighborDistinguish(FishSolution[i], FishSolution[j]) == true)
                        {
                            tempCounter++;
                            for (int k = 0; k < numberOfVariables; k++)
                                CrowCenter[k] += FishSolution[j][k];
                        }
                    }
                    //每個維度皆最終需除以視線範圍內魚群之數量，得幾何中心做標
                    for (int k = 0; k < numberOfVariables; k++)
                        CrowCenter[k] /= tempCounter;

                    //若i魚隻採用簇擁有較高的效益，且目前為可接受之壅塞程度，則進行簇擁
                    double temp = GetObjectiveValue(FishSolution[i]);
                    temp = GetObjectiveValue(CrowCenter);
                    if (GetObjectiveValue(FishSolution[i]) > GetObjectiveValue(CrowCenter))
                    {
                        FishNextMove[i] = 0;
                        if ((tempCounter / NumberOfFishs) <= CongestionDegree)
                        {
                            double EuclideanDistance = GetEuclideanDistance(FishSolution[i], CrowCenter);
                            if (EuclideanDistance > 0.001)//避免當距離太接近時移動步幅趨近於無窮大的問題
                            {
                                for (int k = 0; k < numberOfVariables; k++)
                                {
                                    double MoveSize = (CrowCenter[k] - FishSolution[i][k]) / EuclideanDistance;
                                    FishNextSolution[i][k] = FishSolution[i][k] + RandomGenerator.NextDouble() * Step * MoveSize;

                                    /// <summary>
                                    /// 若超出邊界則停留於邊界
                                    /// </summary>
                                    if (FishNextSolution[i][k] >= upperBounds[k])//若大於上界，則為上界
                                        FishNextSolution[i][k] = upperBounds[k];

                                    if (FishNextSolution[i][k] <= lowerBounds[k])//若小於下界，則為下界
                                        FishNextSolution[i][k] = lowerBounds[k];
                                }
                            }//End Distance If
                            else
                            {
                                Prey(i);
                            }
                        }//End If Inside
                        else
                        {
                            Prey(i);
                        }
                    }//End If Outside
                    else
                    {
                        Prey(i);
                    }
                }//End Boolean Action
            }//End For i
        }

        /// <summary>
        /// 魚群追隨行為函式：魚群尋找視覺範圍中比自己有更佳位置的魚隻，並前往該位置Xsp
        /// </summary>
        virtual public void Follow()
        {
            //計算每隻魚視線範圍內的魚群，i為計算中心點以Sight展開半徑搜尋其他魚隻
            for (int i = 0; i < NumberOfFishs; i++)
            {
                if (ActionArray[i] == false)
                {
                    //紀錄對i魚隻來說在視線範圍內的幾何中心位置，初始化歸零
                    double[] CrowCenter = new double[numberOfVariables];
                    for (int k = 0; k < numberOfVariables; k++)
                        CrowCenter[k] = 0;

                    //宣告兩個以夥伴數量為長度的陣列，以距離為標的儲存最接近的魚群的位置，再自中挑選最佳者做為追隨對象
                    double[] DistandeArray = new double[FriendSize];
                    FishCrowList = new double[FriendSize][];
                    for (int f = 0; f < FriendSize; f++)
                    {
                        DistandeArray[f] = double.MaxValue;
                        FishCrowList[f] = new double[numberOfVariables];
                    }

                    int FoundFriend = 0;
                    //對所有其他魚群作搜索，找最近的幾個
                    for (int j = 0; j < NumberOfFishs; j++)
                    {
                        int counter = 0;
                        while (counter < FriendSize)
                        {
                            if (GetEuclideanDistance(FishSolution[i], FishSolution[j]) < DistandeArray[counter])
                            {
                                DistandeArray[counter] = GetEuclideanDistance(FishSolution[i], FishSolution[j]);
                                for (int c = 0; c < numberOfVariables; c++)
                                    FishCrowList[counter][c] = FishSolution[j][c];
                                Array.Reverse(DistandeArray, 0, FriendSize);
                                counter = FriendSize;
                                FoundFriend++;
                            }
                            counter++;
                        }//End While
                    }
                    if (FoundFriend > FriendSize)
                        FoundFriend = FriendSize;

                    int BestID = i;

                    for (int BestId = 0; BestId < FriendSize; BestId++)
                    {
                        if (GetObjectiveValue(FishCrowList[BestId]) < GetObjectiveValue(FishSolution[BestID]))
                            BestID = BestId;
                    }

                    if (BestID < FriendSize)
                    {
                        if ((FoundFriend / NumberOfFishs) <= CongestionDegree)
                        {
                            FishNextMove[i] = 1;
                            double EuclideanDistance = GetEuclideanDistance(FishSolution[i], FishCrowList[BestID]);

                            if (EuclideanDistance > 0.001)//避免當距離太接近時移動步幅趨近於無窮大的問題
                            {
                                for (int k = 0; k < numberOfVariables; k++)
                                {
                                    double MoveSize = (FishCrowList[BestID][k] - FishSolution[i][k]) / EuclideanDistance;
                                    FishNextSolution[i][k] = FishSolution[i][k] + RandomGenerator.NextDouble() * Step * MoveSize;

                                    /// <summary>
                                    /// 若超出邊界則停留於邊界
                                    /// </summary>
                                    if (FishNextSolution[i][k] >= upperBounds[k])//若大於上界，則為上界
                                        FishNextSolution[i][k] = upperBounds[k];

                                    if (FishNextSolution[i][k] <= lowerBounds[k])//若小於下界，則為下界
                                        FishNextSolution[i][k] = lowerBounds[k];
                                }
                            }//End Distance If
                            else
                            {
                                Prey(i);
                            }
                        }//End If Inside
                        else
                        {
                            Prey(i);
                        }
                    }//End If Outside
                    else
                    {
                        Prey(i);
                    }
                }//End Boolean Action
            }//End For i
        }

        /// <summary>
        /// 魚群捕食行為函式：若簇擁或追隨失敗則進行捕食，隨機進行數次Local求解，若成功則前往該位置Xaim
        /// </summary>
        virtual public void Prey(int i)
        {
            //進行TrialTimes次嘗試跳脫區域解
            double[][] AimList = new double[TrialTimes][];
            for (int aim = 0; aim < TrialTimes; aim++)
            {
                AimList[aim] = new double[numberOfVariables];
                for (int j = 0; j < numberOfVariables; j++)
                {
                    AimList[aim][j] = FishSolution[aim][j] + RandomGenerator.NextDouble() * Sight;
                }
                //若嘗試的解中有比目前更好的解，則進行替代
                if (GetObjectiveValue(AimList[aim]) < GetObjectiveValue(FishSolution[i]))
                {
                    FishNextMove[i] = 2;
                    double EuclideanDistance = GetEuclideanDistance(FishSolution[i], AimList[aim]);
                    if (EuclideanDistance > 0.001)//避免當距離太接近時移動步幅趨近於無窮大的問題
                    {
                        for (int k = 0; k < numberOfVariables; k++)
                        {
                            double MoveSize = (AimList[aim][k] - FishSolution[i][k]) / EuclideanDistance;
                            FishNextSolution[i][k] = FishSolution[i][k] + RandomGenerator.NextDouble() * Step * MoveSize;

                            /// <summary>
                            /// 若超出邊界則停留於邊界
                            /// </summary>
                            if (FishNextSolution[i][k] >= upperBounds[k])//若大於上界，則為上界
                                FishNextSolution[i][k] = upperBounds[k];

                            if (FishNextSolution[i][k] <= lowerBounds[k])//若小於下界，則為下界
                                FishNextSolution[i][k] = lowerBounds[k];
                        }
                    }//End Distance If
                    else
                    {
                        RandomMoving(i);
                    }
                }//End Outside If
                else
                {
                    RandomMoving(i);
                }
            }
        }

        /// <summary>
        /// 魚群隨機移動行為函式：若簇擁、追隨與捕食皆失敗則進行隨機移動，前該位置Xrnd
        /// </summary>
        virtual public void RandomMoving(int i)
        {
            FishNextMove[i] = 3;
            for (int k = 0; k < numberOfVariables; k++)
            {
                FishNextSolution[i][k] = FishSolution[i][k] + RandomGenerator.NextDouble() * Step;

                /// <summary>
                /// 若超出邊界則停留於邊界
                /// </summary>
                if (FishNextSolution[i][k] >= upperBounds[k])//若大於上界，則為上界
                    FishNextSolution[i][k] = upperBounds[k];

                if (FishNextSolution[i][k] <= lowerBounds[k])//若小於下界，則為下界
                    FishNextSolution[i][k] = lowerBounds[k];
            }
        }

        /// <summary>
        /// 參數調整機制，包括步伐大小與視覺範圍
        /// </summary>
        virtual public void UpdateParameters()
        {
            //根據Wang(2008)的文獻做參數之調整
            double alpha = Math.Exp(-30 * Math.Pow((IterationCount / IterationLimitTimes), 5));
            Sight = alpha * Sight + MinSight;
            Step = alpha * Step + MinStep;
        }

        /// <summary>
        /// 魚隻根據策略逐項進行移動，若行動失敗則採取其他行動
        /// </summary>
        virtual public void Action()
        {
            for (int i = 0; i < NumberOfFishs; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    FishSolution[i][j] = FishNextSolution[i][j];
                }
            }
        }

        //計算兩隻魚間的歐氏距離
        public double GetEuclideanDistance(double[] FishPositionA, double[] FishPositionB)
        {
            double tempDistance = 0;
            //計算兩隻魚間的歐氏距離，算法為各維度之差平方相加後開根號
            for (int i = 0; i < numberOfVariables; i++)
            {
                tempDistance += Math.Pow((FishPositionA[i] - FishPositionB[i]), 2);
            }
            return tempDistance = Math.Pow(tempDistance, 0.5);
        }

        //計算兩隻魚間之距離是否在視線範圍內
        public bool NeighborDistinguish(double[] FishPositionA, double[] FishPositionB)
        {
            double tempDistance = GetEuclideanDistance(FishPositionA, FishPositionB);

            //若於視線範圍內則判斷為是，否則為否
            if (tempDistance <= Sight)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 傳統PSO制度：進行魚的移動
        /// </summary>
        virtual public void MoveFishsToNewPositions()
        {
            // Referring to so far the best and each individual best 
            // Move to new position to set new FishSolution

            //先計算初始速度
            for (int i = 0; i < NumberOfFishs; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    Velocity[i][j] = SelfLearningFactor * (SelftBestPosition[i][j] - FishSolution[i][j]) * RandomGenerator.NextDouble()
                        //參考魚自身的記憶：己身過去最佳解的位置
                                    + SocialLearningFactor * (SoFarTheBestSolution[j] - FishSolution[i][j]) * RandomGenerator.NextDouble()
                        //參考前一代群體最佳解的位置
                                    + InteriaFactor * Velocity[i][j] * RandomGenerator.NextDouble();
                    //慣性的力量，考慮過去的前進方向，可選擇不考慮
                }
            }

            /// <summary>
            /// 若超出邊界則停留於邊界
            /// </summary>
            for (int i = 0; i < NumberOfFishs; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    FishSolution[i][j] = Velocity[i][j] + FishSolution[i][j];

                    if (FishSolution[i][j] >= upperBounds[j])//若大於上界，則為上界
                        FishSolution[i][j] = upperBounds[j];

                    if (FishSolution[i][j] <= lowerBounds[j])//若小於下界，則為下界
                        FishSolution[i][j] = lowerBounds[j];
                }
            }

        }

        /// <summary>
        /// 計算目標函數值、此次代解之平均以及更新全域最佳解及計算未改善次數
        /// </summary>
        virtual public void UpdateTheBestPositions()
        {
            double toatalobj = 0;
            for (int i = 0; i < NumberOfFishs; i++)
            {
                FishObjective[i] = GetObjectiveValue(FishSolution[i]);
                toatalobj = toatalobj + FishObjective[i];
                if (SelfBestObjective[i] > FishObjective[i])
                {
                    SelfBestObjective[i] = FishObjective[i];
                    for (int j = 0; j < numberOfVariables; j++)
                        SelftBestPosition[i][j] = FishSolution[i][j];
                }
            }
            indicesOfFish = new int[NumberOfFishsValue];
            //利用排序找出此代之最佳魚之目標函數值與此次代解之平均
            for (int i = 0; i < NumberOfFishs; i++) indicesOfFish[i] = i;
            Array.Sort(FishObjective, indicesOfFish, 0, NumberOfFishs);
            IterationBestSolution = FishSolution[0];
            IterationBestObjective = FishObjective[0];
            IterationObjectiveAverage = toatalobj / NumberOfFishs;

            //更新全域最佳解及計算未改善次數
            if (IterationBestObjective < SoFarTheBestObjective)
            {
                SoFarTheBestSolution = FishSolution[indicesOfFish[0]];
                SoFarTheBestObjective = IterationBestObjective;
                NonImproveCounter = 0;
            }
            else
                NonImproveCounter++;
        }

    }

    public delegate double AFSOObjectiveFunctionDelegate(double[] aSolution);
    public enum AFSOOptimizationType { Min, Max }
}
