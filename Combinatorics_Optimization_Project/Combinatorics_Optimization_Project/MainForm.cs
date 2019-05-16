using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using COP;

namespace Combinatorics_Optimization_Project
{
    public partial class MainForm : Form
    {

        int[] CompareChartIndex = new int[10];

        public MainForm()
        {
            InitializeComponent();
            PSO_Create.Enabled = PSO_OneIteration.Enabled = PSO_Reset.Enabled = PSO_WholeIteration.Enabled = false;
            GA_Create.Enabled = GA_OneInteration.Enabled = GA_Reset.Enabled = GA_WholeInteration.Enabled = false;
            //未載入資料前不可啟動按鈕

            //載入Combobox的內容，用文字陣列形式載入，長度為四但不寫死(length)
            String[] MappingName = { "Logistic Map", "Tent Map", "Sinusoidal Iterator", "Gauss Map", "Circle Map" ,"Double-Button Map"};
            for (int i = 0; i <= MappingName.Length - 1; i++)
                PSO_ChaoticCombobox.Items.Add(MappingName[i]);

            for (int i = 0; i < 10; i++)
                CompareChartIndex[i] = -1;

            
        }

        COPBenchmark theProblem;

        PSOSolver PSOSolver;
        //等待實作的PSO
        GASolver GAObject;
        //先宣告一個GA物件等待被實作
        AFSOSolver AFSOSolver;

        String PSO_SolutionString = "";
        String PSO_VelocityString = "";
        //存取

        /// <summary>
        /// 讀入資料集及載入左邊界面
        /// </summary>
        private void LoadCOPFile_Click(object sender, EventArgs e)
        {
            // 秀出對話盒讀檔產生問題物件
            theProblem = COPBenchmark.LoadAProblemFromAFile();
            // 問題物件相關的屬性和函式都可透過 theProblem.xxx 取得
            // TSPBenchmark 有一些 類別層級 的靜態函式可用，透過 TSPBenchmark.xxx 取得

            if (theProblem == null) return;

            // 將問題的各種資訊秀在 spcMain.Panel1 上
            theProblem.DisplayOnPanel(spcMain.Panel1);

            // 將問題的目標函數投影曲面 3D 圖秀在 pagObjective
            if (theProblem.Dimension == 2)
                theProblem.DisplayObjectiveGraphics(SolutionTab);

            COPTab.Enabled = GA_Create.Enabled = PSO_Create.Enabled = AFSO_Create.Enabled = PSO_ChaoticCheck.Enabled = PSO_UpdateParameters.Checked = AFSO_PSOEnd.Checked = AFSO_PSOEnd_Bar.Enabled = true;
            PSO_ChaoticCombobox.SelectedIndex = 0;
            PSO_ChaoticCombobox.Enabled = PSO_ChaoticCheck.Checked = false;


            //將所有介面重置

            ResultChart.Series[0].Points.Clear();
            ResultChart.Series[1].Points.Clear();
            ResultChart.Series[2].Points.Clear();

            //每當讀入資料集時便更新所有介面中的文字視窗
            PSO_BestObjectiveTextBox.Text = PSO_BestSolutionRichBox.Text = GA_BestObjectiveTextBox.Text = GA_BestSolutionRichBox.Text
                 = AFSO_BehaviorRtb.Text = AFSO_BestObjectiveTextBox.Text
                 = PSO_SolutionRtb.Text = PSO_VelocityRtb.Text = GA_SolutionRtb.Text = GA_ChromosomeRtb.Text = AFSO_SolutionRtb.Text = AFSO_BehaviorRtb.Text = "";

            //控制Run-All部分的check box
            IPSOCheck.Enabled = TPSOCheck.Enabled = CPSO_CircleCheck.Enabled = CPSO_GaussCheck.Enabled = CPSO_LogisticCheck.Enabled = CPSO_SinusoidalCheck.Enabled = CPSO_TentCheck.Enabled
                = GA_BinaryCheck.Enabled = AFSO_Check.Enabled = CPSO_DoubleButtonCheck.Enabled= true;

        }

        /// <summary>
        /// 創造AFSO物件
        /// </summary>
        private void CreateAFSOSolver(object sender, EventArgs e)
        {
            AFSOSolver = new AFSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, AFSO_Update_Parameters.Checked, AFSO_PSOEnd.Checked, AFSO_PSOEnd_Bar.Value);
            //實作出PSO物件，給入資訊為變數維度數/取得目標值函數的function/各個變數的上下界等

            PropertyGrid.SelectedObject = AFSOSolver;

            AFSO_Reset.Enabled = true;
        }

        /// <summary>
        /// 點擊重置按鈕
        /// </summary>
        private void AFSO_Reset_Click(object sender, EventArgs e)
        {

            //將人機界面初始化
            ReNewInterface();

            //初始化AFSO物件的資料集
            AFSOSolver.Reset();

            // 將目前的particles秀在圖上
            theProblem.DisplaySolutionsOnGraphics(AFSOSolver.FishSolution);
            AFSO_OneIteration.Enabled = AFSO_WholeIteration.Enabled = true;
        }

        /// <summary>
        /// AFSO進行一代運算
        /// </summary>
        private void AFSO_OneIteration_Click(object sender, EventArgs e)
        {
            AFSOSolver.RunOneIteration();
            AFSO_UpDateData();
            AFSO_UpdateInRealTimeInterface();
            theProblem.DisplaySolutionsOnGraphics(AFSOSolver.FishSolution);
        }

        /// <summary>
        /// AFSO進行全域運算
        /// </summary>
        private void AFSO_WholeIteration_Click(object sender, EventArgs e)
        {
            while (AFSOSolver.IterationCount < AFSOSolver.IterationLimitTimes)
            {
                AFSOSolver.RunOneIteration();
                AFSO_UpDateData();
                if (AFSO_UpdateInRealTime.Checked)
                    AFSO_UpdateInRealTimeInterface();
                if (AFSO_StopByLimitedTimes.Checked)
                {
                    if (AFSOSolver.NonImproveCounter == AFSOSolver.IterationWithoutImprove)
                    {
                        MessageBox.Show("It has been " + AFSOSolver.IterationWithoutImprove + " iteration without improved at iteration " + AFSOSolver.IterationCount + " ! ", "Iteration Without Improve was reached");
                        break;
                    }
                }
            }
            AFSO_UpDateData();
            AFSO_UpdateInRealTimeInterface();
            MessageBox.Show("PSO Execution has been completed!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        string AFSO_SolutionString = "";
        string AFSO_BehaviorString = "";
        /// <summary>
        /// 對人機介面做更新，包括chart、顯示現行最佳解的listBox和最佳值的Label等
        /// </summary>
        private void AFSO_UpDateData()
        {
            AFSO_BestSolutionRichBox.Clear();

            Console.Write(AFSOSolver.SoFarTheBestSolution[0]);

            AFSO_BestSolutionRichBox.Text = AFSOGetStringSolution(AFSOSolver.SoFarTheBestSolution);

            AFSO_BestObjectiveTextBox.Text = AFSOSolver.SoFarTheBestObjective.ToString("0.000");
            //若有求得更佳解則進行求解區塊資料更新

            ResultChart.Series[0].Points.AddXY(AFSOSolver.IterationCount, AFSOSolver.IterationBestObjective);
            //此代最佳解
            ResultChart.Series[1].Points.AddXY(AFSOSolver.IterationCount, AFSOSolver.IterationObjectiveAverage);
            //此代解平均值
            ResultChart.Series[2].Points.AddXY(AFSOSolver.IterationCount, AFSOSolver.SoFarTheBestObjective);
            //至目前為止最佳解(全域最佳解))

            AFSO_SolutionString = AFSOGetAllStringSolution(AFSOSolver.FishSolution);
            AFSO_SolutionRtb.Text = AFSO_SolutionString;

            AFSO_BehaviorString = AFSOGetAllStringBehavior(AFSOSolver.FishNextMove);
            AFSO_BehaviorRtb.Text = AFSO_BehaviorString;
            //計算此群粒子的解，並以中文組成

        }

        /// <summary>
        /// 進行即時更新
        /// </summary>
        void AFSO_UpdateInRealTimeInterface()
        {
            AFSO_BestSolutionRichBox.Refresh();
            AFSO_BestObjectiveTextBox.Refresh();
            ResultChart.Update();
            theProblem.DisplaySolutionsOnGraphics(AFSOSolver.FishSolution);
            AFSO_SolutionRtb.Refresh();
            AFSO_BehaviorRtb.Refresh();
            //進行即時更新
        }

        /// <summary>
        /// 取得所有魚群的行為文字串
        /// </summary>
        String AFSOGetAllStringBehavior(int[] Behavior)
        {
            String StringBehavior = " Fish ID\t" + "Behavior" + "\t" + "\n";
            //處理表頭的部分

            for (int i = 0; i < AFSOSolver.NumberOfFishs; i++)
            {
                StringBehavior += "Fish" + getFlowNumber(i + 1);

                switch (Behavior[i])
                {
                    case 0:
                        StringBehavior += "簇擁\n";
                        break;

                    case 1:
                        StringBehavior += "追隨\n";
                        break;

                    case 2:
                        StringBehavior += "捕食\n";
                        break;

                    case 3:
                        StringBehavior += "隨機移動\n";
                        break;
                }
            }
            return StringBehavior;
        }

        /// <summary>
        /// 取得所有魚群解的文字串
        /// </summary>
        String AFSOGetAllStringSolution(double[][] SolutionArray)
        {
            String StringVariable = " Particle ID\t";
            for (int VarNumber = 0; VarNumber < theProblem.Dimension; VarNumber++)
            {
                StringVariable += "Var" + (VarNumber + 1) + "\t";
            }
            StringVariable += "\n";
            //處理表頭的部分

            for (int i = 0; i < AFSOSolver.NumberOfFishs; i++)
            {
                StringVariable += "Fish" + getFlowNumber(i + 1);

                for (int j = 0; j < theProblem.Dimension; j++)
                {
                    //Math.Round((SolutionArray[i][j]), 2)指的是四捨五入到小數點第五位
                    if (j != theProblem.Dimension - 1)
                        StringVariable += Convert.ToString(Math.Round((SolutionArray[i][j]), 4)) + "\t";
                    else
                        StringVariable += Convert.ToString(Math.Round((SolutionArray[i][j]), 4));
                }
                StringVariable += "\n";
            }
            return StringVariable;
        }

        /// <summary>
        /// 取得最佳魚隻之解的文字串
        /// </summary>
        String AFSOGetStringSolution(double[] SolutionArray)
        {
            String StringVariable = "";
            for (int i = 0; i < theProblem.Dimension; i++)
            {
                if (i != theProblem.Dimension - 1)
                    StringVariable += Convert.ToString(SolutionArray[i]) + " , ";
                else
                    StringVariable += Convert.ToString(SolutionArray[i]);
            }
            return StringVariable;
        }

        /// <summary>
        /// 創造PSO物件
        /// </summary>
        private void btnCreateSolve_Click(object sender, EventArgs e)
        {
            PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, PSO_UpdateParameters.Checked, PSO_ChaoticCheck.Checked, PSO_ChaoticCombobox.SelectedIndex);
            //實作出PSO物件，給入資訊為變數維度數/取得目標值函數的function/各個變數的上下界等

            PropertyGrid.SelectedObject = PSOSolver;

            PSO_Reset.Enabled = true;
        }

        /// <summary>
        /// 點擊重置按鈕
        /// </summary>
        private void Reset_Click(object sender, EventArgs e)
        {
            //將人機界面初始化
            ReNewInterface();

            //初始化PSO物件的資料集
            PSOSolver.Reset();

            // 將目前的particles秀在圖上
            theProblem.DisplaySolutionsOnGraphics(PSOSolver.ParticleSolution);
            PSO_OneIteration.Enabled = PSO_WholeIteration.Enabled = true;
        }

        /// <summary>
        /// 將人機介面資料清空
        /// </summary>
        void ReNewInterface()
        {
            //清除Chart中的資料點
            ResultChart.Series[0].Points.Clear();
            ResultChart.Series[1].Points.Clear();
            ResultChart.Series[2].Points.Clear();

            GA_BestObjectiveTextBox.Clear();
            PSO_BestObjectiveTextBox.Clear();
            AFSO_BestObjectiveTextBox.Clear();
            GA_BestSolutionRichBox.Clear();
            PSO_BestSolutionRichBox.Clear();
            AFSO_BestSolutionRichBox.Clear();

            PSO_SolutionRtb.Clear();
            GA_SolutionRtb.Clear();
            AFSO_SolutionRtb.Clear();
            PSO_VelocityRtb.Clear();
            GA_ChromosomeRtb.Clear();
            AFSO_BehaviorRtb.Clear();


            //GA_Initialize.Enabled = PSO_Reset.Enabled = GA_OneInteration.Enabled = PSO_OneIteration.Enabled = GA_WholeInteration.Enabled = PSO_WholeIteration.Enabled = false;

            //文字方框清空，按鈕重置

        }

        /// <summary>
        /// 進行一代運算
        /// </summary>
        private void PSO_OneIteration_Click(object sender, EventArgs e)
        {
            PSOSolver.RunOneIteration();
            PSO_UpDateData();
            PSO_UpdateInRealTimeInterface();
            theProblem.DisplaySolutionsOnGraphics(PSOSolver.ParticleSolution);

        }

        /// <summary>
        /// 進行PSO整代運算
        /// </summary>
        private void RunToEnd_Click(object sender, EventArgs e)
        {
            while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
            {
                PSOSolver.RunOneIteration();
                PSO_UpDateData();
                if (PSO_UpdateInRealTime.Checked)
                    PSO_UpdateInRealTimeInterface();
                if (PSO_StopByLimitedTimes.Checked)
                {
                    if (PSOSolver.NonImproveCounter == PSOSolver.IterationWithoutImprove)
                    {
                        MessageBox.Show("It has been " + PSOSolver.IterationWithoutImprove + " iteration without improved at iteration " + PSOSolver.IterationCount + " ! ", "Iteration Without Improve was reached");
                        break;
                    }
                }
            }
            PSO_UpdateInRealTimeInterface();
            MessageBox.Show("PSO Execution has been completed!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 對人機介面做更新，包括chart、顯示現行最佳解的listBox和最佳值的Label等
        /// </summary>
        private void PSO_UpDateData()
        {
            PSO_BestSolutionRichBox.Clear();

            PSO_BestSolutionRichBox.Text = GetStringSolution(PSOSolver.SoFarTheBestSolution);

            PSO_BestObjectiveTextBox.Text = PSOSolver.SoFarTheBestObjective.ToString("0.000");
            //若有求得更佳解則進行求解區塊資料更新

            ResultChart.Series[0].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationBestObjective);
            //此代最佳解
            ResultChart.Series[1].Points.AddXY(PSOSolver.IterationCount, PSOSolver.IterationObjectiveAverage);
            //此代解平均值
            ResultChart.Series[2].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjective);
            //至目前為止最佳解(全域最佳解))

            PSO_SolutionString = GetAllStringSolution(PSOSolver.ParticleSolution);
            PSO_SolutionRtb.Text = PSO_SolutionString;

            PSO_VelocityString = GetAllStringVelocity(PSOSolver.Velocity);
            PSO_VelocityRtb.Text = PSO_VelocityString;
            //計算此群粒子的解，並以中文組成

        }

        /// <summary>
        /// 進行即時更新
        /// </summary>
        void PSO_UpdateInRealTimeInterface()
        {
            PSO_BestSolutionRichBox.Refresh();
            PSO_BestObjectiveTextBox.Refresh();
            ResultChart.Update();
            theProblem.DisplaySolutionsOnGraphics(PSOSolver.ParticleSolution);
            PSO_SolutionRtb.Refresh();
            PSO_VelocityRtb.Refresh();
            //進行即時更新
        }

        /// <summary>
        /// 取得最佳解的文字串
        /// </summary>
        String GetStringSolution(double[] SolutionArray)
        {
            String StringVariable = "";
            for (int i = 0; i < theProblem.Dimension; i++)
            {
                if (i != theProblem.Dimension - 1)
                    StringVariable += Convert.ToString(SolutionArray[i]) + " , ";
                else
                    StringVariable += Convert.ToString(SolutionArray[i]);
            }
            return StringVariable;
        }

        int iterationWithoutImprove;
        //連續未改善次數的計數器

        /// <summary>
        /// 取得所有解的文字串
        /// </summary>
        String GetAllStringSolution(double[][] SolutionArray)
        {
            String StringVariable = " Particle ID\t";
            for (int VarNumber = 0; VarNumber < theProblem.Dimension; VarNumber++)
            {
                StringVariable += "Var" + (VarNumber + 1) + "\t";
            }
            StringVariable += "\n";
            //處理表頭的部分


            for (int i = 0; i < PSOSolver.NumberOfParticles; i++)
            {
                StringVariable += "Particle" + getFlowNumber(i + 1);

                for (int j = 0; j < theProblem.Dimension; j++)
                {
                    //Math.Round((SolutionArray[i][j]), 2)指的是四捨五入到小數點第五位
                    if (j != theProblem.Dimension - 1)
                        StringVariable += Convert.ToString(Math.Round((SolutionArray[i][j]), 4)) + "\t";
                    else
                        StringVariable += Convert.ToString(Math.Round((SolutionArray[i][j]), 4));
                }
                StringVariable += "\n";

            }
            return StringVariable;
        }

        /// <summary>
        /// 取得所有粒子速度的文字串
        /// </summary>
        String GetAllStringVelocity(double[][] VolecityArray)
        {
            String StringVolecity = " Particle ID\t";
            for (int VarNumber = 0; VarNumber < theProblem.Dimension; VarNumber++)
            {
                StringVolecity += "Vel" + (VarNumber + 1) + "\t";
            }
            StringVolecity += "\n";
            //處理表頭的部分

            for (int i = 0; i < PSOSolver.NumberOfParticles; i++)
            {
                StringVolecity += "Particle" + getFlowNumber(i + 1);

                for (int j = 0; j < theProblem.Dimension; j++)
                {
                    //Math.Round((SolutionArray[i][j]), 2)指的是四捨五入到小數點第五位
                    if (j != theProblem.Dimension - 1)
                        StringVolecity += Convert.ToString(Math.Round((VolecityArray[i][j]), 4)) + "\t";
                    else
                        StringVolecity += Convert.ToString(Math.Round((VolecityArray[i][j]), 4));
                }
                StringVolecity += "\n";

            }
            return StringVolecity;
        }

        /// <summary>
        /// 取得目前流水號的字串
        /// </summary>
        String getFlowNumber(int flow)
        {
            int MaxNumber = 3;
            String OutputFlowString = "No.";
            //最大位數=8碼

            int temp = flow;
            int i = 0;
            while (temp != 0)
            {
                temp /= 10;
                i++;
            }
            //查看目前的流水編碼已經到幾位數了

            for (int j = 1; j <= MaxNumber - i; j++)
            {
                OutputFlowString += "0";
            }

            OutputFlowString += flow + "  ";


            return OutputFlowString;
        }

        /// <summary>
        /// 創造GA 0-1物件
        /// </summary>
        private void GA_Create_Click(object sender, EventArgs e)
        {
            GAObject = new BinaryGeneticAlgorithm(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound);
            //將GA物件實作為二元類型
            GAObject.Mode = EncodingMode.Binary;
            //將其解碼模式設定為二元解碼類型
            PropertyGrid.SelectedObject = GAObject;
            //初始化按鈕開啟
            GA_Reset.Enabled = true;

            GA_OneInteration.Enabled = GA_WholeInteration.Enabled = false;
            ReNewInterface();

        }

        /// <summary>
        /// 取得最佳解的文字串
        /// </summary>
        String GetStringSolution(int[] SolutionArray)
        {
            String StringVariable = "";
            for (int i = 0; i < GAObject.totalLength; i++)
            {
                if (i != GAObject.totalLength - 1)
                    StringVariable += Convert.ToString(SolutionArray[i]) + " , ";
                else
                    StringVariable += Convert.ToString(SolutionArray[i]);
            }
            return StringVariable;
        }

        /// <summary>
        /// GA物件初始化
        /// </summary>
        private void GA_Initialize_Click(object sender, EventArgs e)
        {
            //重新設置物件
            GAObject = new BinaryGeneticAlgorithm(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound);

            iterationWithoutImprove = 0;

            //將人機界面初始化
            ReNewInterface();
            GA_BestSolutionRichBox.Clear();
            GA_BestObjectiveTextBox.Clear();

            //初始化PSO物件的資料集
            GAObject.Initialize();
            //計算目前最佳解等資料
            GAObject.UpdateSolutionAndObjective();

            //更新一次介面
            GA_UpdateInRealTime();

            GA_WholeInteration.Enabled = GA_OneInteration.Enabled = true;

        }

        /// <summary>
        /// 對人機介面所需的資料做更新，包括chart、顯示現行最佳解的listBox和最佳值的Label等
        /// </summary>
        private void GA_UpDateData()
        {
            GA_BestSolutionRichBox.Clear();

            GA_BestSolutionRichBox.Text = GetStringSolution(GAObject.SoFarTheBestSolutionBinary);

            GA_BestObjectiveTextBox.Text = GAObject.SoFarTheBestObjective.ToString("0.000");
            //若有求得更佳解則進行求解區塊資料更新

            ResultChart.Series[0].Points.AddXY(GAObject.CurrentIteration, GAObject.IterationBestObjective);
            //此代最佳解
            ResultChart.Series[1].Points.AddXY(GAObject.CurrentIteration, GAObject.IterationAverage);
            //此代解平均值
            ResultChart.Series[2].Points.AddXY(GAObject.CurrentIteration, GAObject.SoFarTheBestObjective);
            //至目前為止最佳解(全域最佳解))

            String GA_SolutionString = GA_GetAllStringSolution(GAObject.ChromosomeSolution);
            GA_SolutionRtb.Text = GA_SolutionString;

            String GA_ChromosomeString = GA_GetAllStringChromosome(GAObject.BinChromosome);
            GA_ChromosomeRtb.Text = GA_ChromosomeString;
            //PSO_VelocityString = GetAllStringVelocity(PSOSolver.Velocity);
            //PSO_VelocityRtb.Text = PSO_VelocityString;
            //計算此群粒子的解，並以中文組成

        }

        /// <summary>
        /// 取得GA所有解的文字串
        /// </summary>
        String GA_GetAllStringSolution(double[][] SolutionArray)
        {
            String StringVariable = " Chromosome ID\t\t";
            for (int VarNumber = 0; VarNumber < theProblem.Dimension; VarNumber++)
            {
                StringVariable += "Var" + (VarNumber + 1) + "\t";
            }
            StringVariable += "\n";
            //處理表頭的部分


            for (int i = 0; i < GAObject.PopulationSize; i++)
            {
                StringVariable += "Chromosome" + getFlowNumber(i + 1) + "\t";

                for (int j = 0; j < theProblem.Dimension; j++)
                {
                    //Math.Round((SolutionArray[i][j]), 2)指的是四捨五入到小數點第五位
                    if (j != theProblem.Dimension - 1)
                        StringVariable += Convert.ToString(Math.Round((SolutionArray[i][j]), 4)) + "\t";
                    else
                        StringVariable += Convert.ToString(Math.Round((SolutionArray[i][j]), 4));
                }
                StringVariable += "\n";

            }
            return StringVariable;
        }

        /// <summary>
        /// 取得所有GA 染色體編碼的文字串
        /// </summary>
        String GA_GetAllStringChromosome(int[][] ChromosomeArray)
        {
            String StringChromosome = " Chromosome ID\t\t" + "Chromosome Code" + "\n";
            //處理表頭的部分

            for (int i = 0; i < GAObject.PopulationSize; i++)
            {
                StringChromosome += "Chromosome" + getFlowNumber(i + 1);

                for (int j = 0; j < GAObject.totalLength; j++)
                {
                    StringChromosome += Convert.ToString(ChromosomeArray[i][j]);
                }
                StringChromosome += "\n";

            }
            return StringChromosome;
        }

        /// <summary>
        /// 更新介面要做的資料控制
        /// </summary>
        void GA_UpdateInRealTime()
        {
            GA_BestSolutionRichBox.Refresh();
            GA_BestObjectiveTextBox.Refresh();
            ResultChart.Update();
            theProblem.DisplaySolutionsOnGraphics(GAObject.ChromosomeSolution);
            GA_SolutionRtb.Refresh();
            GA_ChromosomeRtb.Refresh();
            //進行即時更新
        }

        /// <summary>
        /// 進行GA一代的運算
        /// </summary>
        private void GA_OneInteration_Click(object sender, EventArgs e)
        {
            GAObject.CrossOver();
            GAObject.Mutate();
            GAObject.CurrentIteration++;
            GAObject.Eliminate();
            //一次循環，包括交配、突變與淘汰

            GA_UpDateData();
            GA_UpdateInRealTime();
            //更新資料
        }

        /// <summary>
        /// 進行GA全域求解
        /// </summary>
        private void GA_WholeInteration_Click_1(object sender, EventArgs e)
        {
            while (GAObject.CurrentIteration < GAObject.MaxIteration)
            {
                GAObject.RunOneIteration();
                GA_UpDateData();
                //若有要進行即時更新的話則根據不同Mode來判斷要更新哪些界面資料
                //若要Real-Time更新人機介面資訊則執行以下指令
                if (GA_RealTimeUpdate.Checked)
                    GA_UpdateInRealTime();
                //限制未改善代數
                if (GA_StopByLimitedTimes.Checked)
                {
                    if (GAObject.NonImproveCounter == GAObject.IterationWithoutImprove)
                    {
                        MessageBox.Show("It has been " + GAObject.IterationWithoutImprove + " iteration without improved at iteration " + GAObject.CurrentIteration + " ! ", "Iteration Without Improve was reached");
                        break;
                    }
                }
            }
            GA_UpdateInRealTime();
            MessageBox.Show("GA Execution has been completed!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// PSO物件部分，若選取混沌優化則不能採用Interia Factor更新策略，因為在混沌優化的前提下已無此項參數
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void PSO_ChaoticCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PSO_ChaoticCheck.Checked == true)
            {
                PSO_ChaoticCombobox.Enabled = true;
                PSO_UpdateParameters.Checked = false;
            }
            else
            {
                PSO_ChaoticCombobox.Enabled = false;
            }
        }

        private void PSO_UpdateParameters_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void PSO_UpdateParameters_CheckedChanged(object sender, EventArgs e)
        {
            if (PSO_UpdateParameters.Checked == true)
            {
                PSO_ChaoticCheck.Checked = false;
            }
        }

        /// <summary>
        /// 魚群算法部分，控制track bar與顯示的數字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void AFSO_PSOEnd_Box_ValueChanged(object sender, EventArgs e)
        {
            AFSO_PSOEnd_Value.Text = "" + Convert.ToDouble(AFSO_PSOEnd_Bar.Value) / 100;
        }

        private void AFSO_PSOEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (AFSO_PSOEnd.Checked == true)
                AFSO_PSOEnd_Bar.Enabled = true;
            else
                AFSO_PSOEnd_Bar.Enabled = false;
        }


        /// <summary>
        /// 在顯示比較圖表的部分，點擊不同的check box就馬上新增於圖表上等待實作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TPSOCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (TPSOCheck.Checked == true)
            {
                CompareChart.Series.Add("TPSO");

                CompareChartIndex[0] = CompareChart.Series.IndexOf("TPSO");

                CompareChart.Series[CompareChartIndex[0]].ChartType = ResultChart.Series[0].ChartType;
                CompareChart.Series[CompareChartIndex[0]].BorderWidth = 2;
                CompareChart.Series[CompareChartIndex[0]].Color = Color.Blue;
            }
            else
            {
                CompareChart.Series.Remove(CompareChart.Series[CompareChartIndex[0]]);

                //若順序為在此之後則要前進一位
                for (int i = 0; i < 10; i++)
                {
                    if (CompareChartIndex[i] > CompareChartIndex[0])
                        CompareChartIndex[i]--;
                }
                //刪除此條線條

                CompareChartIndex[0] = -1;
            }
        }

        private void IPSOCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (IPSOCheck.Checked == true)
            {
                CompareChart.Series.Add("IPSO");

                CompareChartIndex[1] = CompareChart.Series.IndexOf("IPSO");

                CompareChart.Series[CompareChartIndex[1]].ChartType = ResultChart.Series[0].ChartType;
                CompareChart.Series[CompareChartIndex[1]].BorderWidth = 2;
                CompareChart.Series[CompareChartIndex[1]].Color = Color.Green;
            }
            else
            {
                CompareChart.Series.Remove(CompareChart.Series[CompareChartIndex[1]]);
                //若順序為在此之後則要前進一位
                for (int i = 0; i < 10; i++)
                {
                    if (CompareChartIndex[i] > CompareChartIndex[1])
                        CompareChartIndex[i]--;
                }
                //刪除此條線條
                CompareChartIndex[1] = -1;
            }
        }

        private void CPSO_LogisticCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CPSO_LogisticCheck.Checked == true)
            {
                CompareChart.Series.Add("CPSO_Logistic");

                CompareChartIndex[2] = CompareChart.Series.IndexOf("CPSO_Logistic");

                CompareChart.Series[CompareChartIndex[2]].ChartType = ResultChart.Series[0].ChartType;
                CompareChart.Series[CompareChartIndex[2]].BorderWidth = 2;
                CompareChart.Series[CompareChartIndex[2]].Color = Color.Red;
            }
            else
            {
                CompareChart.Series.Remove(CompareChart.Series[CompareChartIndex[2]]);
                //若順序為在此之後則要前進一位
                for (int i = 0; i < 10; i++)
                {
                    if (CompareChartIndex[i] > CompareChartIndex[2])
                        CompareChartIndex[i]--;
                }
                //刪除此條線條
                CompareChartIndex[2] = -1;
            }
        }

        private void CPSO_TentCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CPSO_TentCheck.Checked == true)
            {
                CompareChart.Series.Add("CPSO_Tent");

                CompareChartIndex[3] = CompareChart.Series.IndexOf("CPSO_Tent");

                CompareChart.Series[CompareChartIndex[3]].ChartType = ResultChart.Series[0].ChartType;
                CompareChart.Series[CompareChartIndex[3]].BorderWidth = 2;
                CompareChart.Series[CompareChartIndex[3]].Color = Color.Coral;
            }
            else
            {
                CompareChart.Series.Remove(CompareChart.Series[CompareChartIndex[3]]);
                //若順序為在此之後則要前進一位
                for (int i = 0; i < 10; i++)
                {
                    if (CompareChartIndex[i] > CompareChartIndex[3])
                        CompareChartIndex[i]--;
                }
                //刪除此條線條
                CompareChartIndex[3] = -1;
            }
        }

        private void CPSO_SinusoidalCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CPSO_SinusoidalCheck.Checked == true)
            {
                CompareChart.Series.Add("CPSO_Sinusoidal");

                CompareChartIndex[4] = CompareChart.Series.IndexOf("CPSO_Sinusoidal");

                CompareChart.Series[CompareChartIndex[4]].ChartType = ResultChart.Series[0].ChartType;
                CompareChart.Series[CompareChartIndex[4]].BorderWidth = 2;
                CompareChart.Series[CompareChartIndex[4]].Color = Color.DarkGray;
            }
            else
            {
                CompareChart.Series.Remove(CompareChart.Series[CompareChartIndex[4]]);
                //若順序為在此之後則要前進一位
                for (int i = 0; i < 10; i++)
                {
                    if (CompareChartIndex[i] > CompareChartIndex[4])
                        CompareChartIndex[i]--;
                }
                //刪除此條線條
                CompareChartIndex[4] = -1;
            }
        }

        private void CPSO_GaussCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CPSO_GaussCheck.Checked == true)
            {
                //新增一條線條
                CompareChart.Series.Add("CPSO_Gauss");
                //紀錄此線條位置
                CompareChartIndex[5] = CompareChart.Series.IndexOf("CPSO_Gauss");

                CompareChart.Series[CompareChartIndex[5]].ChartType = ResultChart.Series[0].ChartType;
                CompareChart.Series[CompareChartIndex[5]].BorderWidth = 2;
                CompareChart.Series[CompareChartIndex[5]].Color = Color.Goldenrod;
            }
            else
            {
                CompareChart.Series.Remove(CompareChart.Series[CompareChartIndex[5]]);

                //若順序為在此之後則要前進一位
                for (int i = 0; i < 10; i++)
                {
                    if (CompareChartIndex[i] > CompareChartIndex[5])
                        CompareChartIndex[i]--;
                }
                //刪除此條線條
                CompareChartIndex[5] = -1;
            }
        }

        private void CPSO_CircleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CPSO_CircleCheck.Checked == true)
            {
                CompareChart.Series.Add("CPSO_Circle");

                CompareChartIndex[6] = CompareChart.Series.IndexOf("CPSO_Circle");

                CompareChart.Series[CompareChartIndex[6]].ChartType = ResultChart.Series[0].ChartType;
                CompareChart.Series[CompareChartIndex[6]].BorderWidth = 2;
                CompareChart.Series[CompareChartIndex[6]].Color = Color.Fuchsia;
            }
            else
            {
                CompareChart.Series.Remove(CompareChart.Series[CompareChartIndex[6]]);
                //若順序為在此之後則要前進一位
                for (int i = 0; i < 10; i++)
                {
                    if (CompareChartIndex[i] > CompareChartIndex[6])
                        CompareChartIndex[i]--;
                }
                //刪除此條線條
                CompareChartIndex[6] = -1;
            }
        }

        private void GA_BinaryCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (GA_BinaryCheck.Checked == true)
            {
                CompareChart.Series.Add("GA_Binary");

                CompareChartIndex[7] = CompareChart.Series.IndexOf("GA_Binary");

                CompareChart.Series[CompareChartIndex[7]].ChartType = ResultChart.Series[0].ChartType;
                CompareChart.Series[CompareChartIndex[7]].BorderWidth = 2;
                CompareChart.Series[CompareChartIndex[7]].Color = Color.Black;

            }
            else
            {
                CompareChart.Series.Remove(CompareChart.Series[CompareChartIndex[7]]);
                //若順序為在此之後則要前進一位
                for (int i = 0; i < 10; i++)
                {
                    if (CompareChartIndex[i] > CompareChartIndex[7])
                        CompareChartIndex[i]--;
                }
                //刪除此條線條
                CompareChartIndex[7] = -1;
            }
        }

        private void AFSO_Check_CheckedChanged_1(object sender, EventArgs e)
        {
            if (AFSO_Check.Checked == true)
            {
                CompareChart.Series.Add("AFSO");

                CompareChartIndex[8] = CompareChart.Series.IndexOf("AFSO");

                CompareChart.Series[CompareChartIndex[8]].ChartType = ResultChart.Series[0].ChartType;
                CompareChart.Series[CompareChartIndex[8]].BorderWidth = 2;
                CompareChart.Series[CompareChartIndex[8]].Color = Color.Purple;

            }
            else
            {
                CompareChart.Series.Remove(CompareChart.Series[CompareChartIndex[8]]);
                //若順序為在此之後則要前進一位
                for (int i = 0; i < 10; i++)
                {
                    if (CompareChartIndex[i] > CompareChartIndex[8])
                        CompareChartIndex[i]--;
                }
                //刪除此條線條
                CompareChartIndex[8] = -1;
            }
        }

        private void CPSO_DoubleButtonCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CPSO_DoubleButtonCheck.Checked == true)
            {
                CompareChart.Series.Add("CPSO-DoubleButton");

                CompareChartIndex[9] = CompareChart.Series.IndexOf("CPSO-DoubleButton");

                CompareChart.Series[CompareChartIndex[9]].ChartType = ResultChart.Series[0].ChartType;
                CompareChart.Series[CompareChartIndex[9]].BorderWidth = 2;
                CompareChart.Series[CompareChartIndex[9]].Color = Color.Aquamarine;
            }
            else
            {
                CompareChart.Series.Remove(CompareChart.Series[CompareChartIndex[9]]);
                //若順序為在此之後則要前進一位
                for (int i = 0; i < 10; i++)
                {
                    if (CompareChartIndex[i] > CompareChartIndex[9])
                        CompareChartIndex[i]--;
                }
                //刪除此條線條
                CompareChartIndex[9] = -1;
            }
        }


        /// <summary>
        /// 將勾選的演算法執行一次，以圖表方式呈現比較效果
        /// </summary>
        private void AllSolve(object sender, EventArgs e)
        {
            //呼叫函式進行處理，以保持程式可讀性
            SelectedRunOnce();
        }

        double[][] AllAlgorithmSolution;
        /// <summary>
        /// 每個演算法皆進行三十次運算，每次迭代500代，計算三十次
        /// </summary>
        private void AllFor30Times_Click(object sender, EventArgs e)
        {
            AllResultRtbox.Text = "";
            //將陣列初始化，內含八種演算法，每種算法做三十次運算並紀錄起來
            AllAlgorithmSolution = new double[10][];
            for (int i = 0; i < 10; i++)
            {
                AllAlgorithmSolution[i] = new double[30];
            }

            //進行每種算法做三十次運算
            CaculateEachAlgorithm();

            //顯示解於視窗中
            AllResultRtbox.Text = GetAllResultInString(AllAlgorithmSolution);
            MessageBox.Show("Execution of Each Algorithm for 30 times  has been completed!", "Credit Get", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// 將勾選的演算法執行一次的函式
        /// </summary>
        void SelectedRunOnce()
        {
            if (TPSOCheck.Checked == true)
            {
                //實作出PSO物件，給入資訊為變數維度數/取得目標值函數的function/各個變數的上下界等
                PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, false, 0);

                //初始化PSO物件的資料集
                PSOSolver.Reset();

                //清除Chart中的資料點
                CompareChart.Series[CompareChartIndex[0]].Points.Clear();

                while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                {
                    PSOSolver.RunOneIteration();

                    //至目前為止最佳解(全域最佳解))
                    CompareChart.Series[CompareChartIndex[0]].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjective);
                }

                //清出記憶體
                PSOSolver = null;

                CompareChart.Update();
            }

            if (IPSOCheck.Checked == true)
            {
                //
                //實作出PSO物件，內容為考慮改善Interia Factor的改良版本
                PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, true, false, 0);

                //初始化PSO物件的資料集
                PSOSolver.Reset();

                //清除Chart中的資料點
                CompareChart.Series[CompareChartIndex[1]].Points.Clear();

                while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                {
                    PSOSolver.RunOneIteration();

                    //至目前為止最佳解(全域最佳解))
                    CompareChart.Series[CompareChartIndex[1]].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjective);
                }

                //清出記憶體
                PSOSolver = null;

                CompareChart.Update();
            }

            if (CPSO_LogisticCheck.Checked == true)
            {
                //實作出CPSO物件，為Logistic Mapping版本
                PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 0);

                //初始化CPSO物件的資料集
                PSOSolver.Reset();

                //清除Chart中的資料點
                CompareChart.Series[CompareChartIndex[2]].Points.Clear();

                while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                {
                    PSOSolver.RunOneIteration();

                    //至目前為止最佳解(全域最佳解))
                    CompareChart.Series[CompareChartIndex[2]].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjective);
                }

                //清出記憶體
                PSOSolver = null;

                CompareChart.Update();
            }

            if (CPSO_TentCheck.Checked == true)
            {
                //實作出CPSO物件，為Tent Mapping版本
                PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 1);

                //初始化CPSO物件的資料集
                PSOSolver.Reset();

                //清除Chart中的資料點
                CompareChart.Series[CompareChartIndex[3]].Points.Clear();

                while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                {
                    PSOSolver.RunOneIteration();

                    //至目前為止最佳解(全域最佳解))
                    CompareChart.Series[CompareChartIndex[3]].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjective);
                }

                //清出記憶體
                PSOSolver = null;

                CompareChart.Update();
            }

            if (CPSO_SinusoidalCheck.Checked == true)
            {
                //實作出CPSO物件，為Sinusoidal Mapping版本
                PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 2);

                //初始化CPSO物件的資料集
                PSOSolver.Reset();

                //清除Chart中的資料點
                CompareChart.Series[CompareChartIndex[4]].Points.Clear();

                while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                {
                    PSOSolver.RunOneIteration();

                    //至目前為止最佳解(全域最佳解))
                    CompareChart.Series[CompareChartIndex[4]].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjective);
                }

                //清出記憶體
                PSOSolver = null;

                CompareChart.Update();
            }

            if (CPSO_GaussCheck.Checked == true)
            {
                //實作出CPSO物件，為Gauss Mapping版本
                PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 3);

                //初始化CPSO物件的資料集
                PSOSolver.Reset();

                //清除Chart中的資料點
                CompareChart.Series[CompareChartIndex[5]].Points.Clear();

                while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                {
                    PSOSolver.RunOneIteration();

                    //至目前為止最佳解(全域最佳解))
                    CompareChart.Series[CompareChartIndex[5]].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjective);
                }

                //清出記憶體
                PSOSolver = null;

                CompareChart.Update();
            }

            if (CPSO_CircleCheck.Checked == true)
            {
                //實作出CPSO物件，為Circle Mapping版本
                PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 4);

                //初始化CPSO物件的資料集
                PSOSolver.Reset();

                //清除Chart中的資料點
                CompareChart.Series[CompareChartIndex[6]].Points.Clear();

                while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                {
                    PSOSolver.RunOneIteration();

                    //至目前為止最佳解(全域最佳解))
                    CompareChart.Series[CompareChartIndex[6]].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjective);
                }

                //清出記憶體
                PSOSolver = null;

                CompareChart.Update();
            }

            if (GA_BinaryCheck.Checked == true)
            {
                //將GA物件實作為二元類型
                GAObject = new BinaryGeneticAlgorithm(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound);

                //將其解碼模式設定為二元解碼類型
                GAObject.Mode = EncodingMode.Binary;

                //重新設置物件
                GAObject = new BinaryGeneticAlgorithm(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound);

                //初始化PSO物件的資料集
                GAObject.Initialize();

                //計算目前最佳解等資料
                GAObject.UpdateSolutionAndObjective();

                //清除Chart中的資料點
                CompareChart.Series[CompareChartIndex[7]].Points.Clear();

                while (GAObject.CurrentIteration < GAObject.MaxIteration)
                {
                    GAObject.RunOneIteration();
                    //至目前為止最佳解(全域最佳解))
                    CompareChart.Series[CompareChartIndex[7]].Points.AddXY(GAObject.CurrentIteration, GAObject.SoFarTheBestObjective);
                }

                //清出記憶體
                GAObject = null;

                CompareChart.Update();
            }

            if (AFSO_Check.Checked == true)
            {
                //實作出PSO物件，給入資訊為變數維度數/取得目標值函數的function/各個變數的上下界等，內訂最後40%交由粒子群收斂
                AFSOSolver = new AFSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, true, true, 0.4);

                //初始化AFSO物件的資料集
                AFSOSolver.Reset();

                //清除Chart中的資料點
                CompareChart.Series[CompareChartIndex[8]].Points.Clear();

                while (AFSOSolver.IterationCount < AFSOSolver.IterationLimitTimes)
                {
                    AFSOSolver.RunOneIteration();
                    CompareChart.Series[CompareChartIndex[8]].Points.AddXY(AFSOSolver.IterationCount, AFSOSolver.SoFarTheBestObjective);
                }

                //清出記憶體
                AFSOSolver = null;

                CompareChart.Update();
            }

            if (CPSO_DoubleButtonCheck.Checked == true)
            {
                //實作出CPSO物件，為Circle Mapping版本
                PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 5);

                //初始化CPSO物件的資料集
                PSOSolver.Reset();

                //清除Chart中的資料點
                CompareChart.Series[CompareChartIndex[9]].Points.Clear();

                while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                {
                    PSOSolver.RunOneIteration();

                    //至目前為止最佳解(全域最佳解))
                    CompareChart.Series[CompareChartIndex[9]].Points.AddXY(PSOSolver.IterationCount, PSOSolver.SoFarTheBestObjective);
                }

                //清出記憶體
                PSOSolver = null;

                CompareChart.Update();
            }
        }

        /// <summary>
        /// 實際執行計算每個演算法，各進行三十次運算
        /// </summary>
        void CaculateEachAlgorithm()
        {
            // Type自0-8分別做不同算法之計算
            int AlgorithmType = 0;

            /// <summary>
            /// Type自0-8分別做不同算法之計算
            /// </summary>
            do
            {
                //各演算法逐項進行
                switch (AlgorithmType)
                {
                    case 0:
                        for (int i = 0; i < 30; i++)
                        {
                            //實作出PSO物件，給入資訊為變數維度數/取得目標值函數的function/各個變數的上下界等
                            PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, false, 0);
                            PSOSolver.Reset();
                            while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                            {
                                PSOSolver.RunOneIteration();
                            }
                            AllAlgorithmSolution[AlgorithmType][i] = PSOSolver.SoFarTheBestObjective;
                            //清出記憶體
                            PSOSolver = null;
                        }
                        break;

                    case 1:
                        for (int i = 0; i < 30; i++)
                        {
                            //實作出PSO物件，內容為考慮改善Interia Factor的改良版本
                            PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, true, false, 0);
                            PSOSolver.Reset();
                            while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                            {
                                PSOSolver.RunOneIteration();
                            }
                            AllAlgorithmSolution[AlgorithmType][i] = PSOSolver.SoFarTheBestObjective;
                            //清出記憶體
                            PSOSolver = null;
                        }
                        break;

                    case 2:
                        for (int i = 0; i < 30; i++)
                        {
                            //實作出CPSO物件，為Logistic Mapping版本
                            PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 0);
                            PSOSolver.Reset();
                            while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                            {
                                PSOSolver.RunOneIteration();
                            }
                            AllAlgorithmSolution[AlgorithmType][i] = PSOSolver.SoFarTheBestObjective;
                            //清出記憶體
                            PSOSolver = null;
                        }
                        break;

                    case 3:
                        for (int i = 0; i < 30; i++)
                        {
                            //實作出CPSO物件，為Tent Mapping版本
                            PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 1);
                            PSOSolver.Reset();
                            while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                            {
                                PSOSolver.RunOneIteration();
                            }
                            AllAlgorithmSolution[AlgorithmType][i] = PSOSolver.SoFarTheBestObjective;
                            //清出記憶體
                            PSOSolver = null;
                        }
                        break;

                    case 4:
                        for (int i = 0; i < 30; i++)
                        {
                            //實作出CPSO物件，為Sinusoidal Mapping版本
                            PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 2);
                            PSOSolver.Reset();
                            while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                            {
                                PSOSolver.RunOneIteration();
                            }
                            AllAlgorithmSolution[AlgorithmType][i] = PSOSolver.SoFarTheBestObjective;
                            //清出記憶體
                            PSOSolver = null;
                        }
                        break;

                    case 5:
                        for (int i = 0; i < 30; i++)
                        {
                            //實作出CPSO物件，為Gauss Mapping版本
                            PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 3);
                            PSOSolver.Reset();
                            while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                            {
                                PSOSolver.RunOneIteration();
                            }
                            AllAlgorithmSolution[AlgorithmType][i] = PSOSolver.SoFarTheBestObjective;
                            //清出記憶體
                            PSOSolver = null;
                        }
                        break;

                    case 6:
                        for (int i = 0; i < 30; i++)
                        {
                            //實作出CPSO物件，為Circle Mapping版本
                            PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 4);
                            PSOSolver.Reset();
                            while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                            {
                                PSOSolver.RunOneIteration();
                            }
                            AllAlgorithmSolution[AlgorithmType][i] = PSOSolver.SoFarTheBestObjective;
                            //清出記憶體
                            PSOSolver = null;
                        }
                        break;

                    case 7:
                        for (int i = 0; i < 30; i++)
                        {
                            //將GA物件實作為二元類型
                            GAObject = new BinaryGeneticAlgorithm(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound);

                            //將其解碼模式設定為二元解碼類型
                            GAObject.Mode = EncodingMode.Binary;

                            //重新設置物件
                            GAObject = new BinaryGeneticAlgorithm(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound);

                            //初始化PSO物件的資料集
                            GAObject.Initialize();

                            //計算目前最佳解等資料
                            GAObject.UpdateSolutionAndObjective();

                            while (GAObject.CurrentIteration < GAObject.MaxIteration)
                            {
                                GAObject.RunOneIteration();
                            }

                            AllAlgorithmSolution[AlgorithmType][i] = GAObject.SoFarTheBestObjective;

                            //清出記憶體
                            GAObject = null;
                        }
                        break;

                    case 8:
                        for (int i = 0; i < 30; i++)
                        {
                            //實作出PSO物件，給入資訊為變數維度數/取得目標值函數的function/各個變數的上下界等，內訂最後40%交由粒子群收斂
                            AFSOSolver = new AFSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, true, true, 0.4);

                            //初始化AFSO物件的資料集
                            AFSOSolver.Reset();

                            while (AFSOSolver.IterationCount < AFSOSolver.IterationLimitTimes)
                            {
                                AFSOSolver.RunOneIteration();
                            }
                            AllAlgorithmSolution[AlgorithmType][i] = AFSOSolver.SoFarTheBestObjective;
                            //清出記憶體
                            AFSOSolver = null;
                        }
                        break;

                    case 9:
                        for (int i = 0; i < 30; i++)
                        {
                            //實作出CPSO物件，為Circle Mapping版本
                            PSOSolver = new PSOSolver(theProblem.Dimension, theProblem.GetObjectiveValue, theProblem.LowerBound, theProblem.UpperBound, false, true, 5);
                            PSOSolver.Reset();
                            while (PSOSolver.IterationCount < PSOSolver.IterationLimitTimes)
                            {
                                PSOSolver.RunOneIteration();
                            }
                            AllAlgorithmSolution[AlgorithmType][i] = PSOSolver.SoFarTheBestObjective;
                            //清出記憶體
                            PSOSolver = null;
                        }
                        break;

                }
                AlgorithmType++;
            }
            while (AlgorithmType < 10);
        }

        /// <summary>
        /// 將三十次的演算結果紀錄起來並轉成文字
        /// </summary>
        /// <param name="ThirtyTimesValue"></param>
        /// <returns></returns>
        string GetAllResultInString(double[][] ThirtyTimesValue)
        {
            string Result = "";
            for (int i = 0; i < 10; i++)
            {
                Result += "Algorithm" + i + "\n";
                for (int j = 0; j < 30; j++)
                {
                    Result += "Iteration" + j + "\t" + AllAlgorithmSolution[i][j] + "\n";
                }
            }
            return Result;
        }




    }
}
