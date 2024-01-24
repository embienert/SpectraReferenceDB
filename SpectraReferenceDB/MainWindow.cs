using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SpectraReferenceDB
{
    public partial class MainWindow : Form
    {
        private Reference currentReference;
        private bool currentReferenceIsEdit;
        private bool isButtonEdit = false;
        private Dictionary<int, Reference> idReferenceMap;

        private Database db;
        private string databasePath = @"C:\Users\marti\source\repos\SpectraReferenceDB\SpectraReferenceDB\data\";
        private string referenceFilesSubdir = "_files";
        private string referencesFilesPath;
        TextAnnotation annotation;
        private int currentDataPointIndex = -1;
        private int keyDownCount = 0;
        private bool plotFixed = false;

        private string[] spcExtentions = { ".spc" };
        private string[] datExtentions = { ".dat", ".raman", ".txt", ".csv" };

        public MainWindow() {
            InitializeComponent();

            databasePath = Properties.Settings.Default["dbPath"].ToString();
            string db_file = Path.Combine(databasePath, "references.db");
            while (string.IsNullOrEmpty(databasePath) || !File.Exists(db_file)) {
                DialogResult dialogResult = MessageBox.Show("No database path has been specified. " +
                    "Please select the database directory.", "No Database", MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK) {
                    FolderBrowserDialog dialog = new FolderBrowserDialog();

                    if (dialog.ShowDialog() == DialogResult.OK) {
                        databasePath = dialog.SelectedPath;
                    }
                } else {
                    this.Close();
                    return;
                }

                db_file = Path.Combine(databasePath, "references.db");
                if (!File.Exists(db_file)) {
                    dialogResult = MessageBox.Show("No database found at the specified path." +
                        "Do you want to create a new database?", "No Database", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.Yes) {
                        break;
                    }
                }
            }

            Properties.Settings.Default["dbPath"] = databasePath;
            Properties.Settings.Default.Save();
            referencesFilesPath = Path.Combine(databasePath, referenceFilesSubdir);
            Directory.CreateDirectory(referencesFilesPath);  // Create directory if it does not yet exist

            this.db = new Database(db_file);
            loadReferences();
            clearReferenceInfo();

            EReferenceRemarks.ReadOnly = true;
            EReferenceMeta.ReadOnly = true;

            TReferences_Resize(null, null);
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x210) {
                int wparam = m.WParam.ToInt32();

                if (wparam == 0x201) {
                    TReferences.ClearSelection();
                }
            }

            base.WndProc(ref m);
        }


        private void loadReferences() {
            clearReferences();

            this.idReferenceMap = new Dictionary<int, Reference>();
            List<Reference> allReferences = db.allEntries();

            foreach (Reference reference in allReferences) {
                addReferenceRow(reference);
                idReferenceMap[reference.id] = reference;
            }

            LNumResults.Text = $"{allReferences.Count} Results";
        }

        private void clearReferences() {
            TReferences.Rows.Clear();

            idReferenceMap = new Dictionary<int, Reference>();
        }

        private void searchReferences(string searchQuery) {
            clearReferences();

            idReferenceMap = new Dictionary<int, Reference>();
            List<Reference> searchReferences = db.search(searchQuery);

            if (searchReferences == null) { return; }

            foreach (Reference reference in searchReferences) {
                if (reference == null) {
                    continue;
                }
                addReferenceRow(reference);
                idReferenceMap[reference.id] = reference;
            }

            LNumResults.Text = $"{searchReferences.Count} Results";

            if (currentReference != null && idReferenceMap.ContainsKey(currentReference.id)) {
                currentReference = idReferenceMap[currentReference.id];
                setReferenceInfo(currentReference);
            }
        }


        private void showError(string message) {
            if (message != "") {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                MessageBox.Show("An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBReferenceEdit_CheckedChanged(object sender, EventArgs e) {
            BReferenceEdit.Enabled = true;

            if (CBReferenceEdit.Checked) {
                if (currentReferenceIsEdit) {
                    BReferenceEdit.Text = "Save Changes";
                } else {
                    BReferenceEdit.Text = "Save";
                }
                this.isButtonEdit = true;
            } else {
                if (currentReferenceIsEdit) {
                    BReferenceEdit.Text = "Delete Entry";
                    this.isButtonEdit = false;
                } else {
                    this.isButtonEdit = true;
                }
            }

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
            Series series = ChartReference.Series.Add("ReferencePlot");
            for (int i = 0; i < x.Length; i++) {
                series.Points.AddXY(x[i], y[i]);
            }


            // Configure plot
            ChartArea chartArea;
            if (ChartReference.ChartAreas.Count > 0) {
                chartArea = ChartReference.ChartAreas[0];
            } else {
                chartArea = new ChartArea();
                ChartReference.ChartAreas.Add(chartArea);
            }

            // Remove grid
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisX.IntervalOffset = 0;

            // TODO: Set axis limits
            // chartArea.AxisX.Minimum = x.Min();
            // chartArea.AxisX.Maximum = x.Max();
            // chartArea.AxisY.Minimum = y.Min();
            // chartArea.AxisY.Maximum = y.Max();

            if (x.Min() != 0 && x.Max() != 0) {
                int oomUpper = (int)Math.Log10(x.Max());

                chartArea.AxisX.Minimum = Math.Pow(10, oomUpper-1) * Math.Floor(x.Min() / Math.Pow(10, oomUpper - 1));
                chartArea.AxisX.Maximum = Math.Pow(10, oomUpper-1) * Math.Ceiling(x.Max() / Math.Pow(10, oomUpper - 1));

                int nrTicks = 6;
                double interval = (Math.Pow(10, oomUpper-1) * Math.Round(((chartArea.AxisX.Maximum - chartArea.AxisX.Minimum) / (Math.Pow(10, oomUpper-1) * nrTicks)) - 0.3));
                // chartArea.AxisX.Maximum = chartArea.AxisX.Minimum + nrTicks * interval;
                chartArea.AxisX.Interval = interval;
            }

            if (y.Min() != 0 && y.Max() != 0) {
                int oomUpper = (int)Math.Log10(y.Max());

                chartArea.AxisY.Minimum = Math.Pow(10, oomUpper - 1) * Math.Floor(y.Min() / Math.Pow(10, oomUpper - 1));
                chartArea.AxisY.Maximum = Math.Pow(10, oomUpper - 1) * Math.Ceiling(y.Max() / Math.Pow(10, oomUpper - 1));

                int nrTicks = 6;
                double interval = (Math.Pow(10, oomUpper - 1) * Math.Round(((chartArea.AxisY.Maximum - chartArea.AxisY.Minimum) / (Math.Pow(10, oomUpper - 1) * nrTicks)) - 0.3));
                // chartArea.AxisX.Maximum = chartArea.AxisX.Minimum + nrTicks * interval;
                chartArea.AxisY.Interval = interval;
            }

            // Set graph type
            series.ChartType = SeriesChartType.Line;

            ChartReference.Update();
        }

        private void setReferenceInfo(Reference newReference) {
            PReferenceEditControlContainer.Enabled = true;
            CBReferenceEdit.Checked = true;
            CBReferenceEdit.Checked = false;

            EReferenceName.Text = newReference.name;
            EReferenceDate.Value = newReference.date;
            EReferenceOperator.Text = newReference.operatedBy;
            EReferenceInserter.Text = newReference.insertedBy;
            EReferenceDevice.Text = newReference.deviceName;
            EReferenceConditions.Text = newReference.conditions;
            EReferenceFile.Text = Path.Combine(referencesFilesPath, newReference.fileName);
            EReferenceRemarks.Text = newReference.remarks;
            EReferenceMeta.Text = newReference.formatMeta();
        }

        private bool getCurrentReferenceInfo() {
            currentReference.name = EReferenceName.Text;
            currentReference.date = EReferenceDate.Value;
            currentReference.operatedBy = EReferenceOperator.Text;
            currentReference.insertedBy = EReferenceInserter.Text;
            currentReference.deviceName = EReferenceDevice.Text;
            currentReference.conditions = EReferenceConditions.Text;
            currentReference.remarks = EReferenceRemarks.Text;

            // Parse meta to dictionary
            int parseMetaFailedLine = currentReference.parseMeta(EReferenceMeta.Text, strict: true);
            if (parseMetaFailedLine != 0) {
                showError($"Error parsing metadata line {parseMetaFailedLine}. Please make sure to format all meta as `key = value`, with a separate line for each entry.");
                return false;
            }

            return true;
        }

        private void clearReferenceInfo() {
            CBReferenceEdit.Checked = false;
            PReferenceEditControlContainer.Enabled = false;

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
            TReferences.ClearSelection();
        }

        private void BReferenceNew_Click(object sender, EventArgs e) {
            currentReferenceIsEdit = false;

            string filename;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                filename = openFileDialog.FileName;
            } else {
                return;
            }

            Reference newReference;
            try {
                if (spcExtentions.Contains(Path.GetExtension(filename).ToLower())) { newReference = Reference.FromSpc(filename); }
                else if (datExtentions.Contains(Path.GetExtension(filename).ToLower())) {
                    OpenDatDialog dialog = new OpenDatDialog();
                    DialogResult results = dialog.ShowDialog(this);
                    if (results == DialogResult.OK) {
                        if (dialog.isAutomatic()) {
                            newReference = Reference.FromTxt(filename);
                        } else {
                            newReference = Reference.FromTxt(filename, dialog.getValue());
                        }
                    } else {
                        return;
                    }
                }     
                else {
                    showError($"Unknown file extension '{Path.GetExtension(filename)}'. Make sure the file has one of the following extensions: [.spc, .txt, .dat, .raman]");
                    return;
                }
            } catch (Exception ex) {
                if (ex.Message.Length > 0) {
                    showError($"Reading file failed: {ex.Message}");
                } else {
                    showError("Reading file failed");
                }

                return;
            }

            // TODO: Copy reference file to a local directory and update filename accordingly
            string fileTarget = Path.Combine(referencesFilesPath, Path.GetFileName(filename));
            if (newReference.fileName != fileTarget) {
                if (File.Exists(fileTarget)) {
                    // Remove read-only flag
                    File.SetAttributes(fileTarget, File.GetAttributes(fileTarget) & ~FileAttributes.ReadOnly);
                    File.Delete(fileTarget); 
                }  // Delete file if it already exists in target directory
                File.Copy(newReference.fileName, fileTarget);

                string localFilePath = Path.Combine(referenceFilesSubdir, Path.GetFileName(filename));
                newReference.fileName = fileTarget;
                newReference.fileName = Path.GetFileName(fileTarget);
            }
            File.SetAttributes(fileTarget, File.GetAttributes(fileTarget) | FileAttributes.ReadOnly);  // Set the file to read-only


            // Insert values into form
            setReferenceInfo(newReference);
            CBReferenceEdit.Checked = true;  // This also enables the "Save Changes" button

            // Plot data
            setGraphDisplay(newReference.xVals, newReference.yVals);

            this.currentReference = newReference;
            this.currentReferenceIsEdit = false;
        }

        private void TReferences_CellClick(object sender, DataGridViewCellEventArgs e) {
            currentReferenceIsEdit = true;

            int clickedRowIdx = e.RowIndex;
            if (clickedRowIdx == -1) {
                // Column header was clicked
                return;
            }

            int referenceID;
            try {
                referenceID = Int32.Parse(TReferences.Rows[clickedRowIdx].Cells[0].Value.ToString());
            }
            catch (Exception ex) {
                showError("Error loading reference from table: Failed to parse id.");
                return;
            }

            currentReference = idReferenceMap[referenceID];

            // Insert values into form
            setReferenceInfo(currentReference);

            // Load x- and y-values and show the graph
            if (currentReference.xVals == null || currentReference.yVals == null) {
                String targetPath = Path.Combine(this.referencesFilesPath, currentReference.fileName);
                Reference originalReference;

                if (spcExtentions.Contains(Path.GetExtension(targetPath).ToLower())) { 
                    originalReference = Reference.FromSpc(targetPath);
                } else {
                    originalReference = Reference.FromTxt(targetPath);
                }

                currentReference.xVals = originalReference.xVals;
                currentReference.yVals = originalReference.yVals;
            }

            setGraphDisplay(currentReference.xVals, currentReference.yVals);
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

            int newRowIdx = TReferences.Rows.Add(rowData);
            TReferences.Rows[newRowIdx].Selected = true;
        }

        private void updateReferenceRow(Reference reference) { 
            foreach (DataGridViewRow row in TReferences.Rows) { 
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == this.currentReference.id.ToString()) {
                    row.Cells[1].Value = this.currentReference.name;
                    row.Cells[2].Value = this.currentReference.date.ToShortDateString();
                    row.Cells[3].Value = this.currentReference.operatedBy;
                    row.Cells[4].Value = this.currentReference.insertedBy;
                    row.Cells[5].Value = this.currentReference.deviceName;

                    row.Selected = true;

                    break;
                }
            }
        }

        private void removeReferenceRow(Reference reference) {
            foreach (DataGridViewRow row in TReferences.Rows) {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == this.currentReference.id.ToString()) {
                    TReferences.Rows.Remove(row);

                    break;
                }
            }
        }

        private bool validateEntry() {
            if (this.currentReference == null) { return false; }

            if (this.currentReference.name == string.Empty || this.currentReference.name == null) {
                showError("Error validating reference: The field `Name` must not be empty.");
                return false; 
            }
            if (this.currentReference.fileName == string.Empty || this.currentReference.fileName == null) {
                showError("Error validating reference: The field `Filename` must not be empty.");
                return false; 
            }

            int duplicateId = db.findDuplicate(this.currentReference);
            if (duplicateId != -1 && duplicateId != this.currentReference.id) {
                showError($"Error validating reference: A duplicate of this reference already exists (id={duplicateId}).");
                return false;
            }

            return true;
        }

        private void BReferenceEdit_Click(object sender, EventArgs e) {
            if (currentReference == null) { return; }

            if (this.isButtonEdit) {
                if (!validateEntry()) { return; }  // Current entry fails validation

                // Button is set to "Save Changes" -> Apply changes to table and database
                if (!getCurrentReferenceInfo()) { return; }  // Update reference instance with edited values

                if (currentReference.id == -1) {  // No ID assigned yet -> Not in database
                    // Update database and get ID
                    currentReference.id = db.createEntry(currentReference);

                    // Add data to references table
                    addReferenceRow(currentReference);
                    idReferenceMap[currentReference.id] = currentReference;

                    setReferenceInfo(currentReference);
                    currentReferenceIsEdit = true;
                    CBReferenceEdit_CheckedChanged(null, null);
                }
                else {  // Entry is already in database
                    // Update database
                    db.updateEntry(currentReference);

                    // Update data in reference table
                    updateReferenceRow(currentReference);

                    // Reset `enable changes` checkbox
                    CBReferenceEdit.Checked = false;
                }
            } else {
                // Button is set to "Delete Entry" -> Remove current reference from database

                // Confirm delete
                DialogResult dialogResult = MessageBox.Show("Are your sure you want to delete this entry from the database? This process is not reversible.", "Confirm Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                    // Remove entry from database and clear from UI
                    db.deleteEntry(currentReference);

                    removeReferenceRow(currentReference);
                    idReferenceMap.Remove(currentReference.id);

                    // Clear info panel
                    clearReferenceInfo();
                }
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

        private void ChartReference_MouseMove(object sender, MouseEventArgs e) {
            if (ChartReference.Series.Count == 0) { return; }
            if (plotFixed) { return; }
            ChartReference.Focus();

            ChartArea chartArea = ChartReference.ChartAreas[0];
            Axis xAxis = chartArea.AxisX;
            Axis yAxis = chartArea.AxisY;

            double mousePositionX;
            double mousePositionY;
            try {
                mousePositionX = xAxis.PixelPositionToValue(e.X);
                mousePositionY = yAxis.PixelPositionToValue(e.Y);
            }
            catch {
                return;
            }

            if (mousePositionX < xAxis.Minimum || xAxis.Maximum < MousePosition.X 
                || mousePositionY < yAxis.Minimum || yAxis.Maximum < mousePositionY) {
                return;
            }

            // Find nearest point along the x-Axis
            Series graphSeries = ChartReference.Series[0];

            DataPoint closestPoint = null;
            double closestDistance = double.MaxValue;

            for (int i = 0; i < graphSeries.Points.Count; i++) {
                DataPoint point = graphSeries.Points[i];
                double xDiff = Math.Abs(mousePositionX - point.XValue);
                if (xDiff < closestDistance) { 
                    closestPoint = point;
                    closestDistance = xDiff;
                    currentDataPointIndex = i;
                }
            }

            if (closestPoint == null) { return; }

            Series hLineSeries;
            Series vLineSeries;
            if (ChartReference.Series.Count > 1) {
                hLineSeries = ChartReference.Series["hLine"];
                vLineSeries = ChartReference.Series["vLine"];

                hLineSeries.Points.Clear();
                vLineSeries.Points.Clear();
            } else {
                hLineSeries = ChartReference.Series.Add("hLine");
                hLineSeries.ChartType = SeriesChartType.FastLine;
                hLineSeries.Color = Color.Red;

                vLineSeries = ChartReference.Series.Add("vLine");
                vLineSeries.ChartType = SeriesChartType.FastLine;
                vLineSeries.Color = Color.Red;
            }

            hLineSeries.Points.Add(new DataPoint(currentReference.xVals.Min(), closestPoint.YValues[0]));
            hLineSeries.Points.Add(new DataPoint(closestPoint.XValue, closestPoint.YValues[0]));

            vLineSeries.Points.Add(new DataPoint(closestPoint.XValue, closestPoint.YValues[0]));
            vLineSeries.Points.Add(new DataPoint(closestPoint.XValue, 0));


            // Add text annotation with coordinates
            if (ChartReference.Annotations.Count == 0) {
                annotation = new TextAnnotation();
                ChartReference.Annotations.Add(annotation);

                annotation.AnchorAlignment = ContentAlignment.BottomLeft;
                annotation.ForeColor = System.Drawing.Color.Black;
                annotation.Font = new System.Drawing.Font("Segoe UI", 12);
                annotation.BackColor = System.Drawing.Color.Transparent;
                annotation.Alignment = ContentAlignment.BottomLeft;
            }

            annotation.AnchorDataPoint = closestPoint;
            annotation.Text = $"x: {closestPoint.XValue:F2}\ny: {closestPoint.YValues[0]:F2}";

            ChartReference.Update();
        }

        private void ChartReference_MouseLeave(object sender, EventArgs e) {
            if (plotFixed) { return; }

            if (ChartReference.Series.Count > 1) {
                ChartReference.Series.RemoveAt(1);
                ChartReference.Series.RemoveAt(1);
            }
            if (ChartReference.Annotations.Count > 0) {
                ChartReference.Annotations.RemoveAt(0);
            }

            currentDataPointIndex = -1;
        }

        private void ChartReference_KeyDown(object sender, KeyEventArgs e) {
            keyDownCount++;

            if (ChartReference.Series.Count == 0) { return; }  // Nothing currently being displayed on the chart
            Series graphSeries = ChartReference.Series[0];

            // Acceleration
            int accelerationFactor = (int)Math.Ceiling(0.65 * Math.Pow((double)keyDownCount, 4.0f/7.0f));

            bool reverseX = graphSeries.Points[graphSeries.Points.Count() - 1].XValue < graphSeries.Points[0].XValue;
            int shift = reverseX ? -1 : 1;
            if (e.KeyCode == Keys.Left) {
                currentDataPointIndex -= shift * accelerationFactor;
            } else if (e.KeyCode == Keys.Right) {
                currentDataPointIndex += shift * accelerationFactor;
            } else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) {
                plotFixed = !plotFixed;
                return;
            } else {
                return;
            }
            plotFixed = false;
            currentDataPointIndex = Math.Min(Math.Max(0, currentDataPointIndex), graphSeries.Points.Count() - 1);  // Limit 
            DataPoint currentPoint = graphSeries.Points[currentDataPointIndex];

            Series hLineSeries;
            Series vLineSeries;
            if (ChartReference.Series.Count > 1) {
                hLineSeries = ChartReference.Series["hLine"];
                vLineSeries = ChartReference.Series["vLine"];

                hLineSeries.Points.Clear();
                vLineSeries.Points.Clear();
            }
            else {
                hLineSeries = ChartReference.Series.Add("hLine");
                hLineSeries.ChartType = SeriesChartType.FastLine;
                hLineSeries.Color = Color.Red;

                vLineSeries = ChartReference.Series.Add("vLine");
                vLineSeries.ChartType = SeriesChartType.FastLine;
                vLineSeries.Color = Color.Red;
            }

            hLineSeries.Points.Add(new DataPoint(currentReference.xVals.Min(), currentPoint.YValues[0]));
            hLineSeries.Points.Add(new DataPoint(currentPoint.XValue, currentPoint.YValues[0]));

            vLineSeries.Points.Add(new DataPoint(currentPoint.XValue, currentPoint.YValues[0]));
            vLineSeries.Points.Add(new DataPoint(currentPoint.XValue, 0));


            // Add text annotation with coordinates
            if (ChartReference.Annotations.Count == 0) {
                annotation = new TextAnnotation();
                ChartReference.Annotations.Add(annotation);

                annotation.AnchorAlignment = ContentAlignment.BottomLeft;
                annotation.ForeColor = System.Drawing.Color.Black;
                annotation.Font = new System.Drawing.Font("Segoe UI", 12);
                annotation.BackColor = System.Drawing.Color.Transparent;
                annotation.Alignment = ContentAlignment.BottomLeft;
            }

            annotation.AnchorDataPoint = currentPoint;
            annotation.Text = $"x: {currentPoint.XValue:F2}\ny: {currentPoint.YValues[0]:F2}";

            ChartReference.Update();
        }

        private void ChartReference_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                ChartReference.Focus();
                plotFixed = !plotFixed;
            } else {
                plotFixed = false;
            }
        }

        private void ChartReference_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            e.IsInputKey = true;
        }

        private void ChartReference_KeyUp(object sender, KeyEventArgs e) {
            keyDownCount = 0;
        }

        private void BSearch_Click(object sender, EventArgs e) {
            string searchValue = ESearch.Text;
            searchReferences(searchValue);
        }

        private void ESearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string searchValue = ESearch.Text;
                searchReferences(searchValue);
            }
        }

        private void ChartReference_MouseEnter(object sender, EventArgs e) {
            plotFixed = false;
        }

        private void TReferences_KeyDown(object sender, KeyEventArgs e) {
            currentReferenceIsEdit = true;

            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space) {
                return;
            }

            if (TReferences.SelectedCells.Count <= 0) { return; }
            int clickedRowIdx = TReferences.SelectedCells[0].RowIndex;
            if (clickedRowIdx == -1) {
                // Column header was clicked
                return;
            }

            int referenceID;
            try {
                referenceID = Int32.Parse(TReferences.Rows[clickedRowIdx].Cells[0].Value.ToString());
            }
            catch (Exception ex) {
                showError("Error loading reference from table: Failed to parse id.");
                return;
            }

            currentReference = idReferenceMap[referenceID];

            // Insert values into form
            setReferenceInfo(currentReference);

            // Load x- and y-values and show the graph
            if (currentReference.xVals == null || currentReference.yVals == null) {
                String targetPath = Path.Combine(this.referencesFilesPath, currentReference.fileName);
                Reference originalReference;

                if (spcExtentions.Contains(Path.GetExtension(targetPath).ToLower())) {
                    originalReference = Reference.FromSpc(targetPath);
                }
                else {
                    originalReference = Reference.FromTxt(targetPath);
                }

                currentReference.xVals = originalReference.xVals;
                currentReference.yVals = originalReference.yVals;
            }

            setGraphDisplay(currentReference.xVals, currentReference.yVals);
        }

        private void EReferenceRemarks_MouseEnter(object sender, EventArgs e) {
            EReferenceRemarks.Focus();
            EReferenceRemarks.SelectionStart = 0;
            EReferenceRemarks.SelectionLength = 0;
        }

        private void EReferenceRemarks_MouseLeave(object sender, EventArgs e) {
            this.Focus();
        }

        private void EReferenceMeta_MouseEnter(object sender, EventArgs e) {
            EReferenceMeta.Focus();
            EReferenceMeta.SelectionStart = 0;
            EReferenceMeta.SelectionLength = 0;
        }

        private void EReferenceMeta_MouseLeave(object sender, EventArgs e) {
            this.Focus();
        }

        private void TReferences_MouseEnter(object sender, EventArgs e) {
            TReferences.Focus();
        }

        private void TReferences_MouseLeave(object sender, EventArgs e) {
            this.Focus();
        }
    }
}
