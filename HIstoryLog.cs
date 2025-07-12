using System;
using System.Data.SQLite;

namespace SavexTracker
{
    public static class History
    {
        public static void LogHistory(string action, double amount)
        {
            string connStr = AppConfig.ConnectionString;
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO history (action, amount, timestamp) VALUES (@action, @amount, @timestamp)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@action", action);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@timestamp", timestamp);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
