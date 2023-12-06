using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectraReferenceDB
{
    internal class ReferenceFile {
        public double[] xVals;
        public double[] yVals;
        public DateTime date;
        public string deviceName;
        public string conditions;  // Can this be automatically obtained? 
        public Dictionary<string, string> metaData;

        // TODO: Have all essential (see specifications) attributes as own fields and not in metaData!
        // TODO: Have all data from one DB entry here?

        public ReferenceFile(double[] x, double[] y, Dictionary<string, string> meta) {
            this.xVals = new double[x.Length];
            Array.Copy(x, xVals, x.Length);

            this.yVals = new double[y.Length];
            Array.Copy(y, yVals, y.Length);

            this.metaData = new Dictionary<string, string>(meta);
        }

        public static ReferenceFile FromSpc(string filePath) {
            // int, 4 bytes
            // byte, 1 byte
            // double, 8 bytes
            // float, 4 bytes
            // word, 2 bytes

            

            return new ReferenceFile(xVals, yVals, new Dictionary<string, string>());
        }

        public static ReferenceFile FromTxt() { 
            // TODO: TXT file loading logic
            return new ReferenceFile(new double[0], new double[0], new Dictionary<string, string>()); 
        }


        public override string ToString() {
            string repr = "";

            for (int i = 0; i < xVals.Length; i++) {
                repr += xVals[i].ToString() + "\t" + yVals[i] + "\n";
            }

            return repr;
        }
    }
}
