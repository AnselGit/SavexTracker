using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using SavexTracker.Models;
using System.Windows.Forms;
using System.Linq; // Added for .Any()

namespace SavexTracker.Database
{
    public static class CRUD
    {
        // Ensure tables exist
        public static void EnsureDatabaseAndTables()
        {
            string dbPath = AppConfig.DbPath;
            bool dbExists = File.Exists(dbPath);
            if (!dbExists)
                SQLiteConnection.CreateFile(dbPath);
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string createSavingsTable = @"CREATE TABLE IF NOT EXISTS savings (sid INTEGER PRIMARY KEY AUTOINCREMENT, timestamp TEXT NOT NULL, amount REAL NOT NULL);";
                string createArchiveTable = @"CREATE TABLE IF NOT EXISTS archive (aid INTEGER PRIMARY KEY AUTOINCREMENT, sid INTEGER, eid INTEGER, name TEXT, timestamp1 TEXT, amount1 REAL, timestamp2 TEXT, amount2 REAL, note TEXT);";
                string createExpensesTable = @"CREATE TABLE IF NOT EXISTS expenses (eid INTEGER PRIMARY KEY AUTOINCREMENT, timestamp TEXT NOT NULL, amount REAL NOT NULL, note TEXT);";
                string createHistoryTable = @"CREATE TABLE IF NOT EXISTS history (id INTEGER PRIMARY KEY AUTOINCREMENT, action TEXT NOT NULL, amount REAL, timestamp TEXT NOT NULL);";
                string createGoalTable = @"CREATE TABLE IF NOT EXISTS goal (gid INTEGER PRIMARY KEY AUTOINCREMENT, amount REAL NOT NULL);";
                // Add indexes for performance
                string createSavingsTimestampIdx = @"CREATE INDEX IF NOT EXISTS idx_savings_timestamp ON savings(timestamp);";
                string createSavingsAmountIdx = @"CREATE INDEX IF NOT EXISTS idx_savings_amount ON savings(amount);";
                string createExpensesTimestampIdx = @"CREATE INDEX IF NOT EXISTS idx_expenses_timestamp ON expenses(timestamp);";
                string createExpensesAmountIdx = @"CREATE INDEX IF NOT EXISTS idx_expenses_amount ON expenses(amount);";
                string createExpensesNoteIdx = @"CREATE INDEX IF NOT EXISTS idx_expenses_note ON expenses(note);";
                new SQLiteCommand(createSavingsTable, conn).ExecuteNonQuery();
                new SQLiteCommand(createArchiveTable, conn).ExecuteNonQuery();
                new SQLiteCommand(createExpensesTable, conn).ExecuteNonQuery();
                new SQLiteCommand(createHistoryTable, conn).ExecuteNonQuery();
                new SQLiteCommand(createGoalTable, conn).ExecuteNonQuery();
                // Create indexes
                new SQLiteCommand(createSavingsTimestampIdx, conn).ExecuteNonQuery();
                new SQLiteCommand(createSavingsAmountIdx, conn).ExecuteNonQuery();
                new SQLiteCommand(createExpensesTimestampIdx, conn).ExecuteNonQuery();
                new SQLiteCommand(createExpensesAmountIdx, conn).ExecuteNonQuery();
                new SQLiteCommand(createExpensesNoteIdx, conn).ExecuteNonQuery();
            }
        }

        // Load all data and assign to GlobalData
        public static void LoadAllDataToGlobals()
        {
            GlobalData.AllSavings = GetAllSavings();
            GlobalData.AllExpenses = GetAllExpenses();
            GlobalData.AllArchive = GetAllArchive();
            GlobalData.AllHistory = GetAllHistory();
            GlobalData.CurrentGoal = GetLatestGoalAmount();
        }

        public static List<Saving> GetAllSavings()
        {
            var list = new List<Saving>();
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "SELECT sid, timestamp, amount FROM savings ORDER BY sid DESC";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Saving
                        {
                            Sid = Convert.ToInt32(reader["sid"]),
                            Timestamp = reader["timestamp"].ToString(),
                            Amount = Convert.ToDouble(reader["amount"])
                        });
                    }
                }
            }
            return list;
        }

        public static List<Saving> GetAllSavings(int limit, int offset)
        {
            var list = new List<Saving>();
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "SELECT sid, timestamp, amount FROM savings ORDER BY sid DESC LIMIT @limit OFFSET @offset";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@limit", limit);
                    cmd.Parameters.AddWithValue("@offset", offset);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Saving
                            {
                                Sid = Convert.ToInt32(reader["sid"]),
                                Timestamp = reader["timestamp"].ToString(),
                                Amount = Convert.ToDouble(reader["amount"])
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static List<Expense> GetAllExpenses()
        {
            var list = new List<Expense>();
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "SELECT eid, timestamp, amount, note FROM expenses ORDER BY eid DESC";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Expense
                        {
                            Eid = Convert.ToInt32(reader["eid"]),
                            Timestamp = reader["timestamp"].ToString(),
                            Amount = Convert.ToDouble(reader["amount"]),
                            Note = reader["note"] != DBNull.Value ? reader["note"].ToString() : ""
                        });
                    }
                }
            }
            return list;
        }

        public static List<Expense> GetAllExpenses(int limit, int offset)
        {
            var list = new List<Expense>();
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "SELECT eid, timestamp, amount, note FROM expenses ORDER BY eid DESC LIMIT @limit OFFSET @offset";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@limit", limit);
                    cmd.Parameters.AddWithValue("@offset", offset);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Expense
                            {
                                Eid = Convert.ToInt32(reader["eid"]),
                                Timestamp = reader["timestamp"].ToString(),
                                Amount = Convert.ToDouble(reader["amount"]),
                                Note = reader["note"] != DBNull.Value ? reader["note"].ToString() : ""
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static List<ArchiveItem> GetAllArchive()
        {
            var list = new List<ArchiveItem>();
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "SELECT aid, sid, eid, name, timestamp1, amount1, timestamp2, amount2, note FROM archive ORDER BY ROWID DESC";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ArchiveItem
                        {
                            Aid = Convert.ToInt32(reader["aid"]),
                            Sid = reader["sid"] != DBNull.Value ? (int?)Convert.ToInt32(reader["sid"]) : null,
                            Eid = reader["eid"] != DBNull.Value ? (int?)Convert.ToInt32(reader["eid"]) : null,
                            Name = reader["name"].ToString(),
                            Timestamp1 = reader["timestamp1"]?.ToString(),
                            Amount1 = reader["amount1"] != DBNull.Value ? (double?)Convert.ToDouble(reader["amount1"]) : null,
                            Timestamp2 = reader["timestamp2"]?.ToString(),
                            Amount2 = reader["amount2"] != DBNull.Value ? (double?)Convert.ToDouble(reader["amount2"]) : null,
                            Note = reader["note"]?.ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static List<HistoryItem> GetAllHistory()
        {
            var list = new List<HistoryItem>();
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "SELECT id, action, amount, timestamp FROM history ORDER BY id DESC";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new HistoryItem
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Action = reader["action"].ToString(),
                            Amount = reader["amount"] != DBNull.Value ? (double?)Convert.ToDouble(reader["amount"]) : null,
                            Timestamp = reader["timestamp"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static double GetLatestGoalAmount()
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "SELECT amount FROM goal ORDER BY gid DESC LIMIT 1;";
                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        return Convert.ToDouble(reader["amount"]);
                }
            }
            return 0;
        }

        public static double GetTotalSavings()
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT IFNULL(SUM(amount), 0) FROM savings", conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
        }

        public static double GetTotalExpenses()
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT IFNULL(SUM(amount), 0) FROM expenses", conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
            }
        }

        public static int GetSavingsCount()
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM savings";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static int GetExpensesCount()
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM expenses";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public static void LogHistory(string action, double amount, DateTime? timestamp = null)
        {
            string ts = (timestamp ?? DateTime.Now).ToString("yyyy-MM-dd HH:mm:ss");
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO history (action, amount, timestamp) VALUES (@action, @amount, @timestamp)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@action", action);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@timestamp", ts);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool IsTableEmpty(string tableName)
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = $"SELECT COUNT(*) FROM {tableName}";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    long count = (long)cmd.ExecuteScalar();
                    return count == 0;
                }
            }
        }

        public static void DeleteAllHistory()
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM history";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateGoalAmount(double newAmount)
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                // Check if there is already a goal row
                string countQuery = "SELECT COUNT(*) FROM goal";
                long count = 0;
                using (var countCmd = new SQLiteCommand(countQuery, conn))
                {
                    count = (long)countCmd.ExecuteScalar();
                }
                if (count == 0)
                {
                    // Insert new goal
                    string insertQuery = "INSERT INTO goal (amount) VALUES (@amount)";
                    using (var insertCmd = new SQLiteCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@amount", newAmount);
                        insertCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Update the latest goal row
                    string updateQuery = "UPDATE goal SET amount = @amount WHERE gid = (SELECT gid FROM goal ORDER BY gid DESC LIMIT 1)";
                    using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@amount", newAmount);
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Add a new saving and log history
        public static void AddSaving(Saving saving)
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO savings (timestamp, amount) VALUES (@timestamp, @amount);";
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@timestamp", saving.Timestamp);
                    cmd.Parameters.AddWithValue("@amount", saving.Amount);
                    cmd.ExecuteNonQuery();
                }
                LogHistory("Added savings", saving.Amount, DateTime.Now);
            }
        }

        // Add a new expense and log history
        public static void AddExpense(Expense expense)
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string insertQuery = "INSERT INTO expenses (timestamp, amount, note) VALUES (@timestamp, @amount, @note);";
                using (var cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@timestamp", expense.Timestamp);
                    cmd.Parameters.AddWithValue("@amount", expense.Amount);
                    cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(expense.Note) ? (object)DBNull.Value : expense.Note);
                    cmd.ExecuteNonQuery();
                }
                LogHistory("Added expense", expense.Amount, DateTime.Now);
            }
        }

        // Update a saving and log history
        public static void UpdateSaving(int id, string date, double amount)
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string updateQuery = "UPDATE savings SET timestamp = @timestamp, amount = @amount WHERE sid = @sid";
                using (var cmd = new SQLiteCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@timestamp", date);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@sid", id);
                    int affected = cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        LogHistory("Updated savings", amount, DateTime.Now);
                    }
                }
            }
        }

        // Update an expense and log history
        public static void UpdateExpense(int id, string date, double amount, string note)
        {
            try
            {
                using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE expenses SET [timestamp] = @timestamp, amount = @amount, note = @note WHERE eid = @eid";
                    using (var cmd = new SQLiteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@timestamp", date);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@note", note);
                        cmd.Parameters.AddWithValue("@eid", id);
                        int affected = cmd.ExecuteNonQuery();
                        if (affected > 0)
                        {
                            LogHistory("Updated expense", amount, DateTime.Now);
                        }
                        else
                        {
                            MessageBox.Show($"No expense record was updated. ID={id} may not exist.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating expense: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Archive a saving or expense and log history
        public static void ArchiveItem(int id, string type)
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string timestamp = "";
                double amount = 0;
                string note = "";
                bool found = false;
                if (type == "Savings")
                {
                    using (var cmd = new SQLiteCommand("SELECT timestamp, amount FROM savings WHERE sid = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                timestamp = reader["timestamp"].ToString();
                                amount = Convert.ToDouble(reader["amount"]);
                                found = true;
                            }
                        }
                    }
                }
                else if (type == "Expenses")
                {
                    using (var cmd = new SQLiteCommand("SELECT timestamp, amount, note FROM expenses WHERE eid = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                timestamp = reader["timestamp"].ToString();
                                amount = Convert.ToDouble(reader["amount"]);
                                note = reader["note"]?.ToString();
                                found = true;
                            }
                        }
                    }
                }
                if (!found)
                {
                    LogHistory($"Tried to archive non-existent {type}", 0, DateTime.Now);
                    return;
                }
                // Insert into archive
                string insertQuery = @"INSERT INTO archive (sid, eid, name, timestamp1, amount1, timestamp2, amount2, note) VALUES (@sid, @eid, @name, @timestamp1, @amount1, @timestamp2, @amount2, @note);";
                using (var insertCmd = new SQLiteCommand(insertQuery, conn))
                {
                    if (type == "Savings")
                    {
                        insertCmd.Parameters.AddWithValue("@sid", id);
                        insertCmd.Parameters.AddWithValue("@eid", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@name", "Savings");
                        insertCmd.Parameters.AddWithValue("@timestamp1", timestamp);
                        insertCmd.Parameters.AddWithValue("@amount1", amount);
                        insertCmd.Parameters.AddWithValue("@timestamp2", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@amount2", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@note", DBNull.Value);
                    }
                    else
                    {
                        insertCmd.Parameters.AddWithValue("@sid", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@eid", id);
                        insertCmd.Parameters.AddWithValue("@name", "Expenses");
                        insertCmd.Parameters.AddWithValue("@timestamp1", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@amount1", DBNull.Value);
                        insertCmd.Parameters.AddWithValue("@timestamp2", timestamp);
                        insertCmd.Parameters.AddWithValue("@amount2", amount);
                        insertCmd.Parameters.AddWithValue("@note", note);
                    }
                    insertCmd.ExecuteNonQuery();
                }
                // Delete from original table
                string deleteQuery = type == "Savings" ? "DELETE FROM savings WHERE sid = @id" : "DELETE FROM expenses WHERE eid = @id";
                using (var deleteCmd = new SQLiteCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@id", id);
                    deleteCmd.ExecuteNonQuery();
                }
                // Log
                string action = type == "Savings" ? "Removed savings" : "Removed expense";
                LogHistory(action, amount, DateTime.Now);
            }
        }

        // Restore an archive item and log history
        public static void RestoreArchiveItem(int id, string type)
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM archive WHERE sid = @id OR eid = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (type == "Savings")
                            {
                                string timestamp = reader["timestamp1"].ToString();
                                double amount = Convert.ToDouble(reader["amount1"]);
                                using (var insertCmd = new SQLiteCommand("INSERT INTO savings (timestamp, amount) VALUES (@timestamp, @amount)", conn))
                                {
                                    insertCmd.Parameters.AddWithValue("@timestamp", timestamp);
                                    insertCmd.Parameters.AddWithValue("@amount", amount);
                                    insertCmd.ExecuteNonQuery();
                                }
                                LogHistory("Restored savings", amount, DateTime.Now);
                            }
                            else if (type == "Expenses")
                            {
                                string timestamp = reader["timestamp2"].ToString();
                                double amount = Convert.ToDouble(reader["amount2"]);
                                string note = reader["note"]?.ToString();
                                using (var insertCmd = new SQLiteCommand("INSERT INTO expenses (timestamp, amount, note) VALUES (@timestamp, @amount, @note)", conn))
                                {
                                    insertCmd.Parameters.AddWithValue("@timestamp", timestamp);
                                    insertCmd.Parameters.AddWithValue("@amount", amount);
                                    insertCmd.Parameters.AddWithValue("@note", note);
                                    insertCmd.ExecuteNonQuery();
                                }
                                LogHistory("Restored expense", amount, DateTime.Now);
                            }
                        }
                    }
                }
                // Delete from archive
                string deleteQuery = "DELETE FROM archive WHERE sid = @id OR eid = @id";
                using (var deleteCmd = new SQLiteCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@id", id);
                    deleteCmd.ExecuteNonQuery();
                }
            }
        }

        // Delete an archive item and log history
        public static void DeleteArchiveItem(int id, string type)
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                double? amountToLog = null;
                string getAmountQuery = "SELECT amount1, amount2 FROM archive WHERE sid = @id OR eid = @id";
                using (var getCmd = new SQLiteCommand(getAmountQuery, conn))
                {
                    getCmd.Parameters.AddWithValue("@id", id);
                    using (var reader = getCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (type == "Savings" && reader["amount1"] != DBNull.Value)
                                amountToLog = Convert.ToDouble(reader["amount1"]);
                            else if (type == "Expenses" && reader["amount2"] != DBNull.Value)
                                amountToLog = Convert.ToDouble(reader["amount2"]);
                        }
                    }
                }
                string deleteQuery = "DELETE FROM archive WHERE " + (type == "Savings" ? "sid" : "eid") + " = @id";
                using (var cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                if (amountToLog.HasValue)
                {
                    string logText = type == "Savings" ? "Deleted savings" : "Deleted expense";
                    LogHistory(logText, amountToLog.Value, DateTime.Now);
                }
            }
        }

        /// <summary>
        /// Searches both savings and expenses tables for entries matching the search term in date (month name), amount, or note.
        /// Returns a list of SearchResultItem (Date, Type, Amount, Note).
        /// </summary>
        public static List<SearchResultItem> SearchSavingsAndExpenses(string searchTerm)
        {
            var results = new List<SearchResultItem>();
            string lowerTerm = searchTerm?.ToLower() ?? string.Empty;
            bool hasSearch = !string.IsNullOrWhiteSpace(lowerTerm);

            // Split into words for AND search
            var terms = lowerTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Helper for month names/abbr
            string[] monthNames = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat.MonthNames;
            string[] monthAbbrs = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat.AbbreviatedMonthNames;

            // Search Savings
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = hasSearch ?
                    "SELECT sid, timestamp, amount FROM savings ORDER BY sid DESC" :
                    "SELECT sid, timestamp, amount FROM savings ORDER BY sid DESC";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string timestamp = reader["timestamp"].ToString();
                            double amount = Convert.ToDouble(reader["amount"]);
                            string type = "savings";
                            string amountStr = amount.ToString("0.##");
                            string dateStr = timestamp.ToLower();
                            string monthName = "", monthAbbr = "", year = "";
                            try {
                                var dt = DateTime.ParseExact(timestamp, "MM/dd/yy", System.Globalization.CultureInfo.InvariantCulture);
                                monthName = dt.ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture).ToLower();
                                monthAbbr = dt.ToString("MMM", System.Globalization.CultureInfo.InvariantCulture).ToLower();
                                year = dt.ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            } catch {
                                try {
                                    var dt = DateTime.Parse(timestamp);
                                    monthName = dt.ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture).ToLower();
                                    monthAbbr = dt.ToString("MMM", System.Globalization.CultureInfo.InvariantCulture).ToLower();
                                    year = dt.ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                } catch { }
                            }
                            bool match = true;
                            if (hasSearch && terms.Length > 0)
                            {
                                foreach (var term in terms)
                                {
                                    bool termMatch = false;
                                    // Type
                                    if (type.Contains(term)) termMatch = true;
                                    // Date
                                    if (dateStr.Contains(term) || monthName.Contains(term) || monthAbbr.Contains(term) || year.Contains(term)) termMatch = true;
                                    // Amount
                                    if (amountStr.Contains(term)) termMatch = true;
                                    // Month name/abbr
                                    if (monthNames.Any(m => m.ToLower().StartsWith(term)) || monthAbbrs.Any(m => m.ToLower().StartsWith(term))) termMatch = true;
                                    if (!termMatch) { match = false; break; }
                                }
                            }
                            if (match)
                            {
                                results.Add(new SearchResultItem
                                {
                                    Date = timestamp,
                                    Type = "Savings",
                                    Amount = amount,
                                    Note = ""
                                });
                            }
                        }
                    }
                }
            }

            // Search Expenses
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                string query = hasSearch ?
                    "SELECT eid, timestamp, amount, note FROM expenses ORDER BY eid DESC" :
                    "SELECT eid, timestamp, amount, note FROM expenses ORDER BY eid DESC";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string timestamp = reader["timestamp"].ToString();
                            double amount = Convert.ToDouble(reader["amount"]);
                            string note = reader["note"] != DBNull.Value ? reader["note"].ToString() : "";
                            string type = "expense";
                            string amountStr = amount.ToString("0.##");
                            string dateStr = timestamp.ToLower();
                            string monthName = "", monthAbbr = "", year = "";
                            try {
                                var dt = DateTime.ParseExact(timestamp, "MM/dd/yy", System.Globalization.CultureInfo.InvariantCulture);
                                monthName = dt.ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture).ToLower();
                                monthAbbr = dt.ToString("MMM", System.Globalization.CultureInfo.InvariantCulture).ToLower();
                                year = dt.ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture);
                            } catch {
                                try {
                                    var dt = DateTime.Parse(timestamp);
                                    monthName = dt.ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture).ToLower();
                                    monthAbbr = dt.ToString("MMM", System.Globalization.CultureInfo.InvariantCulture).ToLower();
                                    year = dt.ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture);
                                } catch { }
                            }
                            bool match = true;
                            if (hasSearch && terms.Length > 0)
                            {
                                foreach (var term in terms)
                                {
                                    bool termMatch = false;
                                    // Type
                                    if (type.Contains(term)) termMatch = true;
                                    // Date
                                    if (dateStr.Contains(term) || monthName.Contains(term) || monthAbbr.Contains(term) || year.Contains(term)) termMatch = true;
                                    // Amount
                                    if (amountStr.Contains(term)) termMatch = true;
                                    // Note
                                    if (!string.IsNullOrEmpty(note) && note.ToLower().Contains(term)) termMatch = true;
                                    // Month name/abbr
                                    if (monthNames.Any(m => m.ToLower().StartsWith(term)) || monthAbbrs.Any(m => m.ToLower().StartsWith(term))) termMatch = true;
                                    if (!termMatch) { match = false; break; }
                                }
                            }
                            if (match)
                            {
                                results.Add(new SearchResultItem
                                {
                                    Date = timestamp,
                                    Type = "Expense",
                                    Amount = amount,
                                    Note = note
                                });
                            }
                        }
                    }
                }
            }

            return results;
        }

        public static void RestoreArchiveItems(List<(int id, string type)> items)
        {
            using (var conn = new SQLiteConnection(AppConfig.ConnectionString))
            {
                conn.Open();
                foreach (var (id, type) in items)
                {
                    // Use type-specific query to avoid mismatches
                    string query = type == "Savings"
                        ? "SELECT * FROM archive WHERE sid = @id AND name = 'Savings'"
                        : "SELECT * FROM archive WHERE eid = @id AND name = 'Expenses'";
                    string timestamp = null, note = null;
                    double? amount = null;
                    bool isSavings = type == "Savings";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                if (isSavings)
                                {
                                    timestamp = reader["timestamp1"].ToString();
                                    amount = reader["amount1"] != DBNull.Value ? Convert.ToDouble(reader["amount1"]) : 0.0;
                                }
                                else
                                {
                                    timestamp = reader["timestamp2"].ToString();                                    
                                    amount = reader["amount2"] != DBNull.Value ? Convert.ToDouble(reader["amount2"]) : 0.0;
                                    note = reader["note"] != DBNull.Value ? reader["note"].ToString() : "";
                                }
                            }
                        }
                    }
                    // 2. Now insert and delete (reader is closed)
                    if (isSavings && timestamp != null && amount.HasValue)
                    {
                        using (var insertCmd = new SQLiteCommand("INSERT INTO savings (timestamp, amount) VALUES (@timestamp, @amount)", conn))
                        {
                            insertCmd.Parameters.AddWithValue("@timestamp", timestamp);
                            insertCmd.Parameters.AddWithValue("@amount", amount.Value);
                            insertCmd.ExecuteNonQuery();
                        }
                        LogHistory("Restored savings", amount.Value, DateTime.Now);
                    }
                    else if (!isSavings && timestamp != null && amount.HasValue)
                    {
                        using (var insertCmd = new SQLiteCommand("INSERT INTO expenses (timestamp, amount, note) VALUES (@timestamp, @amount, @note)", conn))
                        {
                            insertCmd.Parameters.AddWithValue("@timestamp", timestamp);
                            insertCmd.Parameters.AddWithValue("@amount", amount.Value);
                            insertCmd.Parameters.AddWithValue("@note", note);
                            insertCmd.ExecuteNonQuery();
                        }
                        LogHistory("Restored expense", amount.Value, DateTime.Now);
                    }
                    // 3. Delete from archive
                    string deleteQuery = "DELETE FROM archive WHERE sid = @id OR eid = @id";
                    using (var deleteCmd = new SQLiteCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", id);
                        deleteCmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
} 