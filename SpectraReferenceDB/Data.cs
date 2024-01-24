using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Xml.Linq;

namespace SpectraReferenceDB
{
    internal class Database {
        string connString;

        public Database(string dbPath) {
            this.connString = $"Data Source={dbPath};Version=3;";

            try {
                // Setup tables (also checks if connection works)
                setupTables();
            } catch (Exception ex) {
                throw ex;
            }

        }

        public void setupTables() {
            using (SQLiteConnection connection = new SQLiteConnection(connString)) {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand()) {
                    command.CommandText = @"CREATE TABLE IF NOT EXISTS spectra_references (
                                        id INTEGER PRIMARY KEY, 
                                        name TEXT NOT NULL UNIQUE,
                                        remarks TEXT DEFAULT '',
                                        opDate DATE NOT NULL,
                                        operator TEXT NOT NULL,
                                        inserter TEXT NOT NULL,
                                        device TEXT NOT NULL,
                                        conditions TEXT DEFAULT '',
                                        filename TEXT NOT NULL UNIQUE,
                                        meta TEXT DEFAULT '');";
                    command.ExecuteNonQuery();
                }
            }
        }

        public int createEntry(Reference reference) {
            int newId = -1;
            using (SQLiteConnection connection = new SQLiteConnection(connString)) {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand()) {
                    command.CommandText = @"INSERT INTO spectra_references (name, remarks, opDate, operator, inserter, device, conditions, filename, meta)
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
                }

                using (SQLiteCommand idCommand = connection.CreateCommand()) {
                    idCommand.CommandText = @"SELECT last_insert_rowid();";
                    object result = idCommand.ExecuteScalar();
                    if (result != null && result != DBNull.Value) {
                        newId = Convert.ToInt32(result);
                    }
                }
            }

            return newId;
        }

        public void updateEntry(Reference reference) {
            if (reference.id == -1) {
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connString)) {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand()) {
                    command.CommandText = @"UPDATE spectra_references SET name = $name, remarks = $remarks, opDate = $date, operator = $operator, 
                                        inserter = $inserter, device = $device, conditions = $conditions, filename = $filename, 
                                        meta = $meta WHERE id = $id;";
                    command.Parameters.AddWithValue("$name", reference.name);
                    command.Parameters.AddWithValue("$remarks", reference.remarks);
                    command.Parameters.AddWithValue("$date", reference.date);
                    command.Parameters.AddWithValue("$operator", reference.operatedBy);
                    command.Parameters.AddWithValue("$inserter", reference.insertedBy);
                    command.Parameters.AddWithValue("$device", reference.deviceName);
                    command.Parameters.AddWithValue("$conditions", reference.conditions);
                    command.Parameters.AddWithValue("$filename", reference.fileName);
                    command.Parameters.AddWithValue("$meta", reference.formatMeta(keyValueSeparator: "=", itemSeparator: ";"));
                    command.Parameters.AddWithValue("$id", reference.id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Reference> allEntries() {
            List<Reference> references = new List<Reference>();

            using (SQLiteConnection connection = new SQLiteConnection(connString)) {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand()) {
                    command.CommandText = @"SELECT * FROM spectra_references;";

                    using (SQLiteDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            references.Add(Reference.FromSqlReader(reader));
                        }
                    }
                }
            }

            return references;
        }

        public List<Reference> search(string searchText) {
            List<Reference> references = new List<Reference>();

            using (SQLiteConnection connection = new SQLiteConnection(connString)) {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand()) {
                    command.CommandText = @"SELECT * FROM spectra_references WHERE 
                                        (LOWER(name) LIKE $s) OR
                                        (LOWER(remarks) LIKE $s) OR
                                        (LOWER(operator) LIKE $s) OR
                                        (LOWER(inserter) LIKE $s) OR
                                        (LOWER(device) LIKE $s) OR
                                        (LOWER(conditions) LIKE $s) OR
                                        (LOWER(filename) LIKE $s) OR
                                        (LOWER(meta) LIKE $s);";
                    command.Parameters.AddWithValue("$s", "%" + searchText.ToLower() + "%");

                    using (SQLiteDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            references.Add(Reference.FromSqlReader(reader));
                        }
                    }
                }
            }

            return references;
        }

        // TODO: Delete entry
        public void deleteEntry(Reference reference) {
            using (SQLiteConnection connection = new SQLiteConnection(connString)) {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand()) {
                    command.CommandText = @"DELETE FROM spectra_references WHERE id = $id;";
                    command.Parameters.AddWithValue("$id", reference.id);
                    command.ExecuteNonQuery();
                }
            }
        }
        
        // TODO: Check for duplicate /w Reference as parameter
        public int findDuplicate(Reference reference) {
            int duplicate = -1;

            using (SQLiteConnection connection = new SQLiteConnection(connString)) {
                connection.Open();

                using (SQLiteCommand command = connection.CreateCommand()) {
                    command.CommandText = @"SELECT id FROM spectra_references WHERE LOWER(name) LIKE $name OR filename LIKE $filename LIMIT 1;";
                    command.Parameters.AddWithValue("$name", reference.name);
                    command.Parameters.AddWithValue("$filename", reference.fileName);

                    Console.WriteLine(command.CommandText);

                    using (SQLiteDataReader reader = command.ExecuteReader()) {
                        if (reader.Read()) {
                            duplicate = reader.GetInt32(0);
                        }
                    }
                }
            }

            return duplicate;
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

            //Console.WriteLine("Log dictionary");
            //foreach (var logItem in referenceFile.logData) {
            //    Console.WriteLine($"{logItem.Key}: \t{logItem.Value}");
            //}

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

        public static Reference FromTxt(string filePath, int numHeaders = -1) {
            DATFile referenceFile;
            if (numHeaders < 0) {
                // Automatically determine header size
                referenceFile = new DATFile(filePath);
            } else {
                referenceFile = new DATFile(filePath, numHeaders);
            }

            if (referenceFile.xData.Length < 1) {
                throw new FormatException("Reference data must have an x-Column");
            }
            if (referenceFile.yData.Length < 1) {
                throw new FormatException("Reference data must have at least one y-Column");
            }

            // Define reference fields
            string referenceName = Path.GetFileNameWithoutExtension(filePath);

            //Console.WriteLine(referenceFile.xData.Length);
            //Console.WriteLine(referenceFile.yData[0].Length);

            //for (int i = 0; i < referenceFile.xData.Length; i++) {
            //    Console.WriteLine($"{referenceFile.xData[i]} \t{referenceFile.yData[0][i]}");
            //}

            return new Reference(
                name: referenceName,
                remarks: "",
                date: DateTime.Now,
                operatedBy: "",
                insertedBy: "",
                deviceName: "",
                conditions: "",
                fileName: filePath,
                metaData: new Dictionary<string, string>(),
                xVals: referenceFile.xData,
                yVals: referenceFile.yData[0]
            );
        }


        public static Reference FromSqlReader(SQLiteDataReader reader) {
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


        public String formatMeta(string keyValueSeparator = " = ", string itemSeparator = "\r\n") {
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

                if (row.Trim() == String.Empty) { continue; }

                string[] rowSplit = row.Split(keyValueSeparator);
                if (rowSplit.Length == 2) {
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
