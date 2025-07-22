using SavexTracker;
using System;
using System.Data.SQLite;

namespace SavexTracker.Database
{
    /// <summary>
    /// Provides methods for logging history actions to the database.
    /// </summary>
    public static class History
    {
        /// <summary>
        /// Logs a history action with the specified action, amount, and timestamp.
        /// </summary>
        /// <param name="action">The action performed (e.g., "Added savings").</param>
        /// <param name="amount">The amount involved in the action.</param>
        /// <param name="sharedConn">Optional shared SQLite connection.</param>
        public static void LogHistory(string action, double amount, System.Data.SQLite.SQLiteConnection sharedConn = null)
        {
            string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            bool shouldClose = false;

            var conn = sharedConn ?? new System.Data.SQLite.SQLiteConnection(AppConfig.ConnectionString);

            if (sharedConn == null)
            {
                conn.Open();
                shouldClose = true;
            }

            string query = "INSERT INTO history (action, amount, timestamp) VALUES (@action, @amount, @timestamp)";
            using (var cmd = new System.Data.SQLite.SQLiteCommand(query, conn))
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