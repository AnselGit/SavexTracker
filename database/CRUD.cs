using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using SavexTracker.Models;

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
                new SQLiteCommand(createSavingsTable, conn).ExecuteNonQuery();
                new SQLiteCommand(createArchiveTable, conn).ExecuteNonQuery();
                new SQLiteCommand(createExpensesTable, conn).ExecuteNonQuery();
                new SQLiteCommand(createHistoryTable, conn).ExecuteNonQuery();
                new SQLiteCommand(createGoalTable, conn).ExecuteNonQuery();
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

        // Add more CRUD methods as needed (AddSaving, AddExpense, UpdateSaving, etc.)
        // ...
    }
} 