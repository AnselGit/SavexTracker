namespace SavexTracker.Models
{
    /// <summary>
    /// Represents an archived record for either a saving or an expense.
    /// </summary>
    public class ArchiveItem
    {
        /// <summary>Archive item unique identifier.</summary>
        public int Aid { get; set; }
        /// <summary>Saving ID if this is a saving archive record.</summary>
        public int? Sid { get; set; }
        /// <summary>Expense ID if this is an expense archive record.</summary>
        public int? Eid { get; set; }
        /// <summary>Type of record ("Savings" or "Expenses").</summary>
        public string Name { get; set; }
        /// <summary>Timestamp for savings record.</summary>
        public string Timestamp1 { get; set; }
        /// <summary>Amount for savings record.</summary>
        public double? Amount1 { get; set; }
        /// <summary>Timestamp for expenses record.</summary>
        public string Timestamp2 { get; set; }
        /// <summary>Amount for expenses record.</summary>
        public double? Amount2 { get; set; }
        /// <summary>Note for expenses record.</summary>
        public string Note { get; set; }
    }
} 