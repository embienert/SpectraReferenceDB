using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectraReferenceDB
{
    internal class Reference {
        // Database fields
        public int id;
        public string name;
        public string remarks;
        public DateTime date;
        public string operatedBy;
        public string insertedBy;
        public string deviceName;
        public string conditions;
        public string fileName;
        public Dictionary<string, string> metaData;

        // Internal data
        public double[] xVals;
        public double[] yVals;

        public Reference() {
            this.id = -1;
        }

        public Reference(string name, string remarks, DateTime date, string operatedBy, string insertedBy, string deviceName, string conditions, string fileName, Dictionary<string, string> metaData, double[] xVals, double[] yVals) {
            this.id = -1;
            
            this.name = name;
            this.remarks = remarks;
            this.date = date;
            this.operatedBy = operatedBy;
            this.insertedBy = insertedBy;
            this.deviceName = deviceName;
            this.conditions = conditions;
            this.fileName = fileName;
            this.metaData = metaData;

            this.xVals = xVals;
            this.yVals = yVals;
        }

        public Reference(string name, string remarks, DateTime date, string operatedBy, string insertedBy, string deviceName, string conditions, string fileName, Dictionary<string, string> metaData) {
            this.id = -1;

            this.name = name;
            this.remarks = remarks;
            this.date = date;
            this.operatedBy = operatedBy;
            this.insertedBy = insertedBy;
            this.deviceName = deviceName;
            this.conditions = conditions;
            this.fileName = fileName;
            this.metaData = metaData;

            // TODO: Load x- and y-Data
        }

        public static Reference FromSpc(string filePath) {
            SPCFile referenceFile = new SPCFile(filePath);
            if (referenceFile.xData.Length < 1) {
                throw new FormatException("Reference data must have at least one x-Column");
            }
            if (referenceFile.yData.Length < 1) {
                throw new FormatException("Reference data must have at least one y-Column");
            }

            Console.WriteLine("Log dictionary");
            foreach (var logItem in referenceFile.logData) {
                Console.WriteLine($"{logItem.Key}: \t{logItem.Value}");
            }

            // Define reference fields
            string referenceName = Path.GetFileNameWithoutExtension(filePath);
            string operatedBy = referenceFile.logData.ContainsKey("User_login_name") ? referenceFile.logData["User_login_name"] : "";
            string deviceName = referenceFile.logData.ContainsKey("Spectrometer_Model") ? referenceFile.logData["Spectrometer_Model"] : "";

            // Copy specified keys to metadata for DB
            string[] metaCopyKeys = {
                "Spectrometer_Model",
                "Spectrometer_Serial_Number",
                "Detector_Temperature_C",
                "Intensity_Calibration_File",
                "Exposure_Length_ms",
                "Accumulations",
                "Wavelength_Calibration_File",
                "Laser_Calibration_File",
                "Channel_1_Laser_Wavelength",
                "Spectrometer_ConfigurationName",
                "Sample_is_Saturated",
            };
            Dictionary<string, string> meta = new Dictionary<string, string>();
            foreach (var key in metaCopyKeys) {
                if (referenceFile.logData.ContainsKey(key)) {
                    meta[key] = referenceFile.logData[key];
                }
            }

            return new Reference(
                name: referenceName,
                remarks: "",
                date: referenceFile.date,
                operatedBy: operatedBy,
                insertedBy: "",
                deviceName: deviceName,
                conditions: "",
                fileName: filePath,
                metaData: meta,
                xVals: referenceFile.xData[0],
                yVals: referenceFile.yData[0]
            );        
        }

        public static Reference FromTxt() { 
            // TODO: TXT file loading logic
            return new Reference(); 
        }


        public override string ToString() {
            string repr = "";

            for (int i = 0; i < xVals.Length; i++) {
                repr += xVals[i].ToString() + "\t" + yVals[i] + "\n";
            }

            return repr;
        }


        public String formatMeta(string keyValueSeparator = " = ", string itemSeparator = "\n") {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this.metaData) {
                sb.Append(item.Key.ToString());
                sb.Append(keyValueSeparator);
                sb.Append(item.Value.ToString());
                sb.Append(itemSeparator);
            }

            return sb.ToString();
        }
    }
}
