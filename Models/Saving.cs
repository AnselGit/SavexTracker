namespace SavexTracker.Models
{
    /// <summary>
    /// Represents a savings record.
    /// </summary>
    public class Saving
    {
        /// <summary>Savings unique identifier.</summary>
        public int Sid { get; set; }
        /// <summary>Date and time of the saving.</summary>
        public string Timestamp { get; set; }
        /// <summary>Amount saved.</summary>
        public double Amount { get; set; }
    }
} 