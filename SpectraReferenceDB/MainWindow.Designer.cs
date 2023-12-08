namespace SpectraReferenceDB
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BoxSearch = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ESearch = new System.Windows.Forms.TextBox();
            this.BSearch = new System.Windows.Forms.Button();
            this.LNumResults = new System.Windows.Forms.Label();
            this.BoxResults = new System.Windows.Forms.GroupBox();
            this.BoxData = new System.Windows.Forms.GroupBox();
            this.ChartReference = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BReferenceEdit = new System.Windows.Forms.Button();
            this.CBReferenceEdit = new System.Windows.Forms.CheckBox();
            this.BReferenceNew = new System.Windows.Forms.Button();
            this.EReferenceFile = new System.Windows.Forms.TextBox();
            this.PReferenceRemarksContainer = new System.Windows.Forms.Panel();
            this.EReferenceRemarks = new System.Windows.Forms.RichTextBox();
            this.PReferenceMetaContainer = new System.Windows.Forms.Panel();
            this.EReferenceMeta = new System.Windows.Forms.RichTextBox();
            this.EReferenceConditions = new System.Windows.Forms.TextBox();
            this.EReferenceDevice = new System.Windows.Forms.TextBox();
            this.EReferenceInserter = new System.Windows.Forms.TextBox();
            this.EReferenceOperator = new System.Windows.Forms.TextBox();
            this.EReferenceName = new System.Windows.Forms.TextBox();
            this.LReferenceRemarks = new System.Windows.Forms.Label();
            this.LReferenceMeta = new System.Windows.Forms.Label();
            this.LReferenceFile = new System.Windows.Forms.Label();
            this.LReferenceConditions = new System.Windows.Forms.Label();
            this.LReferenceDevice = new System.Windows.Forms.Label();
            this.LReferenceInserter = new System.Windows.Forms.Label();
            this.LReferenceOperator = new System.Windows.Forms.Label();
            this.LReferenceDate = new System.Windows.Forms.Label();
            this.LReferenceName = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.EReferenceDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.BoxSearch.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.BoxResults.SuspendLayout();
            this.BoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartReference)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.PReferenceRemarksContainer.SuspendLayout();
            this.PReferenceMetaContainer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.BoxSearch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BoxResults, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BoxData, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ChartReference, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BoxSearch
            // 
            this.BoxSearch.Controls.Add(this.tableLayoutPanel3);
            this.BoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoxSearch.Location = new System.Drawing.Point(3, 3);
            this.BoxSearch.Name = "BoxSearch";
            this.BoxSearch.Size = new System.Drawing.Size(386, 69);
            this.BoxSearch.TabIndex = 0;
            this.BoxSearch.TabStop = false;
            this.BoxSearch.Text = "Search";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.73684F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.26316F));
            this.tableLayoutPanel3.Controls.Add(this.ESearch, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.BSearch, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.LNumResults, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(380, 48);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // ESearch
            // 
            this.ESearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ESearch.Location = new System.Drawing.Point(3, 3);
            this.ESearch.Name = "ESearch";
            this.ESearch.Size = new System.Drawing.Size(258, 22);
            this.ESearch.TabIndex = 0;
            // 
            // BSearch
            // 
            this.BSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BSearch.Location = new System.Drawing.Point(267, 3);
            this.BSearch.Name = "BSearch";
            this.BSearch.Size = new System.Drawing.Size(110, 23);
            this.BSearch.TabIndex = 1;
            this.BSearch.Text = "Search";
            this.BSearch.UseVisualStyleBackColor = true;
            // 
            // LNumResults
            // 
            this.LNumResults.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.LNumResults, 2);
            this.LNumResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.LNumResults.Location = new System.Drawing.Point(3, 29);
            this.LNumResults.Name = "LNumResults";
            this.LNumResults.Size = new System.Drawing.Size(374, 13);
            this.LNumResults.TabIndex = 2;
            this.LNumResults.Text = "# Results";
            // 
            // BoxResults
            // 
            this.BoxResults.Controls.Add(this.dataGridView1);
            this.BoxResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoxResults.Location = new System.Drawing.Point(3, 78);
            this.BoxResults.Name = "BoxResults";
            this.tableLayoutPanel1.SetRowSpan(this.BoxResults, 2);
            this.BoxResults.Size = new System.Drawing.Size(386, 480);
            this.BoxResults.TabIndex = 1;
            this.BoxResults.TabStop = false;
            this.BoxResults.Text = "References";
            // 
            // BoxData
            // 
            this.BoxData.AutoSize = true;
            this.BoxData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BoxData.Controls.Add(this.tableLayoutPanel2);
            this.BoxData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoxData.Location = new System.Drawing.Point(395, 3);
            this.BoxData.MinimumSize = new System.Drawing.Size(0, 276);
            this.BoxData.Name = "BoxData";
            this.tableLayoutPanel1.SetRowSpan(this.BoxData, 2);
            this.BoxData.Size = new System.Drawing.Size(386, 312);
            this.BoxData.TabIndex = 2;
            this.BoxData.TabStop = false;
            this.BoxData.Text = "Reference Data";
            // 
            // ChartReference
            // 
            chartArea8.Name = "ChartArea1";
            this.ChartReference.ChartAreas.Add(chartArea8);
            this.ChartReference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartReference.Location = new System.Drawing.Point(395, 321);
            this.ChartReference.MinimumSize = new System.Drawing.Size(386, 237);
            this.ChartReference.Name = "ChartReference";
            series8.ChartArea = "ChartArea1";
            series8.Name = "Series1";
            this.ChartReference.Series.Add(series8);
            this.ChartReference.Size = new System.Drawing.Size(386, 237);
            this.ChartReference.TabIndex = 3;
            this.ChartReference.Text = "Reference Data";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.CBReferenceEdit, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.BReferenceEdit, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(125, 263);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(250, 23);
            this.tableLayoutPanel4.TabIndex = 23;
            // 
            // BReferenceEdit
            // 
            this.BReferenceEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BReferenceEdit.Enabled = false;
            this.BReferenceEdit.Location = new System.Drawing.Point(126, 0);
            this.BReferenceEdit.Margin = new System.Windows.Forms.Padding(0);
            this.BReferenceEdit.Name = "BReferenceEdit";
            this.BReferenceEdit.Size = new System.Drawing.Size(124, 23);
            this.BReferenceEdit.TabIndex = 10;
            this.BReferenceEdit.Text = "Save Changes";
            this.BReferenceEdit.UseVisualStyleBackColor = true;
            // 
            // CBReferenceEdit
            // 
            this.CBReferenceEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBReferenceEdit.Location = new System.Drawing.Point(3, 3);
            this.CBReferenceEdit.Name = "CBReferenceEdit";
            this.CBReferenceEdit.Size = new System.Drawing.Size(120, 17);
            this.CBReferenceEdit.TabIndex = 0;
            this.CBReferenceEdit.Text = "Enable Editing";
            this.CBReferenceEdit.UseVisualStyleBackColor = true;
            this.CBReferenceEdit.CheckedChanged += new System.EventHandler(this.CBReferenceEdit_CheckedChanged);
            // 
            // BReferenceNew
            // 
            this.BReferenceNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BReferenceNew.Location = new System.Drawing.Point(5, 263);
            this.BReferenceNew.Name = "BReferenceNew";
            this.BReferenceNew.Size = new System.Drawing.Size(114, 23);
            this.BReferenceNew.TabIndex = 0;
            this.BReferenceNew.Text = "New Reference";
            this.BReferenceNew.UseVisualStyleBackColor = true;
            this.BReferenceNew.Click += new System.EventHandler(this.BReferenceNew_Click);
            // 
            // EReferenceFile
            // 
            this.EReferenceFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceFile.Location = new System.Drawing.Point(125, 173);
            this.EReferenceFile.Name = "EReferenceFile";
            this.EReferenceFile.ReadOnly = true;
            this.EReferenceFile.Size = new System.Drawing.Size(250, 22);
            this.EReferenceFile.TabIndex = 7;
            // 
            // PReferenceRemarksContainer
            // 
            this.PReferenceRemarksContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PReferenceRemarksContainer.Controls.Add(this.EReferenceRemarks);
            this.PReferenceRemarksContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PReferenceRemarksContainer.Location = new System.Drawing.Point(125, 201);
            this.PReferenceRemarksContainer.Name = "PReferenceRemarksContainer";
            this.PReferenceRemarksContainer.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.PReferenceRemarksContainer.Size = new System.Drawing.Size(250, 25);
            this.PReferenceRemarksContainer.TabIndex = 8;
            // 
            // EReferenceRemarks
            // 
            this.EReferenceRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EReferenceRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceRemarks.Location = new System.Drawing.Point(1, 2);
            this.EReferenceRemarks.Margin = new System.Windows.Forms.Padding(0);
            this.EReferenceRemarks.Name = "EReferenceRemarks";
            this.EReferenceRemarks.Size = new System.Drawing.Size(246, 19);
            this.EReferenceRemarks.TabIndex = 8;
            this.EReferenceRemarks.Text = "";
            // 
            // PReferenceMetaContainer
            // 
            this.PReferenceMetaContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PReferenceMetaContainer.Controls.Add(this.EReferenceMeta);
            this.PReferenceMetaContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PReferenceMetaContainer.Location = new System.Drawing.Point(125, 232);
            this.PReferenceMetaContainer.Name = "PReferenceMetaContainer";
            this.PReferenceMetaContainer.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.PReferenceMetaContainer.Size = new System.Drawing.Size(250, 25);
            this.PReferenceMetaContainer.TabIndex = 9;
            // 
            // EReferenceMeta
            // 
            this.EReferenceMeta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EReferenceMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceMeta.Location = new System.Drawing.Point(1, 2);
            this.EReferenceMeta.Margin = new System.Windows.Forms.Padding(0);
            this.EReferenceMeta.Name = "EReferenceMeta";
            this.EReferenceMeta.Size = new System.Drawing.Size(246, 19);
            this.EReferenceMeta.TabIndex = 9;
            this.EReferenceMeta.Text = "";
            // 
            // EReferenceConditions
            // 
            this.EReferenceConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceConditions.Location = new System.Drawing.Point(125, 145);
            this.EReferenceConditions.Name = "EReferenceConditions";
            this.EReferenceConditions.ReadOnly = true;
            this.EReferenceConditions.Size = new System.Drawing.Size(250, 22);
            this.EReferenceConditions.TabIndex = 6;
            // 
            // EReferenceDevice
            // 
            this.EReferenceDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceDevice.Location = new System.Drawing.Point(125, 117);
            this.EReferenceDevice.Name = "EReferenceDevice";
            this.EReferenceDevice.ReadOnly = true;
            this.EReferenceDevice.Size = new System.Drawing.Size(250, 22);
            this.EReferenceDevice.TabIndex = 5;
            // 
            // EReferenceInserter
            // 
            this.EReferenceInserter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceInserter.Location = new System.Drawing.Point(125, 89);
            this.EReferenceInserter.Name = "EReferenceInserter";
            this.EReferenceInserter.ReadOnly = true;
            this.EReferenceInserter.Size = new System.Drawing.Size(250, 22);
            this.EReferenceInserter.TabIndex = 4;
            // 
            // EReferenceOperator
            // 
            this.EReferenceOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceOperator.Location = new System.Drawing.Point(125, 61);
            this.EReferenceOperator.Multiline = true;
            this.EReferenceOperator.Name = "EReferenceOperator";
            this.EReferenceOperator.ReadOnly = true;
            this.EReferenceOperator.Size = new System.Drawing.Size(250, 22);
            this.EReferenceOperator.TabIndex = 3;
            // 
            // EReferenceName
            // 
            this.EReferenceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceName.Location = new System.Drawing.Point(125, 5);
            this.EReferenceName.Name = "EReferenceName";
            this.EReferenceName.ReadOnly = true;
            this.EReferenceName.Size = new System.Drawing.Size(250, 22);
            this.EReferenceName.TabIndex = 1;
            // 
            // LReferenceRemarks
            // 
            this.LReferenceRemarks.AutoSize = true;
            this.LReferenceRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LReferenceRemarks.Location = new System.Drawing.Point(7, 203);
            this.LReferenceRemarks.Margin = new System.Windows.Forms.Padding(5);
            this.LReferenceRemarks.Name = "LReferenceRemarks";
            this.LReferenceRemarks.Size = new System.Drawing.Size(110, 21);
            this.LReferenceRemarks.TabIndex = 0;
            this.LReferenceRemarks.Text = "Remarks";
            // 
            // LReferenceMeta
            // 
            this.LReferenceMeta.AutoSize = true;
            this.LReferenceMeta.Location = new System.Drawing.Point(7, 234);
            this.LReferenceMeta.Margin = new System.Windows.Forms.Padding(5);
            this.LReferenceMeta.Name = "LReferenceMeta";
            this.LReferenceMeta.Size = new System.Drawing.Size(56, 13);
            this.LReferenceMeta.TabIndex = 0;
            this.LReferenceMeta.Text = "Metadata";
            // 
            // LReferenceFile
            // 
            this.LReferenceFile.AutoSize = true;
            this.LReferenceFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LReferenceFile.Location = new System.Drawing.Point(7, 175);
            this.LReferenceFile.Margin = new System.Windows.Forms.Padding(5);
            this.LReferenceFile.Name = "LReferenceFile";
            this.LReferenceFile.Size = new System.Drawing.Size(110, 18);
            this.LReferenceFile.TabIndex = 0;
            this.LReferenceFile.Text = "File";
            // 
            // LReferenceConditions
            // 
            this.LReferenceConditions.AutoSize = true;
            this.LReferenceConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LReferenceConditions.Location = new System.Drawing.Point(7, 147);
            this.LReferenceConditions.Margin = new System.Windows.Forms.Padding(5);
            this.LReferenceConditions.Name = "LReferenceConditions";
            this.LReferenceConditions.Size = new System.Drawing.Size(110, 18);
            this.LReferenceConditions.TabIndex = 0;
            this.LReferenceConditions.Text = "Conditions";
            // 
            // LReferenceDevice
            // 
            this.LReferenceDevice.AutoSize = true;
            this.LReferenceDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LReferenceDevice.Location = new System.Drawing.Point(7, 119);
            this.LReferenceDevice.Margin = new System.Windows.Forms.Padding(5);
            this.LReferenceDevice.Name = "LReferenceDevice";
            this.LReferenceDevice.Size = new System.Drawing.Size(110, 18);
            this.LReferenceDevice.TabIndex = 0;
            this.LReferenceDevice.Text = "Device Name";
            // 
            // LReferenceInserter
            // 
            this.LReferenceInserter.AutoSize = true;
            this.LReferenceInserter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LReferenceInserter.Location = new System.Drawing.Point(7, 91);
            this.LReferenceInserter.Margin = new System.Windows.Forms.Padding(5);
            this.LReferenceInserter.Name = "LReferenceInserter";
            this.LReferenceInserter.Size = new System.Drawing.Size(110, 18);
            this.LReferenceInserter.TabIndex = 0;
            this.LReferenceInserter.Text = "Inserted By";
            // 
            // LReferenceOperator
            // 
            this.LReferenceOperator.AutoSize = true;
            this.LReferenceOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LReferenceOperator.Location = new System.Drawing.Point(7, 63);
            this.LReferenceOperator.Margin = new System.Windows.Forms.Padding(5);
            this.LReferenceOperator.Name = "LReferenceOperator";
            this.LReferenceOperator.Size = new System.Drawing.Size(110, 18);
            this.LReferenceOperator.TabIndex = 0;
            this.LReferenceOperator.Text = "Operator";
            // 
            // LReferenceDate
            // 
            this.LReferenceDate.AutoSize = true;
            this.LReferenceDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LReferenceDate.Location = new System.Drawing.Point(7, 35);
            this.LReferenceDate.Margin = new System.Windows.Forms.Padding(5);
            this.LReferenceDate.Name = "LReferenceDate";
            this.LReferenceDate.Size = new System.Drawing.Size(110, 18);
            this.LReferenceDate.TabIndex = 0;
            this.LReferenceDate.Text = "Date";
            // 
            // LReferenceName
            // 
            this.LReferenceName.AutoSize = true;
            this.LReferenceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LReferenceName.Location = new System.Drawing.Point(7, 7);
            this.LReferenceName.Margin = new System.Windows.Forms.Padding(5);
            this.LReferenceName.Name = "LReferenceName";
            this.LReferenceName.Size = new System.Drawing.Size(110, 18);
            this.LReferenceName.TabIndex = 0;
            this.LReferenceName.Text = "Name";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.LReferenceName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.LReferenceDate, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.LReferenceOperator, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.LReferenceInserter, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.LReferenceDevice, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.LReferenceConditions, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.LReferenceFile, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.LReferenceMeta, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.LReferenceRemarks, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceOperator, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceInserter, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceDevice, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceConditions, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.PReferenceMetaContainer, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.PReferenceRemarksContainer, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceFile, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.BReferenceNew, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceDate, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.RowCount = 10;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(380, 291);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // EReferenceDate
            // 
            this.EReferenceDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceDate.Enabled = false;
            this.EReferenceDate.Location = new System.Drawing.Point(125, 33);
            this.EReferenceDate.Name = "EReferenceDate";
            this.EReferenceDate.Size = new System.Drawing.Size(250, 22);
            this.EReferenceDate.TabIndex = 24;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.date,
            this.operatedBy,
            this.insertedBy,
            this.device});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(380, 459);
            this.dataGridView1.TabIndex = 0;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.id.HeaderText = "#";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 39;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 61;
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 56;
            // 
            // operatedBy
            // 
            this.operatedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.operatedBy.HeaderText = "Operator";
            this.operatedBy.Name = "operatedBy";
            this.operatedBy.ReadOnly = true;
            this.operatedBy.Width = 79;
            // 
            // insertedBy
            // 
            this.insertedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.insertedBy.HeaderText = "Inserted By";
            this.insertedBy.Name = "insertedBy";
            this.insertedBy.ReadOnly = true;
            this.insertedBy.Width = 88;
            // 
            // device
            // 
            this.device.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.device.HeaderText = "Device";
            this.device.Name = "device";
            this.device.ReadOnly = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.Text = "Spectra Reference Database";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.BoxSearch.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.BoxResults.ResumeLayout(false);
            this.BoxData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartReference)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.PReferenceRemarksContainer.ResumeLayout(false);
            this.PReferenceMetaContainer.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox BoxSearch;
        private System.Windows.Forms.GroupBox BoxResults;
        private System.Windows.Forms.GroupBox BoxData;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartReference;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox ESearch;
        private System.Windows.Forms.Button BSearch;
        private System.Windows.Forms.Label LNumResults;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label LReferenceName;
        private System.Windows.Forms.Label LReferenceDate;
        private System.Windows.Forms.Label LReferenceOperator;
        private System.Windows.Forms.Label LReferenceInserter;
        private System.Windows.Forms.Label LReferenceDevice;
        private System.Windows.Forms.Label LReferenceConditions;
        private System.Windows.Forms.Label LReferenceFile;
        private System.Windows.Forms.Label LReferenceMeta;
        private System.Windows.Forms.Label LReferenceRemarks;
        private System.Windows.Forms.TextBox EReferenceName;
        private System.Windows.Forms.TextBox EReferenceOperator;
        private System.Windows.Forms.TextBox EReferenceInserter;
        private System.Windows.Forms.TextBox EReferenceDevice;
        private System.Windows.Forms.TextBox EReferenceConditions;
        private System.Windows.Forms.Panel PReferenceMetaContainer;
        private System.Windows.Forms.RichTextBox EReferenceMeta;
        private System.Windows.Forms.Panel PReferenceRemarksContainer;
        private System.Windows.Forms.RichTextBox EReferenceRemarks;
        private System.Windows.Forms.TextBox EReferenceFile;
        private System.Windows.Forms.Button BReferenceNew;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.CheckBox CBReferenceEdit;
        private System.Windows.Forms.Button BReferenceEdit;
        private System.Windows.Forms.DateTimePicker EReferenceDate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn operatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn device;
    }
}

