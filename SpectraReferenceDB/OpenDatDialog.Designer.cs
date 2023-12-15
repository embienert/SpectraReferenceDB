namespace SpectraReferenceDB {
    partial class OpenDatDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SAutomatic = new System.Windows.Forms.RadioButton();
            this.SUser = new System.Windows.Forms.RadioButton();
            this.ENumHeaderRows = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BLoad = new System.Windows.Forms.Button();
            this.BCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ENumHeaderRows)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.SAutomatic, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SUser, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ENumHeaderRows, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(296, 88);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SAutomatic
            // 
            this.SAutomatic.AutoSize = true;
            this.SAutomatic.Checked = true;
            this.tableLayoutPanel1.SetColumnSpan(this.SAutomatic, 2);
            this.SAutomatic.Dock = System.Windows.Forms.DockStyle.Left;
            this.SAutomatic.Location = new System.Drawing.Point(3, 3);
            this.SAutomatic.Name = "SAutomatic";
            this.SAutomatic.Size = new System.Drawing.Size(72, 17);
            this.SAutomatic.TabIndex = 0;
            this.SAutomatic.TabStop = true;
            this.SAutomatic.Text = "Automatic";
            this.SAutomatic.UseVisualStyleBackColor = true;
            // 
            // SUser
            // 
            this.SUser.AutoSize = true;
            this.SUser.Dock = System.Windows.Forms.DockStyle.Left;
            this.SUser.Location = new System.Drawing.Point(3, 26);
            this.SUser.Name = "SUser";
            this.SUser.Size = new System.Drawing.Size(88, 20);
            this.SUser.TabIndex = 1;
            this.SUser.Text = "User-defined:";
            this.SUser.UseVisualStyleBackColor = true;
            this.SUser.CheckedChanged += new System.EventHandler(this.SUser_CheckedChanged);
            // 
            // ENumHeaderRows
            // 
            this.ENumHeaderRows.Dock = System.Windows.Forms.DockStyle.Right;
            this.ENumHeaderRows.Enabled = false;
            this.ENumHeaderRows.Location = new System.Drawing.Point(173, 26);
            this.ENumHeaderRows.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.ENumHeaderRows.Name = "ENumHeaderRows";
            this.ENumHeaderRows.Size = new System.Drawing.Size(120, 20);
            this.ENumHeaderRows.TabIndex = 2;
            this.ENumHeaderRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.BLoad, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BCancel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(93, 52);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 33);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // BLoad
            // 
            this.BLoad.AutoSize = true;
            this.BLoad.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BLoad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BLoad.Location = new System.Drawing.Point(3, 5);
            this.BLoad.Name = "BLoad";
            this.BLoad.Size = new System.Drawing.Size(94, 25);
            this.BLoad.TabIndex = 0;
            this.BLoad.Text = "Load";
            this.BLoad.UseVisualStyleBackColor = true;
            // 
            // BCancel
            // 
            this.BCancel.AutoSize = true;
            this.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BCancel.Location = new System.Drawing.Point(103, 5);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(94, 25);
            this.BCancel.TabIndex = 1;
            this.BCancel.Text = "Cancel";
            this.BCancel.UseVisualStyleBackColor = true;
            // 
            // OpenDatDialog
            // 
            this.AcceptButton = this.BLoad;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCancel;
            this.ClientSize = new System.Drawing.Size(306, 98);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "OpenDatDialog";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Select number of header rows";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ENumHeaderRows)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton SAutomatic;
        private System.Windows.Forms.RadioButton SUser;
        private System.Windows.Forms.NumericUpDown ENumHeaderRows;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button BLoad;
        private System.Windows.Forms.Button BCancel;
    }
}