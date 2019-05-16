using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Combinatorics_Optimization_Project
{
    public class PSOSolver
    {
        PSOObjectiveFunctionDelegate GetObjectiveValue;

        /// <summary>
        /// 記錄變數維度數量
        /// </summary>
        int numberOfVariables;

        /// <summary>
        /// 記錄每個變數的上下界，避免粒子跑出可行解區塊
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
        /// 演算次數
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
        /// 此粒子群的規模數量大小
        /// </summary>
        int NumberOfParticlesValue = 20;
        [Category("PSO Setting"), Description("現存粒子群之粒子數 Number of Particles ")]
        public int NumberOfParticles
        {
            get { return NumberOfParticlesValue; }
            set { NumberOfParticlesValue = value; }
        }

        /// <summary>
        /// 參考粒子群中當下帶有最好解之粒子位置的權重
        /// </summary>
        double SocialLearningFactorValue = 2;
        [Category("PSO Setting"), Description("粒子間彼此速度影響之係數 Social Factor ")]
        public double SocialLearningFactor
        {
            get { return SocialLearningFactorValue; }
            set { SocialLearningFactorValue = value; }
        }

        /// <summary>
        /// 參考粒子本身最佳解之位置的權重
        /// </summary>
        double SelfLearningFactorValue = 2;
        [Category("PSO Setting"), Description("粒子參考本身最佳位置記憶之係數 Self Factor ")]
        public double SelfLearningFactor
        {
            get { return SelfLearningFactorValue; }
            set { SelfLearningFactorValue = value; }
        }

        /// <summary>
        /// 參考前次速度的權重
        /// </summary>
        double InteriaFactorValue = 1.2;
        [Category("PSO Setting"), Description("粒子本身慣性速度影響之係數 Interia Factor ")]
        public double InteriaFactor
        {
            get { return InteriaFactorValue; }
            set { InteriaFactorValue = value; }
        }
        
        
        //根據2011 - "A Hybrid Algorithm for Flexible Job-shop Scheduling Problem" Jianchao Tanga,b,*, 
        //Guoji Zhanga, Binbin Lina, Bixi Zhangc
        double MaxInteriaFactor = 1.2;
        double MinInteriaFactor = 0.4;

        /// <summary>
        /// 紀錄所有粒子所帶的解，前面陣列維度為粒子數，後面陣列維度為變數維度
        /// </summary>
        double[][] ParticleSolutionValue;
        [Browsable(false)]
        public double[][] ParticleSolution
        {
            get
            { return ParticleSolutionValue; }
            set
            { ParticleSolutionValue = value; }
        }

        int[] indicesOfParticle;

        /// <summary>
        /// 目前紀錄粒子所帶的解的目標函數值
        /// </summary>
        double[] ParticleObjectiveValue;
        [Browsable(false)]
        public double[] ParticleObjective
        {
            get
            { return ParticleObjectiveValue; }
            set
            { ParticleObjectiveValue = value; }
        }

        /// <summary>
        /// 記錄每粒子前一次維持的速度(即各個維度與前一次的差異)
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
        /// 記錄粒子自身過去以來曾經到過之最佳位置
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
        /// 記錄粒子自身過去以來曾經到過之最佳位置之目標函數值
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
        /// 儲存渾沌序列的值，根據Bilal Alatas *, Erhan Akin, A. Bedri Ozer Firat University, 
        /// Department of Computer Engineering, 23119 Elazig, Turkey Accepted 17 September 2007
        /// 以混沌序列替代w和r
        /// </summary>
        double[][] ChaosticSequenceValue;
        [Browsable(false)]
        public double[][] ChaosticSequence
        {
            get { return ChaosticSequenceValue; }
            set { ChaosticSequenceValue = value; }
        }

        //存取要使用哪種映射函數的屬性
        bool UseChaosticValue = true;
        int UseChaostic = 0;

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

        //利用建構子載入運算需要用的資料及外來函式
        public PSOSolver(int num, PSOObjectiveFunctionDelegate objFunction, double[] mins, double[] maxs, bool UpdateParameterValue, bool BoolUseChaosticValue, int UseChaosticType)
        {
            numberOfVariables = num;
            GetObjectiveValue = objFunction;
            SoFarTheBestSolution = new double[numberOfVariables];
            lowerBounds = mins;
            upperBounds = maxs;
            UpdateParameter = UpdateParameterValue;

            UseChaosticValue = BoolUseChaosticValue;
            if (UseChaosticValue == true)
                UseChaostic = UseChaosticType;
        }

        /// <summary>
        /// 重置物件，將相關資料陣列重新宣告並呼叫初始化方法產生起始資料
        /// </summary>
        virtual public void Reset()
        {
            if (ParticleSolution == null || ParticleSolution.Length != NumberOfParticles)
            {
                ParticleSolution = new double[NumberOfParticles][];
                for (int i = 0; i < NumberOfParticles; i++)
                    ParticleSolution[i] = new double[numberOfVariables];
                ParticleObjective = new double[NumberOfParticles];

                SelftBestPosition = new double[NumberOfParticles][];
                for (int i = 0; i < NumberOfParticles; i++)
                    SelftBestPosition[i] = new double[numberOfVariables];
                SelfBestObjective = new double[NumberOfParticles];

                //初始化混沌序列長度為粒子數
                ChaosticSequence = new double[NumberOfParticles][];
                for (int i = 0; i < NumberOfParticles; i++)
                    ChaosticSequence[i] = new double[numberOfVariables + 1];
                //根據文獻，加入了替代w項的混沌序列

                Velocity = new double[NumberOfParticles][];
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
            // Randomly initialize values to both ParticleSolution and individualBestSolutions
            // Evaluate object values as set so far the best solution and value.

            for (int i = 0; i < NumberOfParticles; i++)
            {
                //初始化資料陣列，包括速度、粒子群中每個粒子的解
                ParticleSolution[i] = new double[numberOfVariables];
                Velocity[i] = new double[numberOfVariables];
                SelftBestPosition[i] = new double[numberOfVariables];

                //定義粒子初代位置及速度
                for (int j = 0; j < numberOfVariables; j++)
                {
                    //初始化粒子速度及位置
                    ParticleSolution[i][j] = ParticleSolution[i][j] = lowerBounds[j] + (upperBounds[j] - lowerBounds[j]) * RandomGenerator.NextDouble();
                    SelftBestPosition[i][j] = ParticleSolution[i][j];
                    Velocity[i][j] = (upperBounds[j] - lowerBounds[j]) * RandomGenerator.NextDouble();
                }
                SelfBestObjective[i] = ParticleObjective[i] = GetObjectiveValue(ParticleSolution[i]);
            }

            //最小化問題：起始值為可用最大值
            for (int i = 0; i < NumberOfParticles; i++)
                SelfBestObjective[i] = double.MaxValue;
            SoFarTheBestObjective = double.MaxValue;
            IterationBestObjective = double.MaxValue;
        }

        /// <summary>
        /// 以混沌理論的策略進行粒子移動，根據丟進來的迭代次數採取不同映射方法，進一步呼叫各種映射函式
        /// </summary>
        /// <param name="IterationIndex"></param>
        virtual public void ChaosticMove(int IterationIndex)
        {
            //"Logistic Map", "Tent Map", "Sinusoidal Iterator", "Gauss Map", "Circle Map"
            switch (UseChaostic)
            {
                case 0:
                    LogisticMap(IterationIndex);
                    break;

                case 1:
                    TentMap(IterationIndex);
                    break;

                case 2:
                    SinusoidalIterator(IterationIndex);
                    break;

                case 3:
                    GaussMap(IterationIndex);
                    break;

                case 4:
                    CircleMap(IterationIndex);
                    break;
                case 5:
                    DoubleButtonMap(IterationIndex);
                    break;
            }
        }

        /// <summary>
        /// 各種混沌函式
        /// </summary>
        virtual public void LogisticMap(int t)
        {
            //若是第一次初始化，則先隨機產生一初始值當作混沌函數之起始值
            if (t == 0)
            {
                for (int i = 0; i < NumberOfParticles; i++)
                {
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        double x;
                        bool XIsQuarter = true;
                        do
                        {
                            x = RandomGenerator.NextDouble();
                            if (x == 0 || x == 0.25 || x == 0.5 || x == 0.75 || x == 1.00)
                            {
                                x = RandomGenerator.NextDouble();
                            }
                            else
                            {
                                ChaosticSequence[i][j] = x;
                                XIsQuarter = false;
                            }

                        } while (XIsQuarter == true);
                    }
                }
            }
            else
            //開始進行映射
            {
                //Bilal Alatas *, Erhan Akin , 2007
                double Alpha = 4;
                for (int i = 0; i < NumberOfParticles; i++)
                {
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        ChaosticSequence[i][j] = Alpha * ChaosticSequence[i][j] * (1 - ChaosticSequence[i][j]);
                    }
                }
            }
        }
        virtual public void TentMap(int t)
        {
            //若是第一次初始化，則先隨機產生一初始值當作混沌函數之起始值
            if (t == 1)
            {
                for (int i = 0; i < NumberOfParticles; i++)
                    for (int j = 0; j < numberOfVariables + 1; j++)
                        ChaosticSequence[i][j] = RandomGenerator.NextDouble();
            }
            else
            //開始進行映射
            {
                for (int i = 0; i < NumberOfParticles; i++)
                {
                    for (int j = 0; j < numberOfVariables + 1; j++)
                    {
                        if (ChaosticSequence[i][j] < 0.7)
                            ChaosticSequence[i][j] = ChaosticSequence[i][j] / 0.7;
                        else
                            ChaosticSequence[i][j] = 10 / (3 * ChaosticSequence[i][j] * (1 - ChaosticSequence[i][j]));
                    }
                }
            }
        }
        virtual public void SinusoidalIterator(int t)
        {
            //若是第一次初始化，則先隨機產生一初始值當作混沌函數之起始值
            if (t == 1)
            {
                for (int i = 0; i < NumberOfParticles; i++)
                    for (int j = 0; j < numberOfVariables + 1; j++)
                        ChaosticSequence[i][j] = RandomGenerator.NextDouble();
            }
            else
            //開始進行映射
            {
                double Alpha = 2.3;
                for (int i = 0; i < NumberOfParticles; i++)
                {
                    for (int j = 0; j < numberOfVariables + 1; j++)
                    {
                        ChaosticSequence[i][j] = Alpha * (Math.Pow(ChaosticSequence[i][j], 2) * (Math.Sin(Math.PI * ChaosticSequence[i][j])));
                    }
                }
            }
        }
        virtual public void GaussMap(int t)
        {
            //若是第一次初始化，則先隨機產生一初始值當作混沌函數之起始值
            if (t == 1)
            {
                for (int i = 0; i < NumberOfParticles; i++)
                    for (int j = 0; j < numberOfVariables + 1; j++)
                        ChaosticSequence[i][j] = RandomGenerator.NextDouble();
            }
            else
            //開始進行映射
            {
                for (int i = 0; i < NumberOfParticles; i++)
                {
                    for (int j = 0; j < numberOfVariables + 1; j++)
                    {
                        if (ChaosticSequence[i][j] == 0)
                            ChaosticSequence[i][j] = 0;
                        else
                        {
                            ChaosticSequence[i][j] = (1 / ChaosticSequence[i][j]) % 1;
                        }
                    }
                }
            }
        }
        virtual public void CircleMap(int t)
        {
            //若是第一次初始化，則先隨機產生一初始值當作混沌函數之起始值
            if (t == 1)
            {
                for (int i = 0; i < NumberOfParticles; i++)
                    for (int j = 0; j < numberOfVariables + 1; j++)
                        ChaosticSequence[i][j] = RandomGenerator.NextDouble();
            }
            else
            //開始進行映射
            {
                double Alpha = 0.5;
                double Beta = 0.2;
                for (int i = 0; i < NumberOfParticles; i++)
                {
                    for (int j = 0; j < numberOfVariables + 1; j++)
                    {
                        ChaosticSequence[i][j] = (ChaosticSequence[i][j] + Beta - (Alpha / (2 * Math.PI)) * (Math.Sin(2 * Math.PI * ChaosticSequence[i][j]))) % 1;
                    }
                }
            }
        }
        virtual public void DoubleButtonMap(int t)
        {
            //若是第一次初始化，則先隨機產生一初始值當作混沌函數之起始值
            if (t == 0)
            {
                for (int i = 0; i < NumberOfParticles; i++)
                {
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        double x;
                        bool XIsQuarter = true;
                        do
                        {
                            x = RandomGenerator.NextDouble();
                            if (x == 0 || x == 0.25 || x == 0.5 || x == 0.75 || x == 1.00)
                            {
                                x = RandomGenerator.NextDouble();
                            }
                            else
                            {
                                ChaosticSequence[i][j] = x;
                                XIsQuarter = false;
                            }

                        } while (XIsQuarter == true);
                    }
                }
            }
            else
            //開始進行映射
            {
                //Bilal Alatas *, Erhan Akin , 2007
                double n = 4;
                for (int i = 0; i < NumberOfParticles; i++)
                {
                    for (int j = 0; j < numberOfVariables; j++)
                    {
                        ChaosticSequence[i][j] = (Math.Sin(2 * n * Math.PI * ChaosticSequence[i][j]) + 1) / 2;
                            //Alpha * ChaosticSequence[i][j] * (1 - ChaosticSequence[i][j]);
                    }
                }
            }
        }

        /// <summary>
        /// 進行一次迭代
        /// </summary>
        virtual public void RunOneIteration()
        {
            //以渾沌機制之參數進行移動
            if (UseChaosticValue == true)
                ChaosticMove(IterationCount);

            // Move to new positions
            MoveParticlesToNewPositions();
            // Evaluate objectives, update self, iteraton best, and so far the best solution.
            if (UpdateParameter == true)
                UpdateParameters();

            UpdateTheBestPositions();
            // Forward iteration counter
            IterationCount++;
        }

        /// <summary>
        /// 參數調整機制，調整inertia weight
        /// </summary>
        virtual public void UpdateParameters()
        {
            //inertia weight自MaxInteriaFactor線性遞減至MinInteriaFactor
            InteriaFactor = MaxInteriaFactor - ((MaxInteriaFactor - MinInteriaFactor) * (IterationCount) / IterationLimitTimes);
        }

        /// <summary>
        /// 進行粒子的移動
        /// </summary>
        virtual public void MoveParticlesToNewPositions()
        {
            // Referring to so far the best and each individual best 
            // Move to new position to set new ParticleSolution

            //先計算初始速度
            for (int i = 0; i < NumberOfParticles; i++)
            {
                double r1 = RandomGenerator.NextDouble();
                double r2 = RandomGenerator.NextDouble();

                for (int j = 0; j < numberOfVariables; j++)
                {
                    //採用混沌機制之移動方式
                    if (UseChaosticValue == true)
                    {
                        Velocity[i][j] = SelfLearningFactor * (SelftBestPosition[i][j] - ParticleSolution[i][j]) * ChaosticSequence[i][0]
                            //參考粒子自身的記憶：己身過去最佳解的位置
                                    + SocialLearningFactor * (SoFarTheBestSolution[j] - ParticleSolution[i][j]) * ChaosticSequence[i][1]
                            //參考前一代群體最佳解的位置
                                    + ChaosticSequence[i][2] * Velocity[i][j];
                        //慣性的力量以混沌序列最後一碼代替，考慮過去的前進方向，可選擇不考慮
                    }
                    //一般模式
                    else
                    {
                        Velocity[i][j] = SelfLearningFactor * (SelftBestPosition[i][j] - ParticleSolution[i][j]) * r1
                            //參考粒子自身的記憶：己身過去最佳解的位置
                                    + SocialLearningFactor * (SoFarTheBestSolution[j] - ParticleSolution[i][j]) * r2
                            //參考前一代群體最佳解的位置
                                    + InteriaFactor * Velocity[i][j];
                        //慣性的力量，考慮過去的前進方向，可選擇不考慮
                    }
                }
            }



            /// <summary>
            /// 若超出邊界則停留於邊界
            /// </summary>
            for (int i = 0; i < NumberOfParticles; i++)
            {
                for (int j = 0; j < numberOfVariables; j++)
                {
                    ParticleSolution[i][j] = Velocity[i][j] + ParticleSolution[i][j];

                    if (ParticleSolution[i][j] >= upperBounds[j])//若大於上界，則為上界
                        ParticleSolution[i][j] = upperBounds[j];

                    if (ParticleSolution[i][j] <= lowerBounds[j])//若小於下界，則為下界
                        ParticleSolution[i][j] = lowerBounds[j];
                }
            }

        }

        /// <summary>
        /// 計算目標函數值、此次代解之平均以及更新全域最佳解及計算未改善次數
        /// </summary>
        virtual public void UpdateTheBestPositions()
        {
            double toatalobj = 0;
            for (int i = 0; i < NumberOfParticles; i++)
            {
                ParticleObjective[i] = GetObjectiveValue(ParticleSolution[i]);
                toatalobj = toatalobj + ParticleObjective[i];
                if (SelfBestObjective[i] > ParticleObjective[i])
                {
                    SelfBestObjective[i] = ParticleObjective[i];
                    for (int j = 0; j < numberOfVariables; j++)
                        SelftBestPosition[i][j] = ParticleSolution[i][j];
                }
            }
            indicesOfParticle = new int[NumberOfParticlesValue];
            //利用排序找出此代之最佳粒子之目標函數值與此次代解之平均
            for (int i = 0; i < NumberOfParticles; i++) indicesOfParticle[i] = i;
            Array.Sort(ParticleObjective, indicesOfParticle, 0, NumberOfParticles);
            IterationBestSolution = ParticleSolution[0];
            IterationBestObjective = ParticleObjective[0];
            IterationObjectiveAverage = toatalobj / NumberOfParticles;

            //更新全域最佳解及計算未改善次數
            if (IterationBestObjective < SoFarTheBestObjective)
            {
                SoFarTheBestSolution = ParticleSolution[indicesOfParticle[0]];
                SoFarTheBestObjective = IterationBestObjective;
                NonImproveCounter = 0;
            }
            else
                NonImproveCounter++;
        }

    }

    public delegate double PSOObjectiveFunctionDelegate(double[] aSolution);
    public enum PSOOptimizationType { Min, Max }

}
