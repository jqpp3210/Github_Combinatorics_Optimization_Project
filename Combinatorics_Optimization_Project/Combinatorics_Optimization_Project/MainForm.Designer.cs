namespace Combinatorics_Optimization_Project
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.ChartTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ResultChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CompareChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SolutionTab = new System.Windows.Forms.TabPage();
            this.PSO_SolutionTab = new System.Windows.Forms.TabPage();
            this.PSO_VelocityLabel = new System.Windows.Forms.Label();
            this.PSO_SolutionLabel = new System.Windows.Forms.Label();
            this.PSO_VelocityRtb = new System.Windows.Forms.RichTextBox();
            this.PSO_SolutionRtb = new System.Windows.Forms.RichTextBox();
            this.GA_SolutionTab = new System.Windows.Forms.TabPage();
            this.GA_ChromosomeRtbLabel = new System.Windows.Forms.Label();
            this.GA_RTBLabel = new System.Windows.Forms.Label();
            this.GA_ChromosomeRtb = new System.Windows.Forms.RichTextBox();
            this.GA_SolutionRtb = new System.Windows.Forms.RichTextBox();
            this.AFSO_SolutionTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.AFSO_BehaviorRtb = new System.Windows.Forms.RichTextBox();
            this.AFSO_RTBLabel = new System.Windows.Forms.Label();
            this.AFSO_SolutionRtb = new System.Windows.Forms.RichTextBox();
            this.All_Result_Tab = new System.Windows.Forms.TabPage();
            this.AllResultRtbox = new System.Windows.Forms.RichTextBox();
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.COPTab = new System.Windows.Forms.TabControl();
            this.PSO_COPTab = new System.Windows.Forms.TabPage();
            this.PSO_ChaoticCombobox = new System.Windows.Forms.ComboBox();
            this.PSO_ChaoticCheck = new System.Windows.Forms.CheckBox();
            this.PSO_UpdateParameters = new System.Windows.Forms.CheckBox();
            this.PSO_OneIteration = new System.Windows.Forms.Button();
            this.PSO_StopByLimitedTimes = new System.Windows.Forms.CheckBox();
            this.PSO_WholeIteration = new System.Windows.Forms.Button();
            this.PSO_BestSolutionRichBox = new System.Windows.Forms.RichTextBox();
            this.PSO_Reset = new System.Windows.Forms.Button();
            this.PSO_Create = new System.Windows.Forms.Button();
            this.PSO_UpdateInRealTime = new System.Windows.Forms.CheckBox();
            this.ACO_BestSolution = new System.Windows.Forms.Label();
            this.PSOBestObjectiveLabel = new System.Windows.Forms.Label();
            this.PSO_BestObjectiveTextBox = new System.Windows.Forms.TextBox();
            this.GA_Tab = new System.Windows.Forms.TabPage();
            this.GA_BestSolutionRichBox = new System.Windows.Forms.RichTextBox();
            this.GA_StopByLimitedTimes = new System.Windows.Forms.CheckBox();
            this.GA_RealTimeUpdate = new System.Windows.Forms.CheckBox();
            this.GA_WholeInteration = new System.Windows.Forms.Button();
            this.PermutationBestSolutionLabel = new System.Windows.Forms.Label();
            this.GA_Reset = new System.Windows.Forms.Button();
            this.GA_OneInteration = new System.Windows.Forms.Button();
            this.GABestObjectiveLabel = new System.Windows.Forms.Label();
            this.GA_Create = new System.Windows.Forms.Button();
            this.GA_BestObjectiveTextBox = new System.Windows.Forms.TextBox();
            this.AFSO_Tab = new System.Windows.Forms.TabPage();
            this.AFSO_PSOEnd_Value = new System.Windows.Forms.Label();
            this.AFSO_PSOEnd_Bar = new System.Windows.Forms.TrackBar();
            this.AFSO_PSOEnd = new System.Windows.Forms.CheckBox();
            this.AFSO_Update_Parameters = new System.Windows.Forms.CheckBox();
            this.AFSO_OneIteration = new System.Windows.Forms.Button();
            this.AFSO_StopByLimitedTimes = new System.Windows.Forms.CheckBox();
            this.AFSO_WholeIteration = new System.Windows.Forms.Button();
            this.AFSO_BestSolutionRichBox = new System.Windows.Forms.RichTextBox();
            this.AFSO_Reset = new System.Windows.Forms.Button();
            this.AFSO_Create = new System.Windows.Forms.Button();
            this.AFSO_UpdateInRealTime = new System.Windows.Forms.CheckBox();
            this.AFSO_BestSolution = new System.Windows.Forms.Label();
            this.AFSOBestObjectiveLabel = new System.Windows.Forms.Label();
            this.AFSO_BestObjectiveTextBox = new System.Windows.Forms.TextBox();
            this.AllRunTab = new System.Windows.Forms.TabPage();
            this.CPSO_DoubleButtonCheck = new System.Windows.Forms.CheckBox();
            this.AllFor30Times = new System.Windows.Forms.Button();
            this.AllSolveButton = new System.Windows.Forms.Button();
            this.AFSO_Check = new System.Windows.Forms.CheckBox();
            this.GA_BinaryCheck = new System.Windows.Forms.CheckBox();
            this.CPSO_CircleCheck = new System.Windows.Forms.CheckBox();
            this.CPSO_GaussCheck = new System.Windows.Forms.CheckBox();
            this.CPSO_SinusoidalCheck = new System.Windows.Forms.CheckBox();
            this.CPSO_TentCheck = new System.Windows.Forms.CheckBox();
            this.CPSO_LogisticCheck = new System.Windows.Forms.CheckBox();
            this.IPSOCheck = new System.Windows.Forms.CheckBox();
            this.TPSOCheck = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.ChartTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultChart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompareChart)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.PSO_SolutionTab.SuspendLayout();
            this.GA_SolutionTab.SuspendLayout();
            this.AFSO_SolutionTab.SuspendLayout();
            this.All_Result_Tab.SuspendLayout();
            this.COPTab.SuspendLayout();
            this.PSO_COPTab.SuspendLayout();
            this.GA_Tab.SuspendLayout();
            this.AFSO_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AFSO_PSOEnd_Bar)).BeginInit();
            this.AllRunTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1051, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1051, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbOpen
            // 
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(136, 22);
            this.tsbOpen.Text = "Open A Benchmark";
            this.tsbOpen.Click += new System.EventHandler(this.LoadCOPFile_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 516);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1051, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 49);
            this.spcMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.splitContainer2);
            this.spcMain.Size = new System.Drawing.Size(1051, 467);
            this.spcMain.SplitterDistance = 98;
            this.spcMain.SplitterWidth = 5;
            this.spcMain.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.PropertyGrid);
            this.splitContainer2.Panel2.Controls.Add(this.COPTab);
            this.splitContainer2.Size = new System.Drawing.Size(948, 467);
            this.splitContainer2.SplitterDistance = 597;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.ChartTab);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer3.Size = new System.Drawing.Size(597, 467);
            this.splitContainer3.SplitterDistance = 311;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // ChartTab
            // 
            this.ChartTab.Controls.Add(this.tabPage1);
            this.ChartTab.Controls.Add(this.tabPage2);
            this.ChartTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartTab.Location = new System.Drawing.Point(0, 0);
            this.ChartTab.Name = "ChartTab";
            this.ChartTab.SelectedIndex = 0;
            this.ChartTab.Size = new System.Drawing.Size(597, 311);
            this.ChartTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ResultChart);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(589, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Result Chart";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ResultChart
            // 
            this.ResultChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.Title = "Iterations";
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisX2.Title = "Objective Value";
            chartArea1.AxisY.Title = "Objective Value";
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.ResultChart.ChartAreas.Add(chartArea1);
            this.ResultChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.ResultChart.Legends.Add(legend1);
            this.ResultChart.Location = new System.Drawing.Point(3, 3);
            this.ResultChart.Name = "ResultChart";
            this.ResultChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.DarkBlue;
            series1.Legend = "Legend1";
            series1.Name = "Iteration Best";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.YellowGreen;
            series2.Legend = "Legend1";
            series2.Name = "Iteration Average";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series3.Legend = "Legend1";
            series3.Name = "Best So Far";
            this.ResultChart.Series.Add(series1);
            this.ResultChart.Series.Add(series2);
            this.ResultChart.Series.Add(series3);
            this.ResultChart.Size = new System.Drawing.Size(583, 276);
            this.ResultChart.TabIndex = 30;
            this.ResultChart.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CompareChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(589, 285);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compare Chart";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CompareChart
            // 
            this.CompareChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisX.Title = "Iterations";
            chartArea2.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisX2.Title = "Objective Value";
            chartArea2.AxisY.Title = "Objective Value";
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.CompareChart.ChartAreas.Add(chartArea2);
            this.CompareChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.CompareChart.Legends.Add(legend2);
            this.CompareChart.Location = new System.Drawing.Point(3, 3);
            this.CompareChart.Name = "CompareChart";
            this.CompareChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            this.CompareChart.Size = new System.Drawing.Size(583, 279);
            this.CompareChart.TabIndex = 31;
            this.CompareChart.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.SolutionTab);
            this.tabControl1.Controls.Add(this.PSO_SolutionTab);
            this.tabControl1.Controls.Add(this.GA_SolutionTab);
            this.tabControl1.Controls.Add(this.AFSO_SolutionTab);
            this.tabControl1.Controls.Add(this.All_Result_Tab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(597, 151);
            this.tabControl1.TabIndex = 0;
            // 
            // SolutionTab
            // 
            this.SolutionTab.Location = new System.Drawing.Point(4, 25);
            this.SolutionTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SolutionTab.Name = "SolutionTab";
            this.SolutionTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SolutionTab.Size = new System.Drawing.Size(589, 122);
            this.SolutionTab.TabIndex = 0;
            this.SolutionTab.Text = "Location";
            this.SolutionTab.UseVisualStyleBackColor = true;
            // 
            // PSO_SolutionTab
            // 
            this.PSO_SolutionTab.Controls.Add(this.PSO_VelocityLabel);
            this.PSO_SolutionTab.Controls.Add(this.PSO_SolutionLabel);
            this.PSO_SolutionTab.Controls.Add(this.PSO_VelocityRtb);
            this.PSO_SolutionTab.Controls.Add(this.PSO_SolutionRtb);
            this.PSO_SolutionTab.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PSO_SolutionTab.Location = new System.Drawing.Point(4, 22);
            this.PSO_SolutionTab.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PSO_SolutionTab.Name = "PSO_SolutionTab";
            this.PSO_SolutionTab.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PSO_SolutionTab.Size = new System.Drawing.Size(589, 125);
            this.PSO_SolutionTab.TabIndex = 1;
            this.PSO_SolutionTab.Text = "(PSO)S and  V";
            this.PSO_SolutionTab.UseVisualStyleBackColor = true;
            // 
            // PSO_VelocityLabel
            // 
            this.PSO_VelocityLabel.AutoSize = true;
            this.PSO_VelocityLabel.Location = new System.Drawing.Point(149, 133);
            this.PSO_VelocityLabel.Name = "PSO_VelocityLabel";
            this.PSO_VelocityLabel.Size = new System.Drawing.Size(73, 15);
            this.PSO_VelocityLabel.TabIndex = 3;
            this.PSO_VelocityLabel.Text = "PSO Velocity";
            // 
            // PSO_SolutionLabel
            // 
            this.PSO_SolutionLabel.AutoSize = true;
            this.PSO_SolutionLabel.Location = new System.Drawing.Point(148, 11);
            this.PSO_SolutionLabel.Name = "PSO_SolutionLabel";
            this.PSO_SolutionLabel.Size = new System.Drawing.Size(76, 15);
            this.PSO_SolutionLabel.TabIndex = 2;
            this.PSO_SolutionLabel.Text = "PSO Solution";
            // 
            // PSO_VelocityRtb
            // 
            this.PSO_VelocityRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PSO_VelocityRtb.Location = new System.Drawing.Point(16, 157);
            this.PSO_VelocityRtb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PSO_VelocityRtb.Name = "PSO_VelocityRtb";
            this.PSO_VelocityRtb.Size = new System.Drawing.Size(558, 3);
            this.PSO_VelocityRtb.TabIndex = 1;
            this.PSO_VelocityRtb.Text = "";
            // 
            // PSO_SolutionRtb
            // 
            this.PSO_SolutionRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PSO_SolutionRtb.Location = new System.Drawing.Point(16, 31);
            this.PSO_SolutionRtb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PSO_SolutionRtb.Name = "PSO_SolutionRtb";
            this.PSO_SolutionRtb.Size = new System.Drawing.Size(558, 3);
            this.PSO_SolutionRtb.TabIndex = 0;
            this.PSO_SolutionRtb.Text = "";
            // 
            // GA_SolutionTab
            // 
            this.GA_SolutionTab.Controls.Add(this.GA_ChromosomeRtbLabel);
            this.GA_SolutionTab.Controls.Add(this.GA_RTBLabel);
            this.GA_SolutionTab.Controls.Add(this.GA_ChromosomeRtb);
            this.GA_SolutionTab.Controls.Add(this.GA_SolutionRtb);
            this.GA_SolutionTab.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GA_SolutionTab.Location = new System.Drawing.Point(4, 22);
            this.GA_SolutionTab.Name = "GA_SolutionTab";
            this.GA_SolutionTab.Size = new System.Drawing.Size(589, 125);
            this.GA_SolutionTab.TabIndex = 2;
            this.GA_SolutionTab.Text = "(GA)S and Chrom";
            this.GA_SolutionTab.UseVisualStyleBackColor = true;
            // 
            // GA_ChromosomeRtbLabel
            // 
            this.GA_ChromosomeRtbLabel.AutoSize = true;
            this.GA_ChromosomeRtbLabel.Location = new System.Drawing.Point(149, 132);
            this.GA_ChromosomeRtbLabel.Name = "GA_ChromosomeRtbLabel";
            this.GA_ChromosomeRtbLabel.Size = new System.Drawing.Size(96, 15);
            this.GA_ChromosomeRtbLabel.TabIndex = 7;
            this.GA_ChromosomeRtbLabel.Text = "GA Chromosome";
            // 
            // GA_RTBLabel
            // 
            this.GA_RTBLabel.AutoSize = true;
            this.GA_RTBLabel.Location = new System.Drawing.Point(148, 10);
            this.GA_RTBLabel.Name = "GA_RTBLabel";
            this.GA_RTBLabel.Size = new System.Drawing.Size(70, 15);
            this.GA_RTBLabel.TabIndex = 6;
            this.GA_RTBLabel.Text = "GA Solution";
            // 
            // GA_ChromosomeRtb
            // 
            this.GA_ChromosomeRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GA_ChromosomeRtb.Location = new System.Drawing.Point(16, 156);
            this.GA_ChromosomeRtb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GA_ChromosomeRtb.Name = "GA_ChromosomeRtb";
            this.GA_ChromosomeRtb.Size = new System.Drawing.Size(558, 3);
            this.GA_ChromosomeRtb.TabIndex = 5;
            this.GA_ChromosomeRtb.Text = "";
            // 
            // GA_SolutionRtb
            // 
            this.GA_SolutionRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GA_SolutionRtb.Location = new System.Drawing.Point(16, 30);
            this.GA_SolutionRtb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GA_SolutionRtb.Name = "GA_SolutionRtb";
            this.GA_SolutionRtb.Size = new System.Drawing.Size(558, 3);
            this.GA_SolutionRtb.TabIndex = 4;
            this.GA_SolutionRtb.Text = "";
            // 
            // AFSO_SolutionTab
            // 
            this.AFSO_SolutionTab.Controls.Add(this.label1);
            this.AFSO_SolutionTab.Controls.Add(this.AFSO_BehaviorRtb);
            this.AFSO_SolutionTab.Controls.Add(this.AFSO_RTBLabel);
            this.AFSO_SolutionTab.Controls.Add(this.AFSO_SolutionRtb);
            this.AFSO_SolutionTab.Location = new System.Drawing.Point(4, 25);
            this.AFSO_SolutionTab.Name = "AFSO_SolutionTab";
            this.AFSO_SolutionTab.Size = new System.Drawing.Size(589, 122);
            this.AFSO_SolutionTab.TabIndex = 3;
            this.AFSO_SolutionTab.Text = "(AFSO)S and Beh";
            this.AFSO_SolutionTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(150, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fish Behavior";
            // 
            // AFSO_BehaviorRtb
            // 
            this.AFSO_BehaviorRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AFSO_BehaviorRtb.Location = new System.Drawing.Point(17, 155);
            this.AFSO_BehaviorRtb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AFSO_BehaviorRtb.Name = "AFSO_BehaviorRtb";
            this.AFSO_BehaviorRtb.Size = new System.Drawing.Size(558, 0);
            this.AFSO_BehaviorRtb.TabIndex = 9;
            this.AFSO_BehaviorRtb.Text = "";
            // 
            // AFSO_RTBLabel
            // 
            this.AFSO_RTBLabel.AutoSize = true;
            this.AFSO_RTBLabel.Location = new System.Drawing.Point(149, 11);
            this.AFSO_RTBLabel.Name = "AFSO_RTBLabel";
            this.AFSO_RTBLabel.Size = new System.Drawing.Size(89, 16);
            this.AFSO_RTBLabel.TabIndex = 8;
            this.AFSO_RTBLabel.Text = "AFSO Solution";
            // 
            // AFSO_SolutionRtb
            // 
            this.AFSO_SolutionRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AFSO_SolutionRtb.Location = new System.Drawing.Point(17, 31);
            this.AFSO_SolutionRtb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AFSO_SolutionRtb.Name = "AFSO_SolutionRtb";
            this.AFSO_SolutionRtb.Size = new System.Drawing.Size(558, 0);
            this.AFSO_SolutionRtb.TabIndex = 7;
            this.AFSO_SolutionRtb.Text = "";
            // 
            // All_Result_Tab
            // 
            this.All_Result_Tab.Controls.Add(this.AllResultRtbox);
            this.All_Result_Tab.Location = new System.Drawing.Point(4, 22);
            this.All_Result_Tab.Name = "All_Result_Tab";
            this.All_Result_Tab.Size = new System.Drawing.Size(589, 125);
            this.All_Result_Tab.TabIndex = 4;
            this.All_Result_Tab.Text = "All Result";
            this.All_Result_Tab.UseVisualStyleBackColor = true;
            // 
            // AllResultRtbox
            // 
            this.AllResultRtbox.Location = new System.Drawing.Point(3, 3);
            this.AllResultRtbox.Name = "AllResultRtbox";
            this.AllResultRtbox.Size = new System.Drawing.Size(583, 116);
            this.AllResultRtbox.TabIndex = 0;
            this.AllResultRtbox.Text = "";
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PropertyGrid.Location = new System.Drawing.Point(3, 270);
            this.PropertyGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(324, 193);
            this.PropertyGrid.TabIndex = 0;
            // 
            // COPTab
            // 
            this.COPTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.COPTab.Controls.Add(this.PSO_COPTab);
            this.COPTab.Controls.Add(this.GA_Tab);
            this.COPTab.Controls.Add(this.AFSO_Tab);
            this.COPTab.Controls.Add(this.AllRunTab);
            this.COPTab.Enabled = false;
            this.COPTab.Location = new System.Drawing.Point(1, 3);
            this.COPTab.Name = "COPTab";
            this.COPTab.SelectedIndex = 0;
            this.COPTab.Size = new System.Drawing.Size(328, 260);
            this.COPTab.TabIndex = 30;
            // 
            // PSO_COPTab
            // 
            this.PSO_COPTab.Controls.Add(this.PSO_ChaoticCombobox);
            this.PSO_COPTab.Controls.Add(this.PSO_ChaoticCheck);
            this.PSO_COPTab.Controls.Add(this.PSO_UpdateParameters);
            this.PSO_COPTab.Controls.Add(this.PSO_OneIteration);
            this.PSO_COPTab.Controls.Add(this.PSO_StopByLimitedTimes);
            this.PSO_COPTab.Controls.Add(this.PSO_WholeIteration);
            this.PSO_COPTab.Controls.Add(this.PSO_BestSolutionRichBox);
            this.PSO_COPTab.Controls.Add(this.PSO_Reset);
            this.PSO_COPTab.Controls.Add(this.PSO_Create);
            this.PSO_COPTab.Controls.Add(this.PSO_UpdateInRealTime);
            this.PSO_COPTab.Controls.Add(this.ACO_BestSolution);
            this.PSO_COPTab.Controls.Add(this.PSOBestObjectiveLabel);
            this.PSO_COPTab.Controls.Add(this.PSO_BestObjectiveTextBox);
            this.PSO_COPTab.Location = new System.Drawing.Point(4, 25);
            this.PSO_COPTab.Name = "PSO_COPTab";
            this.PSO_COPTab.Size = new System.Drawing.Size(320, 231);
            this.PSO_COPTab.TabIndex = 2;
            this.PSO_COPTab.Text = "PSO COP Solver";
            this.PSO_COPTab.UseVisualStyleBackColor = true;
            // 
            // PSO_ChaoticCombobox
            // 
            this.PSO_ChaoticCombobox.FormattingEnabled = true;
            this.PSO_ChaoticCombobox.Location = new System.Drawing.Point(146, 3);
            this.PSO_ChaoticCombobox.Name = "PSO_ChaoticCombobox";
            this.PSO_ChaoticCombobox.Size = new System.Drawing.Size(171, 24);
            this.PSO_ChaoticCombobox.TabIndex = 42;
            // 
            // PSO_ChaoticCheck
            // 
            this.PSO_ChaoticCheck.AutoSize = true;
            this.PSO_ChaoticCheck.Enabled = false;
            this.PSO_ChaoticCheck.Location = new System.Drawing.Point(14, 4);
            this.PSO_ChaoticCheck.Name = "PSO_ChaoticCheck";
            this.PSO_ChaoticCheck.Size = new System.Drawing.Size(126, 20);
            this.PSO_ChaoticCheck.TabIndex = 41;
            this.PSO_ChaoticCheck.Text = "Chaotic Mapping";
            this.PSO_ChaoticCheck.UseVisualStyleBackColor = true;
            this.PSO_ChaoticCheck.CheckedChanged += new System.EventHandler(this.PSO_ChaoticCheck_CheckedChanged);
            // 
            // PSO_UpdateParameters
            // 
            this.PSO_UpdateParameters.AutoSize = true;
            this.PSO_UpdateParameters.Checked = true;
            this.PSO_UpdateParameters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PSO_UpdateParameters.Location = new System.Drawing.Point(14, 30);
            this.PSO_UpdateParameters.Name = "PSO_UpdateParameters";
            this.PSO_UpdateParameters.Size = new System.Drawing.Size(143, 20);
            this.PSO_UpdateParameters.TabIndex = 40;
            this.PSO_UpdateParameters.Text = "Update InteriaFactor";
            this.PSO_UpdateParameters.UseVisualStyleBackColor = true;
            this.PSO_UpdateParameters.CheckedChanged += new System.EventHandler(this.PSO_UpdateParameters_CheckedChanged);
            // 
            // PSO_OneIteration
            // 
            this.PSO_OneIteration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PSO_OneIteration.Enabled = false;
            this.PSO_OneIteration.Location = new System.Drawing.Point(32, 193);
            this.PSO_OneIteration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PSO_OneIteration.Name = "PSO_OneIteration";
            this.PSO_OneIteration.Size = new System.Drawing.Size(126, 27);
            this.PSO_OneIteration.TabIndex = 28;
            this.PSO_OneIteration.Text = "Run One Iteration";
            this.PSO_OneIteration.UseVisualStyleBackColor = true;
            this.PSO_OneIteration.Click += new System.EventHandler(this.PSO_OneIteration_Click);
            // 
            // PSO_StopByLimitedTimes
            // 
            this.PSO_StopByLimitedTimes.AutoSize = true;
            this.PSO_StopByLimitedTimes.Checked = true;
            this.PSO_StopByLimitedTimes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PSO_StopByLimitedTimes.Location = new System.Drawing.Point(14, 79);
            this.PSO_StopByLimitedTimes.Name = "PSO_StopByLimitedTimes";
            this.PSO_StopByLimitedTimes.Size = new System.Drawing.Size(193, 20);
            this.PSO_StopByLimitedTimes.TabIndex = 27;
            this.PSO_StopByLimitedTimes.Text = "Limited Non-Improved Times";
            this.PSO_StopByLimitedTimes.UseVisualStyleBackColor = true;
            // 
            // PSO_WholeIteration
            // 
            this.PSO_WholeIteration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PSO_WholeIteration.Enabled = false;
            this.PSO_WholeIteration.Location = new System.Drawing.Point(180, 192);
            this.PSO_WholeIteration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PSO_WholeIteration.Name = "PSO_WholeIteration";
            this.PSO_WholeIteration.Size = new System.Drawing.Size(121, 27);
            this.PSO_WholeIteration.TabIndex = 1;
            this.PSO_WholeIteration.Text = "Run To End";
            this.PSO_WholeIteration.UseVisualStyleBackColor = true;
            this.PSO_WholeIteration.Click += new System.EventHandler(this.RunToEnd_Click);
            // 
            // PSO_BestSolutionRichBox
            // 
            this.PSO_BestSolutionRichBox.Location = new System.Drawing.Point(14, 152);
            this.PSO_BestSolutionRichBox.Name = "PSO_BestSolutionRichBox";
            this.PSO_BestSolutionRichBox.Size = new System.Drawing.Size(303, 33);
            this.PSO_BestSolutionRichBox.TabIndex = 26;
            this.PSO_BestSolutionRichBox.Text = "";
            // 
            // PSO_Reset
            // 
            this.PSO_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PSO_Reset.Enabled = false;
            this.PSO_Reset.Location = new System.Drawing.Point(207, 69);
            this.PSO_Reset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PSO_Reset.Name = "PSO_Reset";
            this.PSO_Reset.Size = new System.Drawing.Size(110, 30);
            this.PSO_Reset.TabIndex = 3;
            this.PSO_Reset.Text = "Initialize";
            this.PSO_Reset.UseVisualStyleBackColor = true;
            this.PSO_Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // PSO_Create
            // 
            this.PSO_Create.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PSO_Create.Enabled = false;
            this.PSO_Create.Location = new System.Drawing.Point(207, 34);
            this.PSO_Create.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PSO_Create.Name = "PSO_Create";
            this.PSO_Create.Size = new System.Drawing.Size(110, 33);
            this.PSO_Create.TabIndex = 4;
            this.PSO_Create.Text = "Create Solver";
            this.PSO_Create.UseVisualStyleBackColor = true;
            this.PSO_Create.Click += new System.EventHandler(this.btnCreateSolve_Click);
            // 
            // PSO_UpdateInRealTime
            // 
            this.PSO_UpdateInRealTime.AutoSize = true;
            this.PSO_UpdateInRealTime.Location = new System.Drawing.Point(14, 56);
            this.PSO_UpdateInRealTime.Name = "PSO_UpdateInRealTime";
            this.PSO_UpdateInRealTime.Size = new System.Drawing.Size(129, 20);
            this.PSO_UpdateInRealTime.TabIndex = 25;
            this.PSO_UpdateInRealTime.Text = "Real Time Update";
            this.PSO_UpdateInRealTime.UseVisualStyleBackColor = true;
            // 
            // ACO_BestSolution
            // 
            this.ACO_BestSolution.AutoSize = true;
            this.ACO_BestSolution.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ACO_BestSolution.ForeColor = System.Drawing.Color.Green;
            this.ACO_BestSolution.Location = new System.Drawing.Point(12, 131);
            this.ACO_BestSolution.Name = "ACO_BestSolution";
            this.ACO_BestSolution.Size = new System.Drawing.Size(87, 17);
            this.ACO_BestSolution.TabIndex = 21;
            this.ACO_BestSolution.Text = "Best Solution";
            // 
            // PSOBestObjectiveLabel
            // 
            this.PSOBestObjectiveLabel.AutoSize = true;
            this.PSOBestObjectiveLabel.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PSOBestObjectiveLabel.ForeColor = System.Drawing.Color.Purple;
            this.PSOBestObjectiveLabel.Location = new System.Drawing.Point(11, 103);
            this.PSOBestObjectiveLabel.Name = "PSOBestObjectiveLabel";
            this.PSOBestObjectiveLabel.Size = new System.Drawing.Size(91, 17);
            this.PSOBestObjectiveLabel.TabIndex = 22;
            this.PSOBestObjectiveLabel.Text = "BestObjective";
            // 
            // PSO_BestObjectiveTextBox
            // 
            this.PSO_BestObjectiveTextBox.Enabled = false;
            this.PSO_BestObjectiveTextBox.Location = new System.Drawing.Point(146, 102);
            this.PSO_BestObjectiveTextBox.Name = "PSO_BestObjectiveTextBox";
            this.PSO_BestObjectiveTextBox.Size = new System.Drawing.Size(171, 23);
            this.PSO_BestObjectiveTextBox.TabIndex = 24;
            // 
            // GA_Tab
            // 
            this.GA_Tab.Controls.Add(this.GA_BestSolutionRichBox);
            this.GA_Tab.Controls.Add(this.GA_StopByLimitedTimes);
            this.GA_Tab.Controls.Add(this.GA_RealTimeUpdate);
            this.GA_Tab.Controls.Add(this.GA_WholeInteration);
            this.GA_Tab.Controls.Add(this.PermutationBestSolutionLabel);
            this.GA_Tab.Controls.Add(this.GA_Reset);
            this.GA_Tab.Controls.Add(this.GA_OneInteration);
            this.GA_Tab.Controls.Add(this.GABestObjectiveLabel);
            this.GA_Tab.Controls.Add(this.GA_Create);
            this.GA_Tab.Controls.Add(this.GA_BestObjectiveTextBox);
            this.GA_Tab.Location = new System.Drawing.Point(4, 22);
            this.GA_Tab.Name = "GA_Tab";
            this.GA_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.GA_Tab.Size = new System.Drawing.Size(320, 234);
            this.GA_Tab.TabIndex = 1;
            this.GA_Tab.Text = "GA COP Solver";
            this.GA_Tab.UseVisualStyleBackColor = true;
            // 
            // GA_BestSolutionRichBox
            // 
            this.GA_BestSolutionRichBox.Location = new System.Drawing.Point(14, 118);
            this.GA_BestSolutionRichBox.Name = "GA_BestSolutionRichBox";
            this.GA_BestSolutionRichBox.Size = new System.Drawing.Size(306, 57);
            this.GA_BestSolutionRichBox.TabIndex = 30;
            this.GA_BestSolutionRichBox.Text = "";
            // 
            // GA_StopByLimitedTimes
            // 
            this.GA_StopByLimitedTimes.AutoSize = true;
            this.GA_StopByLimitedTimes.Checked = true;
            this.GA_StopByLimitedTimes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GA_StopByLimitedTimes.Location = new System.Drawing.Point(14, 26);
            this.GA_StopByLimitedTimes.Name = "GA_StopByLimitedTimes";
            this.GA_StopByLimitedTimes.Size = new System.Drawing.Size(193, 20);
            this.GA_StopByLimitedTimes.TabIndex = 28;
            this.GA_StopByLimitedTimes.Text = "Limited Non-Improved Times";
            this.GA_StopByLimitedTimes.UseVisualStyleBackColor = true;
            // 
            // GA_RealTimeUpdate
            // 
            this.GA_RealTimeUpdate.AutoSize = true;
            this.GA_RealTimeUpdate.Location = new System.Drawing.Point(14, 6);
            this.GA_RealTimeUpdate.Name = "GA_RealTimeUpdate";
            this.GA_RealTimeUpdate.Size = new System.Drawing.Size(129, 20);
            this.GA_RealTimeUpdate.TabIndex = 16;
            this.GA_RealTimeUpdate.Text = "Real Time Update";
            this.GA_RealTimeUpdate.UseVisualStyleBackColor = true;
            // 
            // GA_WholeInteration
            // 
            this.GA_WholeInteration.Enabled = false;
            this.GA_WholeInteration.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GA_WholeInteration.Location = new System.Drawing.Point(175, 182);
            this.GA_WholeInteration.Name = "GA_WholeInteration";
            this.GA_WholeInteration.Size = new System.Drawing.Size(145, 33);
            this.GA_WholeInteration.TabIndex = 5;
            this.GA_WholeInteration.Text = "Run Whole Interation";
            this.GA_WholeInteration.UseVisualStyleBackColor = true;
            this.GA_WholeInteration.Click += new System.EventHandler(this.GA_WholeInteration_Click_1);
            // 
            // PermutationBestSolutionLabel
            // 
            this.PermutationBestSolutionLabel.AutoSize = true;
            this.PermutationBestSolutionLabel.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PermutationBestSolutionLabel.ForeColor = System.Drawing.Color.Green;
            this.PermutationBestSolutionLabel.Location = new System.Drawing.Point(27, 85);
            this.PermutationBestSolutionLabel.Name = "PermutationBestSolutionLabel";
            this.PermutationBestSolutionLabel.Size = new System.Drawing.Size(87, 17);
            this.PermutationBestSolutionLabel.TabIndex = 6;
            this.PermutationBestSolutionLabel.Text = "Best Solution";
            // 
            // GA_Reset
            // 
            this.GA_Reset.Enabled = false;
            this.GA_Reset.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GA_Reset.Location = new System.Drawing.Point(133, 77);
            this.GA_Reset.Name = "GA_Reset";
            this.GA_Reset.Size = new System.Drawing.Size(187, 35);
            this.GA_Reset.TabIndex = 3;
            this.GA_Reset.Text = "Initialize";
            this.GA_Reset.UseVisualStyleBackColor = true;
            this.GA_Reset.Click += new System.EventHandler(this.GA_Initialize_Click);
            // 
            // GA_OneInteration
            // 
            this.GA_OneInteration.Enabled = false;
            this.GA_OneInteration.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GA_OneInteration.Location = new System.Drawing.Point(14, 182);
            this.GA_OneInteration.Name = "GA_OneInteration";
            this.GA_OneInteration.Size = new System.Drawing.Size(150, 33);
            this.GA_OneInteration.TabIndex = 4;
            this.GA_OneInteration.Text = "Run 1 Interation";
            this.GA_OneInteration.UseVisualStyleBackColor = true;
            this.GA_OneInteration.Click += new System.EventHandler(this.GA_OneInteration_Click);
            // 
            // GABestObjectiveLabel
            // 
            this.GABestObjectiveLabel.AutoSize = true;
            this.GABestObjectiveLabel.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GABestObjectiveLabel.ForeColor = System.Drawing.Color.Purple;
            this.GABestObjectiveLabel.Location = new System.Drawing.Point(27, 52);
            this.GABestObjectiveLabel.Name = "GABestObjectiveLabel";
            this.GABestObjectiveLabel.Size = new System.Drawing.Size(91, 17);
            this.GABestObjectiveLabel.TabIndex = 7;
            this.GABestObjectiveLabel.Text = "BestObjective";
            // 
            // GA_Create
            // 
            this.GA_Create.Enabled = false;
            this.GA_Create.Location = new System.Drawing.Point(207, 11);
            this.GA_Create.Name = "GA_Create";
            this.GA_Create.Size = new System.Drawing.Size(113, 28);
            this.GA_Create.TabIndex = 5;
            this.GA_Create.Text = "Create GA Solver";
            this.GA_Create.UseVisualStyleBackColor = true;
            this.GA_Create.Click += new System.EventHandler(this.GA_Create_Click);
            // 
            // GA_BestObjectiveTextBox
            // 
            this.GA_BestObjectiveTextBox.Enabled = false;
            this.GA_BestObjectiveTextBox.Location = new System.Drawing.Point(133, 48);
            this.GA_BestObjectiveTextBox.Name = "GA_BestObjectiveTextBox";
            this.GA_BestObjectiveTextBox.Size = new System.Drawing.Size(187, 23);
            this.GA_BestObjectiveTextBox.TabIndex = 10;
            // 
            // AFSO_Tab
            // 
            this.AFSO_Tab.Controls.Add(this.AFSO_PSOEnd_Value);
            this.AFSO_Tab.Controls.Add(this.AFSO_PSOEnd_Bar);
            this.AFSO_Tab.Controls.Add(this.AFSO_PSOEnd);
            this.AFSO_Tab.Controls.Add(this.AFSO_Update_Parameters);
            this.AFSO_Tab.Controls.Add(this.AFSO_OneIteration);
            this.AFSO_Tab.Controls.Add(this.AFSO_StopByLimitedTimes);
            this.AFSO_Tab.Controls.Add(this.AFSO_WholeIteration);
            this.AFSO_Tab.Controls.Add(this.AFSO_BestSolutionRichBox);
            this.AFSO_Tab.Controls.Add(this.AFSO_Reset);
            this.AFSO_Tab.Controls.Add(this.AFSO_Create);
            this.AFSO_Tab.Controls.Add(this.AFSO_UpdateInRealTime);
            this.AFSO_Tab.Controls.Add(this.AFSO_BestSolution);
            this.AFSO_Tab.Controls.Add(this.AFSOBestObjectiveLabel);
            this.AFSO_Tab.Controls.Add(this.AFSO_BestObjectiveTextBox);
            this.AFSO_Tab.Location = new System.Drawing.Point(4, 25);
            this.AFSO_Tab.Name = "AFSO_Tab";
            this.AFSO_Tab.Size = new System.Drawing.Size(320, 231);
            this.AFSO_Tab.TabIndex = 3;
            this.AFSO_Tab.Text = "AFSO COP Solver";
            this.AFSO_Tab.UseVisualStyleBackColor = true;
            // 
            // AFSO_PSOEnd_Value
            // 
            this.AFSO_PSOEnd_Value.AutoSize = true;
            this.AFSO_PSOEnd_Value.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AFSO_PSOEnd_Value.Location = new System.Drawing.Point(263, 73);
            this.AFSO_PSOEnd_Value.Name = "AFSO_PSOEnd_Value";
            this.AFSO_PSOEnd_Value.Size = new System.Drawing.Size(15, 16);
            this.AFSO_PSOEnd_Value.TabIndex = 43;
            this.AFSO_PSOEnd_Value.Text = "0";
            // 
            // AFSO_PSOEnd_Bar
            // 
            this.AFSO_PSOEnd_Bar.Location = new System.Drawing.Point(236, 46);
            this.AFSO_PSOEnd_Bar.Maximum = 100;
            this.AFSO_PSOEnd_Bar.Name = "AFSO_PSOEnd_Bar";
            this.AFSO_PSOEnd_Bar.Size = new System.Drawing.Size(81, 45);
            this.AFSO_PSOEnd_Bar.TabIndex = 42;
            this.AFSO_PSOEnd_Bar.TickFrequency = 20;
            this.AFSO_PSOEnd_Bar.ValueChanged += new System.EventHandler(this.AFSO_PSOEnd_Box_ValueChanged);
            // 
            // AFSO_PSOEnd
            // 
            this.AFSO_PSOEnd.AutoSize = true;
            this.AFSO_PSOEnd.Location = new System.Drawing.Point(158, 47);
            this.AFSO_PSOEnd.Name = "AFSO_PSOEnd";
            this.AFSO_PSOEnd.Size = new System.Drawing.Size(76, 20);
            this.AFSO_PSOEnd.TabIndex = 40;
            this.AFSO_PSOEnd.Text = "PSO End";
            this.AFSO_PSOEnd.UseVisualStyleBackColor = true;
            this.AFSO_PSOEnd.CheckedChanged += new System.EventHandler(this.AFSO_PSOEnd_CheckedChanged);
            // 
            // AFSO_Update_Parameters
            // 
            this.AFSO_Update_Parameters.AutoSize = true;
            this.AFSO_Update_Parameters.Checked = true;
            this.AFSO_Update_Parameters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AFSO_Update_Parameters.Location = new System.Drawing.Point(14, 48);
            this.AFSO_Update_Parameters.Name = "AFSO_Update_Parameters";
            this.AFSO_Update_Parameters.Size = new System.Drawing.Size(136, 20);
            this.AFSO_Update_Parameters.TabIndex = 39;
            this.AFSO_Update_Parameters.Text = "Update Parameters";
            this.AFSO_Update_Parameters.UseVisualStyleBackColor = true;
            // 
            // AFSO_OneIteration
            // 
            this.AFSO_OneIteration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AFSO_OneIteration.Enabled = false;
            this.AFSO_OneIteration.Location = new System.Drawing.Point(14, 180);
            this.AFSO_OneIteration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AFSO_OneIteration.Name = "AFSO_OneIteration";
            this.AFSO_OneIteration.Size = new System.Drawing.Size(148, 38);
            this.AFSO_OneIteration.TabIndex = 38;
            this.AFSO_OneIteration.Text = "Run One Iteration";
            this.AFSO_OneIteration.UseVisualStyleBackColor = true;
            this.AFSO_OneIteration.Click += new System.EventHandler(this.AFSO_OneIteration_Click);
            // 
            // AFSO_StopByLimitedTimes
            // 
            this.AFSO_StopByLimitedTimes.AutoSize = true;
            this.AFSO_StopByLimitedTimes.Checked = true;
            this.AFSO_StopByLimitedTimes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AFSO_StopByLimitedTimes.Location = new System.Drawing.Point(14, 26);
            this.AFSO_StopByLimitedTimes.Name = "AFSO_StopByLimitedTimes";
            this.AFSO_StopByLimitedTimes.Size = new System.Drawing.Size(193, 20);
            this.AFSO_StopByLimitedTimes.TabIndex = 37;
            this.AFSO_StopByLimitedTimes.Text = "Limited Non-Improved Times";
            this.AFSO_StopByLimitedTimes.UseVisualStyleBackColor = true;
            // 
            // AFSO_WholeIteration
            // 
            this.AFSO_WholeIteration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AFSO_WholeIteration.Enabled = false;
            this.AFSO_WholeIteration.Location = new System.Drawing.Point(179, 180);
            this.AFSO_WholeIteration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AFSO_WholeIteration.Name = "AFSO_WholeIteration";
            this.AFSO_WholeIteration.Size = new System.Drawing.Size(138, 38);
            this.AFSO_WholeIteration.TabIndex = 29;
            this.AFSO_WholeIteration.Text = "Run To End";
            this.AFSO_WholeIteration.UseVisualStyleBackColor = true;
            this.AFSO_WholeIteration.Click += new System.EventHandler(this.AFSO_WholeIteration_Click);
            // 
            // AFSO_BestSolutionRichBox
            // 
            this.AFSO_BestSolutionRichBox.Location = new System.Drawing.Point(14, 139);
            this.AFSO_BestSolutionRichBox.Name = "AFSO_BestSolutionRichBox";
            this.AFSO_BestSolutionRichBox.Size = new System.Drawing.Size(303, 31);
            this.AFSO_BestSolutionRichBox.TabIndex = 36;
            this.AFSO_BestSolutionRichBox.Text = "";
            // 
            // AFSO_Reset
            // 
            this.AFSO_Reset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AFSO_Reset.Enabled = false;
            this.AFSO_Reset.Location = new System.Drawing.Point(133, 102);
            this.AFSO_Reset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AFSO_Reset.Name = "AFSO_Reset";
            this.AFSO_Reset.Size = new System.Drawing.Size(184, 33);
            this.AFSO_Reset.TabIndex = 30;
            this.AFSO_Reset.Text = "Initialize";
            this.AFSO_Reset.UseVisualStyleBackColor = true;
            this.AFSO_Reset.Click += new System.EventHandler(this.AFSO_Reset_Click);
            // 
            // AFSO_Create
            // 
            this.AFSO_Create.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AFSO_Create.Enabled = false;
            this.AFSO_Create.Location = new System.Drawing.Point(207, 11);
            this.AFSO_Create.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AFSO_Create.Name = "AFSO_Create";
            this.AFSO_Create.Size = new System.Drawing.Size(110, 28);
            this.AFSO_Create.TabIndex = 31;
            this.AFSO_Create.Text = "Create Solver";
            this.AFSO_Create.UseVisualStyleBackColor = true;
            this.AFSO_Create.Click += new System.EventHandler(this.CreateAFSOSolver);
            // 
            // AFSO_UpdateInRealTime
            // 
            this.AFSO_UpdateInRealTime.AutoSize = true;
            this.AFSO_UpdateInRealTime.Location = new System.Drawing.Point(14, 6);
            this.AFSO_UpdateInRealTime.Name = "AFSO_UpdateInRealTime";
            this.AFSO_UpdateInRealTime.Size = new System.Drawing.Size(129, 20);
            this.AFSO_UpdateInRealTime.TabIndex = 35;
            this.AFSO_UpdateInRealTime.Text = "Real Time Update";
            this.AFSO_UpdateInRealTime.UseVisualStyleBackColor = true;
            // 
            // AFSO_BestSolution
            // 
            this.AFSO_BestSolution.AutoSize = true;
            this.AFSO_BestSolution.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AFSO_BestSolution.ForeColor = System.Drawing.Color.Green;
            this.AFSO_BestSolution.Location = new System.Drawing.Point(27, 109);
            this.AFSO_BestSolution.Name = "AFSO_BestSolution";
            this.AFSO_BestSolution.Size = new System.Drawing.Size(87, 17);
            this.AFSO_BestSolution.TabIndex = 32;
            this.AFSO_BestSolution.Text = "Best Solution";
            // 
            // AFSOBestObjectiveLabel
            // 
            this.AFSOBestObjectiveLabel.AutoSize = true;
            this.AFSOBestObjectiveLabel.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AFSOBestObjectiveLabel.ForeColor = System.Drawing.Color.Purple;
            this.AFSOBestObjectiveLabel.Location = new System.Drawing.Point(27, 76);
            this.AFSOBestObjectiveLabel.Name = "AFSOBestObjectiveLabel";
            this.AFSOBestObjectiveLabel.Size = new System.Drawing.Size(91, 17);
            this.AFSOBestObjectiveLabel.TabIndex = 33;
            this.AFSOBestObjectiveLabel.Text = "BestObjective";
            // 
            // AFSO_BestObjectiveTextBox
            // 
            this.AFSO_BestObjectiveTextBox.Enabled = false;
            this.AFSO_BestObjectiveTextBox.Location = new System.Drawing.Point(133, 72);
            this.AFSO_BestObjectiveTextBox.Name = "AFSO_BestObjectiveTextBox";
            this.AFSO_BestObjectiveTextBox.Size = new System.Drawing.Size(97, 23);
            this.AFSO_BestObjectiveTextBox.TabIndex = 34;
            // 
            // AllRunTab
            // 
            this.AllRunTab.Controls.Add(this.CPSO_DoubleButtonCheck);
            this.AllRunTab.Controls.Add(this.AllFor30Times);
            this.AllRunTab.Controls.Add(this.AllSolveButton);
            this.AllRunTab.Controls.Add(this.AFSO_Check);
            this.AllRunTab.Controls.Add(this.GA_BinaryCheck);
            this.AllRunTab.Controls.Add(this.CPSO_CircleCheck);
            this.AllRunTab.Controls.Add(this.CPSO_GaussCheck);
            this.AllRunTab.Controls.Add(this.CPSO_SinusoidalCheck);
            this.AllRunTab.Controls.Add(this.CPSO_TentCheck);
            this.AllRunTab.Controls.Add(this.CPSO_LogisticCheck);
            this.AllRunTab.Controls.Add(this.IPSOCheck);
            this.AllRunTab.Controls.Add(this.TPSOCheck);
            this.AllRunTab.Location = new System.Drawing.Point(4, 22);
            this.AllRunTab.Name = "AllRunTab";
            this.AllRunTab.Size = new System.Drawing.Size(320, 234);
            this.AllRunTab.TabIndex = 4;
            this.AllRunTab.Text = "All Solver";
            this.AllRunTab.UseVisualStyleBackColor = true;
            // 
            // CPSO_DoubleButtonCheck
            // 
            this.CPSO_DoubleButtonCheck.AutoSize = true;
            this.CPSO_DoubleButtonCheck.Enabled = false;
            this.CPSO_DoubleButtonCheck.Location = new System.Drawing.Point(27, 199);
            this.CPSO_DoubleButtonCheck.Name = "CPSO_DoubleButtonCheck";
            this.CPSO_DoubleButtonCheck.Size = new System.Drawing.Size(144, 20);
            this.CPSO_DoubleButtonCheck.TabIndex = 11;
            this.CPSO_DoubleButtonCheck.Text = "CPSO-Double-Buton";
            this.CPSO_DoubleButtonCheck.UseVisualStyleBackColor = true;
            this.CPSO_DoubleButtonCheck.CheckedChanged += new System.EventHandler(this.CPSO_DoubleButtonCheckBox_CheckedChanged);
            // 
            // AllFor30Times
            // 
            this.AllFor30Times.Location = new System.Drawing.Point(185, 182);
            this.AllFor30Times.Name = "AllFor30Times";
            this.AllFor30Times.Size = new System.Drawing.Size(126, 36);
            this.AllFor30Times.TabIndex = 10;
            this.AllFor30Times.Text = "All for 30 Times";
            this.AllFor30Times.UseVisualStyleBackColor = true;
            this.AllFor30Times.Click += new System.EventHandler(this.AllFor30Times_Click);
            // 
            // AllSolveButton
            // 
            this.AllSolveButton.Location = new System.Drawing.Point(185, 131);
            this.AllSolveButton.Name = "AllSolveButton";
            this.AllSolveButton.Size = new System.Drawing.Size(126, 36);
            this.AllSolveButton.TabIndex = 9;
            this.AllSolveButton.Text = "All Selected Solve";
            this.AllSolveButton.UseVisualStyleBackColor = true;
            this.AllSolveButton.Click += new System.EventHandler(this.AllSolve);
            // 
            // AFSO_Check
            // 
            this.AFSO_Check.AutoSize = true;
            this.AFSO_Check.Enabled = false;
            this.AFSO_Check.Location = new System.Drawing.Point(173, 43);
            this.AFSO_Check.Name = "AFSO_Check";
            this.AFSO_Check.Size = new System.Drawing.Size(58, 20);
            this.AFSO_Check.TabIndex = 8;
            this.AFSO_Check.Text = "AFSO";
            this.AFSO_Check.UseVisualStyleBackColor = true;
            this.AFSO_Check.CheckedChanged += new System.EventHandler(this.AFSO_Check_CheckedChanged_1);
            // 
            // GA_BinaryCheck
            // 
            this.GA_BinaryCheck.AutoSize = true;
            this.GA_BinaryCheck.Enabled = false;
            this.GA_BinaryCheck.Location = new System.Drawing.Point(173, 17);
            this.GA_BinaryCheck.Name = "GA_BinaryCheck";
            this.GA_BinaryCheck.Size = new System.Drawing.Size(83, 20);
            this.GA_BinaryCheck.TabIndex = 7;
            this.GA_BinaryCheck.Text = "GA-Binary";
            this.GA_BinaryCheck.UseVisualStyleBackColor = true;
            this.GA_BinaryCheck.CheckedChanged += new System.EventHandler(this.GA_BinaryCheck_CheckedChanged);
            // 
            // CPSO_CircleCheck
            // 
            this.CPSO_CircleCheck.AutoSize = true;
            this.CPSO_CircleCheck.Enabled = false;
            this.CPSO_CircleCheck.Location = new System.Drawing.Point(27, 173);
            this.CPSO_CircleCheck.Name = "CPSO_CircleCheck";
            this.CPSO_CircleCheck.Size = new System.Drawing.Size(95, 20);
            this.CPSO_CircleCheck.TabIndex = 6;
            this.CPSO_CircleCheck.Text = "CPSO-Circle";
            this.CPSO_CircleCheck.UseVisualStyleBackColor = true;
            this.CPSO_CircleCheck.CheckedChanged += new System.EventHandler(this.CPSO_CircleCheck_CheckedChanged);
            // 
            // CPSO_GaussCheck
            // 
            this.CPSO_GaussCheck.AutoSize = true;
            this.CPSO_GaussCheck.Enabled = false;
            this.CPSO_GaussCheck.Location = new System.Drawing.Point(27, 147);
            this.CPSO_GaussCheck.Name = "CPSO_GaussCheck";
            this.CPSO_GaussCheck.Size = new System.Drawing.Size(97, 20);
            this.CPSO_GaussCheck.TabIndex = 5;
            this.CPSO_GaussCheck.Text = "CPSO-Gauss";
            this.CPSO_GaussCheck.UseVisualStyleBackColor = true;
            this.CPSO_GaussCheck.CheckedChanged += new System.EventHandler(this.CPSO_GaussCheck_CheckedChanged);
            // 
            // CPSO_SinusoidalCheck
            // 
            this.CPSO_SinusoidalCheck.AutoSize = true;
            this.CPSO_SinusoidalCheck.Enabled = false;
            this.CPSO_SinusoidalCheck.Location = new System.Drawing.Point(27, 121);
            this.CPSO_SinusoidalCheck.Name = "CPSO_SinusoidalCheck";
            this.CPSO_SinusoidalCheck.Size = new System.Drawing.Size(122, 20);
            this.CPSO_SinusoidalCheck.TabIndex = 4;
            this.CPSO_SinusoidalCheck.Text = "CPSO-Sinusoidal";
            this.CPSO_SinusoidalCheck.UseVisualStyleBackColor = true;
            this.CPSO_SinusoidalCheck.CheckedChanged += new System.EventHandler(this.CPSO_SinusoidalCheck_CheckedChanged);
            // 
            // CPSO_TentCheck
            // 
            this.CPSO_TentCheck.AutoSize = true;
            this.CPSO_TentCheck.Enabled = false;
            this.CPSO_TentCheck.Location = new System.Drawing.Point(27, 95);
            this.CPSO_TentCheck.Name = "CPSO_TentCheck";
            this.CPSO_TentCheck.Size = new System.Drawing.Size(89, 20);
            this.CPSO_TentCheck.TabIndex = 3;
            this.CPSO_TentCheck.Text = "CPSO-Tent";
            this.CPSO_TentCheck.UseVisualStyleBackColor = true;
            this.CPSO_TentCheck.CheckedChanged += new System.EventHandler(this.CPSO_TentCheck_CheckedChanged);
            // 
            // CPSO_LogisticCheck
            // 
            this.CPSO_LogisticCheck.AutoSize = true;
            this.CPSO_LogisticCheck.Enabled = false;
            this.CPSO_LogisticCheck.Location = new System.Drawing.Point(27, 69);
            this.CPSO_LogisticCheck.Name = "CPSO_LogisticCheck";
            this.CPSO_LogisticCheck.Size = new System.Drawing.Size(137, 20);
            this.CPSO_LogisticCheck.TabIndex = 2;
            this.CPSO_LogisticCheck.Text = "CPSO-Logistic Map";
            this.CPSO_LogisticCheck.UseVisualStyleBackColor = true;
            this.CPSO_LogisticCheck.CheckedChanged += new System.EventHandler(this.CPSO_LogisticCheck_CheckedChanged);
            // 
            // IPSOCheck
            // 
            this.IPSOCheck.AutoSize = true;
            this.IPSOCheck.Enabled = false;
            this.IPSOCheck.Location = new System.Drawing.Point(27, 43);
            this.IPSOCheck.Name = "IPSOCheck";
            this.IPSOCheck.Size = new System.Drawing.Size(54, 20);
            this.IPSOCheck.TabIndex = 1;
            this.IPSOCheck.Text = "IPSO";
            this.IPSOCheck.UseVisualStyleBackColor = true;
            this.IPSOCheck.CheckedChanged += new System.EventHandler(this.IPSOCheck_CheckedChanged);
            // 
            // TPSOCheck
            // 
            this.TPSOCheck.AutoSize = true;
            this.TPSOCheck.Enabled = false;
            this.TPSOCheck.Location = new System.Drawing.Point(27, 17);
            this.TPSOCheck.Name = "TPSOCheck";
            this.TPSOCheck.Size = new System.Drawing.Size(58, 20);
            this.TPSOCheck.TabIndex = 0;
            this.TPSOCheck.Text = "TPSO";
            this.TPSOCheck.UseVisualStyleBackColor = true;
            this.TPSOCheck.CheckedChanged += new System.EventHandler(this.TPSOCheck_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 538);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Continuous Optimal Problem Solver";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ChartTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultChart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompareChart)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.PSO_SolutionTab.ResumeLayout(false);
            this.PSO_SolutionTab.PerformLayout();
            this.GA_SolutionTab.ResumeLayout(false);
            this.GA_SolutionTab.PerformLayout();
            this.AFSO_SolutionTab.ResumeLayout(false);
            this.AFSO_SolutionTab.PerformLayout();
            this.All_Result_Tab.ResumeLayout(false);
            this.COPTab.ResumeLayout(false);
            this.PSO_COPTab.ResumeLayout(false);
            this.PSO_COPTab.PerformLayout();
            this.GA_Tab.ResumeLayout(false);
            this.GA_Tab.PerformLayout();
            this.AFSO_Tab.ResumeLayout(false);
            this.AFSO_Tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AFSO_PSOEnd_Bar)).EndInit();
            this.AllRunTab.ResumeLayout(false);
            this.AllRunTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage SolutionTab;
        private System.Windows.Forms.TabPage PSO_SolutionTab;
        private System.Windows.Forms.RichTextBox PSO_SolutionRtb;
        private System.Windows.Forms.Button PSO_Create;
        private System.Windows.Forms.Button PSO_Reset;
        private System.Windows.Forms.Button PSO_WholeIteration;
        private System.Windows.Forms.PropertyGrid PropertyGrid;
        private System.Windows.Forms.TabControl COPTab;
        private System.Windows.Forms.TabPage GA_Tab;
        private System.Windows.Forms.CheckBox GA_StopByLimitedTimes;
        private System.Windows.Forms.CheckBox GA_RealTimeUpdate;
        private System.Windows.Forms.Button GA_WholeInteration;
        private System.Windows.Forms.Label PermutationBestSolutionLabel;
        private System.Windows.Forms.Button GA_Reset;
        private System.Windows.Forms.Button GA_OneInteration;
        private System.Windows.Forms.Label GABestObjectiveLabel;
        private System.Windows.Forms.Button GA_Create;
        private System.Windows.Forms.TextBox GA_BestObjectiveTextBox;
        private System.Windows.Forms.TabPage PSO_COPTab;
        private System.Windows.Forms.Button PSO_OneIteration;
        private System.Windows.Forms.CheckBox PSO_StopByLimitedTimes;
        private System.Windows.Forms.RichTextBox PSO_BestSolutionRichBox;
        private System.Windows.Forms.CheckBox PSO_UpdateInRealTime;
        private System.Windows.Forms.Label ACO_BestSolution;
        private System.Windows.Forms.Label PSOBestObjectiveLabel;
        private System.Windows.Forms.TextBox PSO_BestObjectiveTextBox;
        private System.Windows.Forms.RichTextBox GA_BestSolutionRichBox;
        private System.Windows.Forms.Label PSO_VelocityLabel;
        private System.Windows.Forms.Label PSO_SolutionLabel;
        private System.Windows.Forms.RichTextBox PSO_VelocityRtb;
        private System.Windows.Forms.TabPage GA_SolutionTab;
        private System.Windows.Forms.Label GA_ChromosomeRtbLabel;
        private System.Windows.Forms.Label GA_RTBLabel;
        private System.Windows.Forms.RichTextBox GA_ChromosomeRtb;
        private System.Windows.Forms.RichTextBox GA_SolutionRtb;
        private System.Windows.Forms.TabPage AFSO_Tab;
        private System.Windows.Forms.Button AFSO_OneIteration;
        private System.Windows.Forms.CheckBox AFSO_StopByLimitedTimes;
        private System.Windows.Forms.Button AFSO_WholeIteration;
        private System.Windows.Forms.RichTextBox AFSO_BestSolutionRichBox;
        private System.Windows.Forms.Button AFSO_Reset;
        private System.Windows.Forms.Button AFSO_Create;
        private System.Windows.Forms.CheckBox AFSO_UpdateInRealTime;
        private System.Windows.Forms.Label AFSO_BestSolution;
        private System.Windows.Forms.Label AFSOBestObjectiveLabel;
        private System.Windows.Forms.TextBox AFSO_BestObjectiveTextBox;
        private System.Windows.Forms.TabPage AFSO_SolutionTab;
        private System.Windows.Forms.Label AFSO_RTBLabel;
        private System.Windows.Forms.RichTextBox AFSO_SolutionRtb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox AFSO_BehaviorRtb;
        private System.Windows.Forms.CheckBox AFSO_Update_Parameters;
        private System.Windows.Forms.CheckBox PSO_UpdateParameters;
        private System.Windows.Forms.ComboBox PSO_ChaoticCombobox;
        private System.Windows.Forms.CheckBox PSO_ChaoticCheck;
        private System.Windows.Forms.CheckBox AFSO_PSOEnd;
        private System.Windows.Forms.TrackBar AFSO_PSOEnd_Bar;
        private System.Windows.Forms.Label AFSO_PSOEnd_Value;
        private System.Windows.Forms.TabControl ChartTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ResultChart;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart CompareChart;
        private System.Windows.Forms.TabPage AllRunTab;
        private System.Windows.Forms.CheckBox CPSO_LogisticCheck;
        private System.Windows.Forms.CheckBox IPSOCheck;
        private System.Windows.Forms.CheckBox TPSOCheck;
        private System.Windows.Forms.CheckBox AFSO_Check;
        private System.Windows.Forms.CheckBox GA_BinaryCheck;
        private System.Windows.Forms.CheckBox CPSO_CircleCheck;
        private System.Windows.Forms.CheckBox CPSO_GaussCheck;
        private System.Windows.Forms.CheckBox CPSO_SinusoidalCheck;
        private System.Windows.Forms.CheckBox CPSO_TentCheck;
        private System.Windows.Forms.Button AllSolveButton;
        private System.Windows.Forms.Button AllFor30Times;
        private System.Windows.Forms.TabPage All_Result_Tab;
        private System.Windows.Forms.RichTextBox AllResultRtbox;
        private System.Windows.Forms.CheckBox CPSO_DoubleButtonCheck;
    }
}

