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
        public MainWindow()
        {
            InitializeComponent();
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
            CBReferenceEdit.Checked = true;
            BReferenceEdit.Enabled = true;

            EReferenceName.Text = newReference.name;
            EReferenceDate.Value = newReference.date;
            EReferenceOperator.Text = newReference.operatedBy;
            EReferenceInserter.Text = newReference.insertedBy;
            EReferenceDevice.Text = newReference.deviceName;
            EReferenceConditions.Text = newReference.conditions;
            EReferenceFile.Text = filename;
            EReferenceRemarks.Text = newReference.remarks;
            EReferenceMeta.Text = newReference.formatMeta();

            // Plot data
            setGraphDisplay(newReference.xVals, newReference.yVals);
        }
    }
}
