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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BoxSearch = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ESearch = new System.Windows.Forms.TextBox();
            this.BSearch = new System.Windows.Forms.Button();
            this.BoxResults = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.PReferenceContainer = new System.Windows.Forms.Panel();
            this.TReferences = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.insertedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LNumResults = new System.Windows.Forms.Label();
            this.BoxData = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LReferenceName = new System.Windows.Forms.Label();
            this.LReferenceDate = new System.Windows.Forms.Label();
            this.LReferenceOperator = new System.Windows.Forms.Label();
            this.LReferenceInserter = new System.Windows.Forms.Label();
            this.LReferenceDevice = new System.Windows.Forms.Label();
            this.LReferenceConditions = new System.Windows.Forms.Label();
            this.LReferenceFile = new System.Windows.Forms.Label();
            this.LReferenceMeta = new System.Windows.Forms.Label();
            this.LReferenceRemarks = new System.Windows.Forms.Label();
            this.EReferenceName = new System.Windows.Forms.TextBox();
            this.EReferenceInserter = new System.Windows.Forms.TextBox();
            this.EReferenceDevice = new System.Windows.Forms.TextBox();
            this.EReferenceConditions = new System.Windows.Forms.TextBox();
            this.EReferenceFile = new System.Windows.Forms.TextBox();
            this.BReferenceNew = new System.Windows.Forms.Button();
            this.PReferenceEditControlContainer = new System.Windows.Forms.TableLayoutPanel();
            this.CBReferenceEdit = new System.Windows.Forms.CheckBox();
            this.BReferenceEdit = new System.Windows.Forms.Button();
            this.EReferenceDate = new System.Windows.Forms.DateTimePicker();
            this.EReferenceOperator = new System.Windows.Forms.TextBox();
            this.ChartReference = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.EReferenceRemarks = new System.Windows.Forms.TextBox();
            this.EReferenceMeta = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.BoxSearch.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.BoxResults.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.PReferenceContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TReferences)).BeginInit();
            this.BoxData.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.PReferenceEditControlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartReference)).BeginInit();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
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
            this.BoxSearch.Size = new System.Drawing.Size(386, 56);
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
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(380, 35);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // ESearch
            // 
            this.ESearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ESearch.Location = new System.Drawing.Point(3, 3);
            this.ESearch.Name = "ESearch";
            this.ESearch.Size = new System.Drawing.Size(258, 22);
            this.ESearch.TabIndex = 0;
            this.ESearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ESearch_KeyDown);
            // 
            // BSearch
            // 
            this.BSearch.AutoSize = true;
            this.BSearch.Location = new System.Drawing.Point(267, 3);
            this.BSearch.Name = "BSearch";
            this.BSearch.Size = new System.Drawing.Size(110, 23);
            this.BSearch.TabIndex = 1;
            this.BSearch.Text = "Search";
            this.BSearch.UseVisualStyleBackColor = true;
            this.BSearch.Click += new System.EventHandler(this.BSearch_Click);
            // 
            // BoxResults
            // 
            this.BoxResults.Controls.Add(this.tableLayoutPanel5);
            this.BoxResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoxResults.Location = new System.Drawing.Point(3, 65);
            this.BoxResults.Name = "BoxResults";
            this.BoxResults.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.SetRowSpan(this.BoxResults, 2);
            this.BoxResults.Size = new System.Drawing.Size(386, 493);
            this.BoxResults.TabIndex = 1;
            this.BoxResults.TabStop = false;
            this.BoxResults.Text = "References";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.PReferenceContainer, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.LNumResults, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 21);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(374, 466);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // PReferenceContainer
            // 
            this.PReferenceContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel5.SetColumnSpan(this.PReferenceContainer, 2);
            this.PReferenceContainer.Controls.Add(this.TReferences);
            this.PReferenceContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PReferenceContainer.Location = new System.Drawing.Point(0, 13);
            this.PReferenceContainer.Margin = new System.Windows.Forms.Padding(0);
            this.PReferenceContainer.Name = "PReferenceContainer";
            this.PReferenceContainer.Size = new System.Drawing.Size(374, 453);
            this.PReferenceContainer.TabIndex = 1;
            // 
            // TReferences
            // 
            this.TReferences.AllowUserToAddRows = false;
            this.TReferences.AllowUserToDeleteRows = false;
            this.TReferences.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TReferences.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TReferences.BackgroundColor = System.Drawing.SystemColors.Window;
            this.TReferences.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TReferences.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.TReferences.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TReferences.ColumnHeadersHeight = 30;
            this.TReferences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.TReferences.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.date,
            this.operatedBy,
            this.insertedBy,
            this.device});
            this.TReferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TReferences.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TReferences.GridColor = System.Drawing.SystemColors.ControlLight;
            this.TReferences.Location = new System.Drawing.Point(0, 0);
            this.TReferences.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.TReferences.MultiSelect = false;
            this.TReferences.Name = "TReferences";
            this.TReferences.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.TReferences.RowHeadersVisible = false;
            this.TReferences.RowTemplate.Height = 25;
            this.TReferences.RowTemplate.ReadOnly = true;
            this.TReferences.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TReferences.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TReferences.ShowRowErrors = false;
            this.TReferences.Size = new System.Drawing.Size(372, 451);
            this.TReferences.TabIndex = 0;
            this.TReferences.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TReferences_CellClick);
            this.TReferences.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TReferences_KeyDown);
            this.TReferences.MouseEnter += new System.EventHandler(this.TReferences_MouseEnter);
            this.TReferences.MouseLeave += new System.EventHandler(this.TReferences_MouseLeave);
            this.TReferences.Resize += new System.EventHandler(this.TReferences_Resize);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "#";
            this.id.Name = "id";
            this.id.ToolTipText = "Reference ID in Database";
            this.id.Width = 39;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.Width = 61;
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.date.HeaderText = "Measurement Date";
            this.date.Name = "date";
            this.date.Width = 118;
            // 
            // operatedBy
            // 
            this.operatedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.operatedBy.HeaderText = "Operator";
            this.operatedBy.Name = "operatedBy";
            this.operatedBy.Width = 79;
            // 
            // insertedBy
            // 
            this.insertedBy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.insertedBy.HeaderText = "Inserted By";
            this.insertedBy.Name = "insertedBy";
            this.insertedBy.Width = 81;
            // 
            // device
            // 
            this.device.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.device.HeaderText = "Device";
            this.device.Name = "device";
            // 
            // LNumResults
            // 
            this.LNumResults.AutoSize = true;
            this.LNumResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LNumResults.Location = new System.Drawing.Point(187, 0);
            this.LNumResults.Margin = new System.Windows.Forms.Padding(0);
            this.LNumResults.Name = "LNumResults";
            this.LNumResults.Size = new System.Drawing.Size(187, 13);
            this.LNumResults.TabIndex = 2;
            this.LNumResults.Text = "# Results";
            this.LNumResults.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.BoxData.Size = new System.Drawing.Size(386, 305);
            this.BoxData.TabIndex = 2;
            this.BoxData.TabStop = false;
            this.BoxData.Text = "Reference Data";
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
            this.tableLayoutPanel2.Controls.Add(this.EReferenceInserter, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceDevice, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceConditions, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceFile, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.BReferenceNew, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.PReferenceEditControlContainer, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceDate, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceOperator, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceRemarks, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.EReferenceMeta, 1, 8);
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
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(380, 284);
            this.tableLayoutPanel2.TabIndex = 0;
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
            // LReferenceMeta
            // 
            this.LReferenceMeta.AutoSize = true;
            this.LReferenceMeta.Location = new System.Drawing.Point(7, 229);
            this.LReferenceMeta.Margin = new System.Windows.Forms.Padding(5);
            this.LReferenceMeta.Name = "LReferenceMeta";
            this.LReferenceMeta.Size = new System.Drawing.Size(56, 13);
            this.LReferenceMeta.TabIndex = 0;
            this.LReferenceMeta.Text = "Metadata";
            // 
            // LReferenceRemarks
            // 
            this.LReferenceRemarks.AutoSize = true;
            this.LReferenceRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LReferenceRemarks.Location = new System.Drawing.Point(7, 203);
            this.LReferenceRemarks.Margin = new System.Windows.Forms.Padding(5);
            this.LReferenceRemarks.Name = "LReferenceRemarks";
            this.LReferenceRemarks.Size = new System.Drawing.Size(110, 16);
            this.LReferenceRemarks.TabIndex = 0;
            this.LReferenceRemarks.Text = "Remarks";
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
            // EReferenceInserter
            // 
            this.EReferenceInserter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceInserter.Location = new System.Drawing.Point(125, 89);
            this.EReferenceInserter.Name = "EReferenceInserter";
            this.EReferenceInserter.ReadOnly = true;
            this.EReferenceInserter.Size = new System.Drawing.Size(250, 22);
            this.EReferenceInserter.TabIndex = 4;
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
            // EReferenceConditions
            // 
            this.EReferenceConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceConditions.Location = new System.Drawing.Point(125, 145);
            this.EReferenceConditions.Name = "EReferenceConditions";
            this.EReferenceConditions.ReadOnly = true;
            this.EReferenceConditions.Size = new System.Drawing.Size(250, 22);
            this.EReferenceConditions.TabIndex = 6;
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
            // BReferenceNew
            // 
            this.BReferenceNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BReferenceNew.Location = new System.Drawing.Point(5, 253);
            this.BReferenceNew.Name = "BReferenceNew";
            this.BReferenceNew.Size = new System.Drawing.Size(114, 26);
            this.BReferenceNew.TabIndex = 0;
            this.BReferenceNew.Text = "New Reference";
            this.BReferenceNew.UseVisualStyleBackColor = true;
            this.BReferenceNew.Click += new System.EventHandler(this.BReferenceNew_Click);
            // 
            // PReferenceEditControlContainer
            // 
            this.PReferenceEditControlContainer.AutoSize = true;
            this.PReferenceEditControlContainer.ColumnCount = 2;
            this.PReferenceEditControlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.PReferenceEditControlContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PReferenceEditControlContainer.Controls.Add(this.CBReferenceEdit, 0, 0);
            this.PReferenceEditControlContainer.Controls.Add(this.BReferenceEdit, 1, 0);
            this.PReferenceEditControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PReferenceEditControlContainer.Enabled = false;
            this.PReferenceEditControlContainer.Location = new System.Drawing.Point(125, 253);
            this.PReferenceEditControlContainer.Name = "PReferenceEditControlContainer";
            this.PReferenceEditControlContainer.RowCount = 1;
            this.PReferenceEditControlContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PReferenceEditControlContainer.Size = new System.Drawing.Size(250, 26);
            this.PReferenceEditControlContainer.TabIndex = 23;
            // 
            // CBReferenceEdit
            // 
            this.CBReferenceEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBReferenceEdit.Location = new System.Drawing.Point(3, 3);
            this.CBReferenceEdit.Name = "CBReferenceEdit";
            this.CBReferenceEdit.Size = new System.Drawing.Size(120, 20);
            this.CBReferenceEdit.TabIndex = 0;
            this.CBReferenceEdit.Text = "Enable Editing";
            this.CBReferenceEdit.UseVisualStyleBackColor = true;
            this.CBReferenceEdit.CheckedChanged += new System.EventHandler(this.CBReferenceEdit_CheckedChanged);
            // 
            // BReferenceEdit
            // 
            this.BReferenceEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BReferenceEdit.Location = new System.Drawing.Point(126, 0);
            this.BReferenceEdit.Margin = new System.Windows.Forms.Padding(0);
            this.BReferenceEdit.Name = "BReferenceEdit";
            this.BReferenceEdit.Size = new System.Drawing.Size(124, 26);
            this.BReferenceEdit.TabIndex = 10;
            this.BReferenceEdit.Text = "Delete Entry";
            this.BReferenceEdit.UseVisualStyleBackColor = true;
            this.BReferenceEdit.Click += new System.EventHandler(this.BReferenceEdit_Click);
            // 
            // EReferenceDate
            // 
            this.EReferenceDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceDate.Enabled = false;
            this.EReferenceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EReferenceDate.Location = new System.Drawing.Point(125, 33);
            this.EReferenceDate.Name = "EReferenceDate";
            this.EReferenceDate.Size = new System.Drawing.Size(250, 22);
            this.EReferenceDate.TabIndex = 24;
            // 
            // EReferenceOperator
            // 
            this.EReferenceOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceOperator.Location = new System.Drawing.Point(125, 61);
            this.EReferenceOperator.Name = "EReferenceOperator";
            this.EReferenceOperator.ReadOnly = true;
            this.EReferenceOperator.Size = new System.Drawing.Size(250, 22);
            this.EReferenceOperator.TabIndex = 25;
            // 
            // ChartReference
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartReference.ChartAreas.Add(chartArea2);
            this.ChartReference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartReference.Location = new System.Drawing.Point(395, 314);
            this.ChartReference.MinimumSize = new System.Drawing.Size(386, 237);
            this.ChartReference.Name = "ChartReference";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.ChartReference.Series.Add(series2);
            this.ChartReference.Size = new System.Drawing.Size(386, 244);
            this.ChartReference.TabIndex = 3;
            this.ChartReference.Text = "Reference Data";
            this.ChartReference.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChartReference_KeyDown);
            this.ChartReference.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChartReference_KeyUp);
            this.ChartReference.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChartReference_MouseClick);
            this.ChartReference.MouseEnter += new System.EventHandler(this.ChartReference_MouseEnter);
            this.ChartReference.MouseLeave += new System.EventHandler(this.ChartReference_MouseLeave);
            this.ChartReference.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChartReference_MouseMove);
            this.ChartReference.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ChartReference_PreviewKeyDown);
            // 
            // EReferenceRemarks
            // 
            this.EReferenceRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceRemarks.Location = new System.Drawing.Point(125, 201);
            this.EReferenceRemarks.Multiline = true;
            this.EReferenceRemarks.Name = "EReferenceRemarks";
            this.EReferenceRemarks.ReadOnly = true;
            this.EReferenceRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EReferenceRemarks.Size = new System.Drawing.Size(250, 20);
            this.EReferenceRemarks.TabIndex = 8;
            this.EReferenceRemarks.MouseEnter += new System.EventHandler(this.EReferenceRemarks_MouseEnter);
            this.EReferenceRemarks.MouseLeave += new System.EventHandler(this.EReferenceRemarks_MouseLeave);
            // 
            // EReferenceMeta
            // 
            this.EReferenceMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EReferenceMeta.Location = new System.Drawing.Point(125, 227);
            this.EReferenceMeta.Multiline = true;
            this.EReferenceMeta.Name = "EReferenceMeta";
            this.EReferenceMeta.ReadOnly = true;
            this.EReferenceMeta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.EReferenceMeta.Size = new System.Drawing.Size(250, 20);
            this.EReferenceMeta.TabIndex = 9;
            this.EReferenceMeta.MouseEnter += new System.EventHandler(this.EReferenceMeta_MouseEnter);
            this.EReferenceMeta.MouseLeave += new System.EventHandler(this.EReferenceMeta_MouseLeave);
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
            this.HelpButton = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.Text = "Spectra Reference Database v1.1.1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.BoxSearch.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.BoxResults.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.PReferenceContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TReferences)).EndInit();
            this.BoxData.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.PReferenceEditControlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChartReference)).EndInit();
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
        private System.Windows.Forms.TextBox EReferenceInserter;
        private System.Windows.Forms.TextBox EReferenceDevice;
        private System.Windows.Forms.TextBox EReferenceConditions;
        private System.Windows.Forms.TextBox EReferenceFile;
        private System.Windows.Forms.Button BReferenceNew;
        private System.Windows.Forms.TableLayoutPanel PReferenceEditControlContainer;
        private System.Windows.Forms.CheckBox CBReferenceEdit;
        private System.Windows.Forms.Button BReferenceEdit;
        private System.Windows.Forms.DateTimePicker EReferenceDate;
        private System.Windows.Forms.DataGridView TReferences;
        private System.Windows.Forms.Panel PReferenceContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn operatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn insertedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn device;
        private System.Windows.Forms.TextBox EReferenceOperator;
        private System.Windows.Forms.TextBox EReferenceRemarks;
        private System.Windows.Forms.TextBox EReferenceMeta;
    }
}

