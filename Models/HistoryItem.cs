namespace SavexTracker.Models
{
    /// <summary>
    /// Represents a single history log entry.
    /// </summary>
    public class HistoryItem
    {
        /// <summary>History entry unique identifier.</summary>
        public int Id { get; set; }
        /// <summary>Description of the action performed.</summary>
        public string Action { get; set; }
        /// <summary>Amount involved in the action (if any).</summary>
        public double? Amount { get; set; }
        /// <summary>Date and time of the action.</summary>
        public string Timestamp { get; set; }
    }
} 