using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics_Optimization_Project
{
    public enum EncodingMode { Binary, Permutation };

    class GASolver
    {
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////
        /// </summary>

        public EncodingMode Mode = EncodingMode.Binary;

        public enum SelectionMode { Stochastic, Deterministic };

        protected ObjectiveFunctionDelegate COPGetObjectiveValue;

        public double[][] GeneSolution;

        public int PercisionValue = 1;
        [Category("GA Parameters"), Description("各變數求解精度")]
        public int Percision
        {
            get { return PercisionValue; }
            set { PercisionValue = value; }
        }

        /// <summary>
        /// 記錄每個變數的上下界，避免跑出可行解區塊
        /// </summary>
        public double[] lowerBounds, upperBounds;

        SelectionMode SelectionTypeObject = SelectionMode.Deterministic;
        //預設為確定型選擇交配染色體模式
        [Category("GA Operation Modes"), Description("挑選進行交配染色體的模式，分為確定型與隨機型。")]
        public SelectionMode SelectType
        {
            get { return SelectionTypeObject; }
            set { SelectionTypeObject = value; }
        }
        //存取挑選進行交配的染色體模式的屬性

        int PopulationSizeValue = 30;
        [Category("GA Parameters"), Description("母體大小，建議不低於變數量之1/4。")]
        public int PopulationSize
        {
            get { return PopulationSizeValue; }
            set { if (value >= 0) PopulationSizeValue = value; }
        }
        //存取母體大小的屬性

        double CrossoverRateValue = 0.7;
        [Category("GA Parameters"), Description("交配率，建議界於0.5~0.9之間。")]
        public double CrossoverRate
        {
            get { return CrossoverRateValue; }
            set { if (value > 0 && value < 1) CrossoverRateValue = value; }
        }
        //存取交配率的屬性，預設為70%

        double MutationRateValue = 0.1;
        [Category("GA Parameters"), Description("突變率，建議界於0.01~0.1之間。")]
        public double MutationRate
        {
            get { return MutationRateValue; }
            set { if (value > 0 && value < 1) MutationRateValue = value; }
        }
        //存取突變率的屬性，預設為10%

        public int[] VariableLength;
        //各個變數佔用的格數，將該變數的間隔化為整數，看需要佔用二進位多少格

        public int NumberOfVariables;
        //存取工作數量的屬性

        public int NonImproveCounter = 0;
        //目前未改善解的次數

        int MaxIterationValue = 500;
        [Category("GA Parameters"), Description("內定的演化迭代次數上限，建議大於1000。")]
        public int MaxIteration
        {
            get { return MaxIterationValue; }
            set { if (value >= 0) MaxIterationValue = value; }
        }
        //存取最大迭代次數的屬性，預設為100代

        //連續未求得改善解的上限次數，若達到則強制收斂
        int iterationWithoutImprove = 100;
        [Category("Execution"), Description("連續未求得改善解之演化代次上限 Non-Improved Iteration Limit")]
        public int IterationWithoutImprove
        {
            get { return iterationWithoutImprove; }
            set { if (value >= 0) iterationWithoutImprove = value; }
        }

        public double[] Objective;
        //存取目標函式值的屬性

        public int CurrentIteration;
        //存取目前運算迭代次數的屬性

        public double IterationBestObjective;
        //存取當代最佳解的目標涵式值的屬性

        public double IterationAverage;
        //存取當代的平均目標函式值的屬性

        public double SoFarTheBestObjective;
        //存取截至目前為止最佳解的目標函式值的屬性

        protected int CrossoverPoolSize;
        protected int MutationPoolSize;
        //分別要作幾次交配與突變的屬性，與交配率及突變率有關

        public int[] tempIDs;
        public double[] tempObjs;

        protected double[] Probabilities;
        //存取輪盤法累計積率的陣列屬性

        public int[][] BinChromosome;
        //存取二元GA目前染色體的屬性

        public int[] BinGenerationBestSolution;
        //存取目前當代最佳解的目標函數值

        public int[] SoFarTheBestSolutionBinary;
        //存取截至目前Binary-GA為止最好的解的模樣

        public double[] Fitness;

        public double[][] ChromosomeSolution=new double[1][];

        public int totalLength = 0;
        //染色體總長度

        /////////////////////////////////////////////////////////////////
        //等待實作的各個函式
        /////////////////////////////////////////////////////////////////

        protected virtual double GetObjectiveValue(int[] x)
        {
            double y = 0.0;
            return y;
        }

        public virtual void InitializePopulation()
        {

        }

        public virtual void Initialize()
        {

        }

        public virtual void RunOneIteration()
        {

        }

        public virtual void CrossOver()
        {

        }

        public virtual void Mutate()
        {

        }

        public virtual void Eliminate()
        {

        }

        public virtual void SetFitness(int FitnessIndex, double Objective)
        {

        }

        public virtual void UpdateSolutionAndObjective()
        {
        }

        public virtual void RunToEnd()
        {

        }
        public delegate double ObjectiveFunctionDelegate(double[] aSolution);
    }
}
