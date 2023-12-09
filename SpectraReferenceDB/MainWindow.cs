using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectraReferenceDB
{
    public partial class MainWindow : Form
    {
        private Reference currentReference;
        private bool currentReferenceIsEdit;

        private Database db;
        private string databasePath = @"C:\Users\marti\source\repos\SpectraReferenceDB\SpectraReferenceDB\data\references.db";

        public MainWindow()
        {
            InitializeComponent();

            //this.db = new Database(this.databasePath);

            EReferenceRemarks.ReadOnly = true;
            EReferenceMeta.ReadOnly = true;

            TReferences_Resize(null, null);
        }


        private void showError(string message) {
            if (message != "") {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                MessageBox.Show("An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBReferenceEdit_CheckedChanged(object sender, EventArgs e) {
            BReferenceEdit.Enabled = CBReferenceEdit.Checked;

            EReferenceName.ReadOnly = !CBReferenceEdit.Checked;
            EReferenceDate.Enabled = CBReferenceEdit.Checked;
            EReferenceOperator.ReadOnly = !CBReferenceEdit.Checked;
            EReferenceInserter.ReadOnly = !CBReferenceEdit.Checked;
            EReferenceDevice.ReadOnly = !CBReferenceEdit.Checked;
            EReferenceConditions.ReadOnly = !CBReferenceEdit.Checked;
            EReferenceRemarks.ReadOnly = !CBReferenceEdit.Checked;
            EReferenceMeta.ReadOnly = !CBReferenceEdit.Checked;
        }

        private void clearGraphDisplay() {
            ChartReference.Series.Clear();
        }

        private void setGraphDisplay(double[] x, double[] y) {
            clearGraphDisplay();  // Clear the chart

            // Assert that x- and y-axis length match
            if (x.Length != y.Length) {
                showError($"An error occured while plotting values: x and y must have same length, but {x.Length} != {y.Length}");
                return;
            }

            // Create new series and add values
            ChartReference.Series.Add("ReferencePlot");
            for (int i = 0; i < x.Length; i++) {
                ChartReference.Series["ReferencePlot"].Points.AddXY(x[i], y[i]);
            }

            ChartReference.Update();
        }

        private void setReferenceInfo(Reference newReference) {
            EReferenceName.Text = newReference.name;
            EReferenceDate.Value = newReference.date;
            EReferenceOperator.Text = newReference.operatedBy;
            EReferenceInserter.Text = newReference.insertedBy;
            EReferenceDevice.Text = newReference.deviceName;
            EReferenceConditions.Text = newReference.conditions;
            EReferenceFile.Text = newReference.fileName;
            EReferenceRemarks.Text = newReference.remarks;
            EReferenceMeta.Text = newReference.formatMeta();
        }

        private void clearReferenceInfo() {
            CBReferenceEdit.Checked = false;  // This also disables the "Save Changes" button

            EReferenceName.Text = string.Empty;
            EReferenceDate.Value = DateTime.Now;
            EReferenceOperator.Text = string.Empty;
            EReferenceInserter.Text = string.Empty;
            EReferenceDevice.Text = string.Empty;
            EReferenceConditions.Text = string.Empty;
            EReferenceFile.Text = string.Empty;
            EReferenceRemarks.Text = string.Empty;
            EReferenceMeta.Text = string.Empty;

            clearGraphDisplay();

            this.currentReference = null;

            BReferenceEdit.Text = "Save Changes";
        }

        private void BReferenceNew_Click(object sender, EventArgs e) {
            string filename;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                filename = openFileDialog.FileName;
            } else {
                return;
            }

            Reference newReference;
            try {
                // TODO: Differentiate between different file types
                newReference = Reference.FromSpc(filename);
            } catch (Exception ex) {
                if (ex.Message.Length > 0) {
                    showError($"Reading file failed: {ex.Message}");
                } else {
                    showError("Reading file failed");
                }

                return;
            }

            // TODO: Move reference file to a local directory and update filename accordingly

            // Insert values into form
            CBReferenceEdit.Checked = true;  // This also enables the "Save Changes" button
            setReferenceInfo(newReference);
            

            // Plot data
            setGraphDisplay(newReference.xVals, newReference.yVals);

            this.currentReference = newReference;
            this.currentReferenceIsEdit = false;

            BReferenceEdit.Text = "Save";
        }

        private void addReferenceRow(Reference reference) {
            // TODO: Check for validity of data

            string[] rowData = {
                reference.id.ToString(),
                reference.name,
                reference.date.ToShortDateString(),
                reference.operatedBy,
                reference.insertedBy,
                reference.deviceName,
            };

            TReferences.Rows.Add(rowData);
        }

        private void BReferenceEdit_Click(object sender, EventArgs e) {
            if (currentReference == null) { return; }

            if (currentReference.id == -1) {  // No ID assigned yet -> Not in database
                // TODO: Validate data

                // Update reference instance with edited values
                currentReference.name = EReferenceName.Text;
                currentReference.date = EReferenceDate.Value;
                currentReference.operatedBy = EReferenceOperator.Text;
                currentReference.insertedBy = EReferenceInserter.Text;
                currentReference.deviceName = EReferenceDevice.Text;
                currentReference.conditions = EReferenceConditions.Text;
                currentReference.remarks = EReferenceRemarks.Text;
                int parseMetaFailedLine = currentReference.parseMeta(EReferenceMeta.Text, strict: true);
                if (parseMetaFailedLine != 0) {
                    showError($"Error parsing metadata line {parseMetaFailedLine}. Please make sure to format all meta as `key = value`, with a separate line for each entry.");
                    return;
                }

                // TODO: Update database and get ID

                // Add data to references table
                addReferenceRow(currentReference);

                clearReferenceInfo();
            } else {
                // TODO: Validate data

                // TODO: Update reference instance with edited values

                // TODO: Update database

                // TODO: Update data in reference table

                clearReferenceInfo();
            }
        }

        private void EReferenceRemarks_ReadOnlyChanged(object sender, EventArgs e) {
            if (EReferenceRemarks.ReadOnly) {
                EReferenceRemarks.BackColor = SystemColors.Control;
            } else {
                EReferenceRemarks.BackColor = SystemColors.Window;
            }
        }

        private void EReferenceMeta_ReadOnlyChanged(object sender, EventArgs e) {
            if (EReferenceMeta.ReadOnly) {
                EReferenceMeta.BackColor = SystemColors.Control;
            } else {
                EReferenceMeta.BackColor = SystemColors.Window;
            }
        }

        private void TReferences_Resize(object sender, EventArgs e) {
            bool isTableScrolled = TReferences.PreferredSize.Width > TReferences.ClientSize.Width;

            if (isTableScrolled) {
                TReferences.Columns[TReferences.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            } else {
                TReferences.Columns[TReferences.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
