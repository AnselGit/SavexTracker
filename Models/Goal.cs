namespace SavexTracker.Models
{
    /// <summary>
    /// Represents a savings goal.
    /// </summary>
    public class Goal
    {
        /// <summary>Goal unique identifier.</summary>
        public int Gid { get; set; }
        /// <summary>Goal amount.</summary>
        public double Amount { get; set; }
    }
} 