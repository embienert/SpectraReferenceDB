using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace SpectraReferenceDB
{
    internal class Database {
        SqliteConnection connection;

        public Database(string dbPath) {
            this.connection = new SqliteConnection($"Data Source={dbPath};Version=3;");

            try {
                // Check if connection works
                this.connection.Open();
                this.connection.Close();
            } catch { }

        }


        public void setupTables() {
            this.connection.Open();

            SqliteCommand command = this.connection.CreateCommand();
            command.CommandText = @"CREATE TABLE IF NOT EXISTS references (
                                        id INTEGER PRIMARY KEY, 
                                        name TEXT NOT NULL UNIQUE,
                                        remarks TEXT DEFAULT '',
                                        date DATE NOT NULL,
                                        operator TEXT NOT NULL,
                                        inserter TEXT NOT NULL,
                                        device TEXT NOT NULL,
                                        conditions TEXT DEFAULT '',
                                        filename TEXT NOT NULL UNIQUE,
                                        meta TEXT DEFAULT '');";
            command.ExecuteNonQuery();

            this.connection.Close();
        }


        public void createEntry(Reference reference) {
            this.connection.Open();

            SqliteCommand command = this.connection.CreateCommand();
            command.CommandText = @"INSERT INTO references (name, remarks, date, operator, inserter, device, conditions, filename, meta)
                                        VALUES ($name, $remarks, $date, $operator, $inserter, $device, $conditions, $filename, $meta);";
            command.Parameters.AddWithValue("$name", reference.name);
            command.Parameters.AddWithValue("$remarks", reference.remarks);
            command.Parameters.AddWithValue("$date", reference.date);
            command.Parameters.AddWithValue("$operator", reference.operatedBy);
            command.Parameters.AddWithValue("$inserter", reference.insertedBy);
            command.Parameters.AddWithValue("$device", reference.deviceName);
            command.Parameters.AddWithValue("$conditions", reference.conditions);
            command.Parameters.AddWithValue("$filename", reference.fileName);
            command.Parameters.AddWithValue("$meta", reference.formatMeta(keyValueSeparator: "=", itemSeparator: ";"));
            command.ExecuteNonQuery();

            this.connection.Close();
        }

        public List<Reference> allEntries() {
            this.connection.Open();

            SqliteCommand command = this.connection.CreateCommand();
            command.CommandText = @"SELECT * FROM references;";

            SqliteDataReader reader = command.ExecuteReader();
            List<Reference> references = new List<Reference>();
            while (reader.Read()) {
                references.Add(Reference.FromSqlReader(reader));
            }

            this.connection.Close();

            return references;
        }

        public List<Reference> search(string searchText) {
            this.connection.Open();

            SqliteCommand command = this.connection.CreateCommand();
            command.CommandText = @"SELECT * FROM references WHERE 
                                        (LOWER(name) LIKE LOWER(%$s%)) OR
                                        (LOWER(remarks) LIKE LOWER(%$s%)) OR
                                        (LOWER(operator) LIKE LOWER(%$s%)) OR
                                        (LOWER(inserter) LIKE LOWER(%$s%)) OR
                                        (LOWER(device) LIKE LOWER(%$s%)) OR
                                        (LOWER(conditions) LIKE LOWER(%$s%)) OR
                                        (LOWER(filename) LIKE LOWER(%$s%)) OR
                                        (LOWER(meta) LIKE LOWER(%$s%));";
            command.Parameters.AddWithValue("$s", searchText);

            SqliteDataReader reader = command.ExecuteReader();
            List<Reference> references = new List<Reference>();
            while (reader.Read()) {
                references.Add(Reference.FromSqlReader(reader));
            }

            this.connection.Close();

            return references;
        }
    }


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

        public Reference(string name, string remarks, DateTime date, string operatedBy, string insertedBy, string deviceName, string conditions, string fileName, Dictionary<string, string> metaData, double[] xVals = null, double[] yVals = null, int id = -1) {
            this.id = id;
            
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


        public static Reference FromSqlReader(SqliteDataReader reader) {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string remarks = reader.GetString(2);
            DateTime date = reader.GetDateTime(3);
            string operatedBy = reader.GetString(4);
            string insertedBy = reader.GetString(5);
            string deviceName = reader.GetString(6);
            string conditions = reader.GetString(7);
            string fileName = reader.GetString(8);
            string metaString = reader.GetString(9);

            Reference reference = new Reference(
                id: id,
                name: name,
                remarks: remarks,
                date: date,
                operatedBy: operatedBy,
                insertedBy: insertedBy,
                deviceName: deviceName,
                conditions: conditions,
                fileName: fileName,
                metaData: new Dictionary<string, string>()
            );
            reference.parseMeta(metaString, itemSeparator: ';', strict: true);

            return reference;
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

        public int parseMeta(string metaRaw, char keyValueSeparator = '=', char itemSeparator = '\n', bool strict = false) {
            this.metaData = new Dictionary<string, string>();
            string[] metaRows = metaRaw.Trim().Split(itemSeparator);

            for (int i = 0; i < metaRows.Length; i++) {
                string row = metaRows[i];

                if (row.Contains(keyValueSeparator)) {
                    string[] rowSplit = row.Split(keyValueSeparator);
                    string key = rowSplit[0].Trim();
                    string value = rowSplit[1].Trim();

                    metaData[key] = value;
                } else if (strict) {
                    return i+1;
                }
            }

            return 0;
        }
    }
}
