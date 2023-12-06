using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectraReferenceDB
{
    internal class ReferenceFile {
        public ReferenceFile() {
            
        }

        public static ReferenceFile FromSpc(string filePath, int maxSubfiles = int.MaxValue) { 
            // int, 4 bytes
            // byte, 1 byte
            // double, 8 bytes
            // float, 4 bytes
            // word, 2 bytes

            // TODO: SPC file loading logic
            using (FileStream stream = File.OpenRead(filePath)) {
                using (BinaryReader reader = new BinaryReader(stream)) {
                    // Main header
                    int flags = (int)reader.ReadByte();
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
                    byte[] spare = reader.ReadBytes(8*4);  // What datatype? (Source reads as 8 floats)
                    string memo = Encoding.UTF8.GetString(reader.ReadBytes(130));
                    string customAxisLabels = Encoding.UTF8.GetString(reader.ReadBytes(30));
                    int byteOffsetToLogBlock = reader.ReadInt32();
                    int fileModificationFlag = reader.ReadInt32();
                    int processingCode = (int)reader.ReadByte();
                    int calibrationLevel = (int)reader.ReadByte();
                    short subMethodSampleInjectorNumber = reader.ReadInt16();
                    float dataMultiplierConcentration = reader.ReadSingle();
                    byte[] methodFile = reader.ReadBytes(48);
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



                    for (int subfile = 0; subfile < Math.Min(numSubfiles, maxSubfiles); subfile++) {

                    }
                }
            }


            return new ReferenceFile();
        }

        public static ReferenceFile FromTxt() { 
            // TODO: TXT file loading logic
            return new ReferenceFile(); 
        }
    }
}
