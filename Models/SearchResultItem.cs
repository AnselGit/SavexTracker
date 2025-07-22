using System;

namespace SavexTracker.Models
{
    /// <summary>
    /// Represents a search result item for savings or expenses.
    /// </summary>
    public class SearchResultItem
    {
        /// <summary>Date of the record.</summary>
        public string Date { get; set; }
        /// <summary>Type of the record ("Savings" or "Expense").</summary>
        public string Type { get; set; } // "Savings" or "Expense"
        /// <summary>Amount of the record.</summary>
        public double Amount { get; set; }
        /// <summary>Note associated with the record.</summary>
        public string Note { get; set; }
    }
} 