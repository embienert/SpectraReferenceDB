using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectraReferenceDB {
    internal class SPCFILE {
        int fileVersion;
        int experimentTypeCode;
        int numDataPoints;  // Unimportant for XYXY format
        int numSubfiles;
        int xUnitsTypeCode;
        int yUnitsTypeCode;
        int zUnitsTypeCode;
        int wUnitsTypeCode;
        int postingDisposition;
        DateTime date;
        string resolutionDescription;
        string sourceInstrumentDescription;
        short pearkPointNumber;
        byte[] spare;
        string memo;
        string xAxisLabel;
        string yAxisLabel;
        string zAxisLabel;
        int processingCode;
        int calibrationLevel;
        string methodFile;
        float zSubfileIncrement;
        int numWPlanes;
        float wPlaneIncrement;

        double[][] xData;
        double[][] yData;

        public SPCFILE(string filePath) {


            using (FileStream stream = File.OpenRead(filePath)) {
                using (BinaryReader reader = new BinaryReader(stream)) {
                    // Main header
                    byte flags = reader.ReadByte();
                    int spcFileVersion = (int)reader.ReadByte();
                    int experimentTypeCode = (int)reader.ReadByte();
                    int exponent = (int)reader.ReadByte();
                    int numDataPoints = reader.ReadInt32();
                    double firstX = reader.ReadDouble();
                    double lastX = reader.ReadDouble();
                    int numSubfiles = reader.ReadInt32();
                    int xUnitsTypeCode = (int)reader.ReadByte();
                    int yUnitsTypeCode = (int)reader.ReadByte();
                    int zUnitsTypeCode = (int)reader.ReadByte();
                    int postingDisposition = (int)reader.ReadByte();
                    int compressedDate = reader.ReadInt32();
                    string resolutionDescription = Encoding.UTF8.GetString(reader.ReadBytes(9));
                    string sourceInstrumentDescription = Encoding.UTF8.GetString(reader.ReadBytes(9));
                    short peakPointNumber = reader.ReadInt16();
                    byte[] spare = reader.ReadBytes(8 * 4);  // What datatype? (Source reads as 8 floats)
                    string memo = Encoding.UTF8.GetString(reader.ReadBytes(130));
                    string customAxisLabels = Encoding.UTF8.GetString(reader.ReadBytes(30));
                    int byteOffsetToLogBlock = reader.ReadInt32();
                    int fileModificationFlag = reader.ReadInt32();
                    int processingCode = (int)reader.ReadByte();
                    int calibrationLevel = (int)reader.ReadByte();
                    short subMethodSampleInjectorNumber = reader.ReadInt16();
                    float dataMultiplierConcentration = reader.ReadSingle();
                    string methodFile = Encoding.UTF8.GetString(reader.ReadBytes(48));
                    float zSubfileIncrement = reader.ReadSingle();
                    int numWPlanes = reader.ReadInt32();
                    float wPlaneIncrement = reader.ReadSingle();
                    int wAxisUnitsCode = (int)reader.ReadByte();
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
                    DateTime date = new DateTime(year, month, day, hour, minute, 0);


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

                    // TODO: Load log data

                    // TODO: Construct meta
                    Console.WriteLine(date.ToString());
                }
            }
        }
    }
}
