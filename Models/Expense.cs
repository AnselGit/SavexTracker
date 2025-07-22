namespace SavexTracker.Models
{
    /// <summary>
    /// Represents an expense record.
    /// </summary>
    public class Expense
    {
        /// <summary>Expense unique identifier.</summary>
        public int Eid { get; set; }
        /// <summary>Date and time of the expense.</summary>
        public string Timestamp { get; set; }
        /// <summary>Amount spent.</summary>
        public double Amount { get; set; }
        /// <summary>Optional note for the expense.</summary>
        public string Note { get; set; }
    }
} 