using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectraReferenceDB {
    public class SPCFile {
        //const int LOG_HEADER_SIZE = 64;

        public int fileVersion;
        public int experimentTypeCode;
        public int numDataPoints;  // Unimportant for XYXY format
        public int numSubfiles;
        public int xUnitsTypeCode;
        public int yUnitsTypeCode;
        public int zUnitsTypeCode;
        public int wUnitsTypeCode;
        public int postingDisposition;
        public DateTime date;
        public string resolutionDescription;
        public string sourceInstrumentDescription;
        public short peakPointNumber;
        public byte[] spare;
        public string memo;
        public string xAxisLabel;
        public string yAxisLabel;
        public string zAxisLabel;
        public int processingCode;
        public int calibrationLevel;
        public string methodFile;
        public float zSubfileIncrement;
        public int numWPlanes;
        public float wPlaneIncrement;

        public readonly double[][] xData;
        public readonly double[][] yData;

        public Dictionary<string, string> logData;

        public SPCFile(string filePath) {


            using (FileStream stream = File.OpenRead(filePath)) {
                using (BinaryReader reader = new BinaryReader(stream)) {
                    // Main header
                    byte flags = reader.ReadByte();
                    int spcFileVersion = (int)reader.ReadByte();
                    experimentTypeCode = (int)reader.ReadByte();
                    int exponent = (int)reader.ReadByte();
                    numDataPoints = reader.ReadInt32();
                    double firstX = reader.ReadDouble();
                    double lastX = reader.ReadDouble();
                    numSubfiles = reader.ReadInt32();
                    xUnitsTypeCode = (int)reader.ReadByte();
                    yUnitsTypeCode = (int)reader.ReadByte();
                    zUnitsTypeCode = (int)reader.ReadByte();
                    postingDisposition = (int)reader.ReadByte();
                    int compressedDate = reader.ReadInt32();
                    resolutionDescription = Encoding.UTF8.GetString(reader.ReadBytes(9));
                    sourceInstrumentDescription = Encoding.UTF8.GetString(reader.ReadBytes(9));
                    peakPointNumber = reader.ReadInt16();
                    spare = reader.ReadBytes(8 * 4);  // What datatype? (Source reads as 8 floats)
                    memo = Encoding.UTF8.GetString(reader.ReadBytes(130));
                    string customAxisLabels = Encoding.UTF8.GetString(reader.ReadBytes(30));
                    int byteOffsetToLogBlock = reader.ReadInt32();
                    int fileModificationFlag = reader.ReadInt32();
                    processingCode = (int)reader.ReadByte();
                    calibrationLevel = (int)reader.ReadByte();
                    short subMethodSampleInjectorNumber = reader.ReadInt16();
                    float dataMultiplierConcentration = reader.ReadSingle();
                    methodFile = Encoding.UTF8.GetString(reader.ReadBytes(48));
                    zSubfileIncrement = reader.ReadSingle();
                    numWPlanes = reader.ReadInt32();
                    wPlaneIncrement = reader.ReadSingle();
                    wUnitsTypeCode = (int)reader.ReadByte();
                    byte[] reserved = reader.ReadBytes(187);


                    /*
                     * Process header data
                     */

                    // Process header flags
                    bool txvals = (flags & (1 << 0)) != 0;
                    bool txyxys = (flags & (1 << 1)) != 0;
                    bool talabs = (flags & (1 << 2)) != 0;
                    bool tordrd = (flags & (1 << 3)) != 0;
                    bool trandm = (flags & (1 << 4)) != 0;
                    bool tmulti = (flags & (1 << 5)) != 0;
                    bool tcgram = (flags & (1 << 6)) != 0;
                    bool tsprec = (flags & (1 << 7)) != 0;

                    // Process date
                    int year = compressedDate >> 20;
                    int month = (compressedDate >> 16) % ((int)Math.Pow(2, 4));
                    int day = (compressedDate >> 11) % ((int)Math.Pow(2, 5));
                    int hour = (compressedDate >> 6) % ((int)Math.Pow(2, 5));
                    int minute = compressedDate % ((int)Math.Pow(2, 6));
                    date = new DateTime(year, month, day, hour, minute, 0);

                    // TODO: Process axis labels


                    /*
                     * Process body data
                     */

                    if (!txyxys) {
                        xData = new double[1][];
                        double[] xVals = new double[numDataPoints];

                        if (txvals) {
                            // Explicit global x-Values
                            for (int i = 0; i < numDataPoints; i++) {
                                xVals[i] = (double)reader.ReadSingle();
                            }
                        }
                        else {
                            // x-values can be generated from metadata
                            double xInterval = (lastX - firstX) / (numDataPoints - 1);
                            for (int i = 0; i < numDataPoints; i++) {
                                xVals[i] = firstX + i * xInterval;
                            }
                        }

                        xData[0] = xVals;
                    } else {
                        xData = new double[numSubfiles][];
                    }

                    /*
                     * Process first subfile
                     */

                    // Read first subfile header
                    byte subfileFlags = reader.ReadByte();
                    int subfileExponent = (int)reader.ReadByte();
                    if (subfileExponent == 0) { subfileExponent = exponent; }
                    if (subfileExponent <= -128 || 128 < subfileExponent) { subfileExponent = 0; }
                    short subfileIndex = reader.ReadInt16();
                    float subfileZStart = reader.ReadSingle();
                    float subfileZEnd = reader.ReadSingle();
                    float subfileNoise = reader.ReadSingle();
                    int subfileNumDataPoints = reader.ReadInt32();  // Only relevant for XYXY format
                    if (!txyxys) { subfileNumDataPoints = numDataPoints; }
                    int subfileNumCoScans = reader.ReadInt32();  // Number of co-added scans
                    float subfileWAxis = reader.ReadSingle();
                    byte[] subfileReserved = reader.ReadBytes(4);

                    yData = new double[numSubfiles][];
                    for (int subfile = 0; subfile < numSubfiles; subfile++) {
                        if (txyxys) {
                            // Subfiles also contain x-values
                            double[] xVals = new double[subfileNumDataPoints];

                            for (int i = 0; i < subfileNumDataPoints; i++) {
                                xVals[i] = (double)reader.ReadSingle() * (Math.Pow(2.0, subfileExponent - 32));
                            }

                            xData[subfile] = xVals;
                        }

                        // Load y-values from file
                        double[] yVals = new double[subfileNumDataPoints];

                        if (subfileExponent == 128) {
                            // y-values are floats
                            for (int i = 0; i < subfileNumDataPoints; i++) {
                                yVals[i] = (double)reader.ReadSingle();
                            }
                        }
                        else {
                            // y-values are integers
                            if (tsprec) {
                                // 16-bit integers
                                for (int i = 0; i < subfileNumDataPoints; ++i) {
                                    yVals[i] = (double)reader.ReadInt16() * (Math.Pow(2.0, subfileExponent - 16));
                                }
                            }
                            else {
                                // 32-bit integers
                                for (int i = 0; i < subfileNumDataPoints; i++) {
                                    yVals[i] = (double)reader.ReadInt32() * (Math.Pow(2.0, subfileExponent - 32));
                                }
                            }
                        }

                        yData[subfile] = yVals;
                    }

                    // Load log data
                    logData = new Dictionary<string, string>();
                    if (byteOffsetToLogBlock != 0) {  // If offset is 0, there is no log block
                        reader.BaseStream.Seek(byteOffsetToLogBlock, SeekOrigin.Begin);  // Set current position in file to start of log block

                        // Read log header
                        int logSizeD = reader.ReadInt32();
                        int logSizeM = reader.ReadInt32();
                        int logTxtOffset = reader.ReadInt32();
                        int logBins = reader.ReadInt32();
                        int logDsks = reader.ReadInt32();
                        string logSpare = Encoding.UTF8.GetString(reader.ReadBytes(44));
 
                        reader.BaseStream.Seek(byteOffsetToLogBlock + logTxtOffset, SeekOrigin.Begin);  // Set current position in file to start of log content

                        // Read log content
                        string logContent = Encoding.UTF8.GetString(reader.ReadBytes(logSizeD)).Replace("\r", "");

                        // Process log content into a dictionary
                        string[] logRows = logContent.Split('\n');

                        foreach (string row in logRows) {
                            if (row.Contains('=')) {
                                string[] rowSplit = row.Split('=');
                                string key = rowSplit[0];
                                string value = rowSplit[1];

                                logData[key] = value;
                            }
                        }
                    }


                    // TODO: Construct meta
                    Console.WriteLine(date.ToString());
                }
            }
        }
    }


    public class DATFile {
        private char[] separators = { ',', ';', '\t', ' ' };
        private char separator;

        public readonly double[] xData;
        public readonly double[][] yData;

        public DATFile(string filePath) {
            string fileContent = File.ReadAllText(filePath);

            fileContent = fileContent.Replace("\r", "").Trim();

            // Detect column separator
            int commaCount = fileContent.Count(c => c == ',');
            int semicolonCount = fileContent.Count(c => c == ';');
            int tabCount = fileContent.Count(c => c == '\t');
            int spaceCount = fileContent.Count(c => c == ' ');
            int[] countArray = { commaCount, semicolonCount, tabCount, spaceCount };
            int maxVal = countArray.Max();
            int maxIndex = countArray.ToList().IndexOf(maxVal);

            if (countArray.Count(val => val == maxVal) > 1) {
                throw new FormatException("Automatic separator selection result is ambiguous.");
            }

            separator = separators[maxIndex];

            string[] linesContent = fileContent.Split('\n');
            string[][] linesSplitContent = new string[linesContent.Length][];

            // Find first value row index
            int firstContentRowIndex = -1;
            int currentRowLength;
            int numCols = -1;
            for (int i = 0; i < linesContent.Length; i++) {
                string currentRow = linesContent[i];

                string[] currentRowSplit = currentRow.Trim().Split(separator);
                linesSplitContent[i] = currentRowSplit;
                currentRowLength = currentRowSplit.Length;

                // Current row has different length than previous row or is empty -> update variables
                if (currentRowLength != numCols || currentRowLength == 0) {
                    firstContentRowIndex = i;
                    numCols = currentRowLength;
                }

                try {
                    Convert.ToDouble(currentRowSplit[0]);
                } catch {
                    // Current row contains non-numeric values
                    firstContentRowIndex = i;
                    numCols = currentRowLength;
                }
            }

            if (firstContentRowIndex == linesContent.Length - 1) {
                throw new FormatException("Number of columns is inconsistent.");
            }

            // TODO: Maybe combine this with the 'main' iteration where values are parsed
            // Iterate over numeric content lines and add values
            int firstContentRowIndexOffset = 0;
            xData = new double[linesContent.Length - firstContentRowIndex];
            double[][] yDataTransposed = new double[linesContent.Length - firstContentRowIndex][];

            for (int i = 0; i < linesContent.Length - firstContentRowIndex; i++) {
                try {
                    string[] currentRowSplit = linesSplitContent[i + firstContentRowIndex];

                    xData[i] = Convert.ToDouble(currentRowSplit[0]);
                    double[] y = new double[numCols-1];

                    for (int j = 1; j < numCols; j++) {
                        y[j - 1] = Convert.ToDouble(currentRowSplit[j]);
                    }

                    yDataTransposed[i] = y;
                } catch {
                    // Cannot parse row -> Non-numeric value in row
                    firstContentRowIndexOffset = i + 1;
                }
            }

            if (firstContentRowIndexOffset != 0) {
                double[] xOverride = new double[linesContent.Length - (firstContentRowIndex + firstContentRowIndexOffset)];
                double[][] ysOverride = new double[linesContent.Length - (firstContentRowIndex + firstContentRowIndexOffset)][];

                for (int i = firstContentRowIndexOffset; i < xData.Length; i++) {
                    xOverride[i - firstContentRowIndexOffset] = xData[i];

                    // Copy y-row
                    double[] yOverride = new double[numCols - 1];
                    Array.Copy(yDataTransposed[i], yOverride, numCols-1);
                    ysOverride[i - firstContentRowIndexOffset] = yOverride;
                }

                xData = xOverride;
                yDataTransposed = ysOverride;
            }

            // Transpose yData
            yData = new double[yDataTransposed[0].Length][];
            for (int colIdx = 0; colIdx < yDataTransposed[0].Length; colIdx++) {
                double[] transposedRow = new double[yDataTransposed.Length];

                for (int rowIdx = 0; rowIdx < yDataTransposed.Length; rowIdx++) {
                    transposedRow[rowIdx] = yDataTransposed[rowIdx][colIdx];
                }

                yData[colIdx] = transposedRow;
            }
        }


        public DATFile(string filePath, int numHeaders) {
            string fileContent = File.ReadAllText(filePath);

            fileContent = fileContent.Replace("\r", "").Trim();

            // Detect column separator
            int commaCount = fileContent.Count(c => c == ',');
            int semicolonCount = fileContent.Count(c => c == ';');
            int tabCount = fileContent.Count(c => c == '\t');
            int spaceCount = fileContent.Count(c => c == ' ');
            int[] countArray = { commaCount, semicolonCount, tabCount, spaceCount };
            int maxVal = countArray.Max();
            int maxIndex = countArray.ToList().IndexOf(maxVal);

            if (countArray.Count(val => val == maxVal) > 1) {
                throw new FormatException("Automatic separator selection result is ambiguous.");
            }

            separator = separators[maxIndex];

            string[] linesContent = fileContent.Split('\n');

            // TODO: Maybe combine this with the 'main' iteration where values are parsed
            // Iterate over numeric content lines and add values
            xData = new double[linesContent.Length - numHeaders];
            double[][] yDataTransposed = new double[linesContent.Length - numHeaders][];

            for (int i = 0; i < linesContent.Length - numHeaders; i++) {
                int j = 0;
                try {
                    string[] currentRowSplit = linesContent[i + numHeaders].Split(separator);
                    int numCols = currentRowSplit.Length;

                    if (numCols < 2) {
                        throw new FormatException($"Row {i + 1} contains less than two values");
                    }

                    xData[i] = Convert.ToDouble(currentRowSplit[0]);
                    double[] y = new double[numCols - 1];

                    for (j = 1; j < numCols; j++) {
                        y[j - 1] = Convert.ToDouble(currentRowSplit[j]);
                    }

                    yDataTransposed[i] = y;
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                    // Cannot parse row -> Non-numeric value in row
                    throw new FormatException($"Cannot parse value in row {i + 1}, column {j + 1}.");
                }
            }

            // Transpose yData
            yData = new double[yDataTransposed[0].Length][];
            for (int colIdx = 0; colIdx < yDataTransposed[0].Length; colIdx++) {
                double[] transposedRow = new double[yDataTransposed.Length];

                for (int rowIdx = 0; rowIdx < yDataTransposed.Length; rowIdx++) {
                    transposedRow[rowIdx] = yDataTransposed[rowIdx][colIdx];
                }

                yData[colIdx] = transposedRow;
            }
        }
    }
}
