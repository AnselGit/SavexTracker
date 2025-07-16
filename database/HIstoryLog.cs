using SavexTracker;
using System;
using System.Data.SQLite;

namespace SavexTracker.Database
{
    public static class History
    {
        public static void LogHistory(string action, double amount, SQLiteConnection sharedConn = null)
        {
            string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            bool shouldClose = false;

            var conn = sharedConn ?? new SQLiteConnection(AppConfig.ConnectionString);

            if (sharedConn == null)
            {
                conn.Open();
                shouldClose = true;
            }

            string query = "INSERT INTO history (action, amount, timestamp) VALUES (@action, @amount, @timestamp)";
            using (var cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@action", action);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@timestamp", timestamp);
                cmd.ExecuteNonQuery();
            }

            if (shouldClose)
                conn.Close();
        }
    }
}
