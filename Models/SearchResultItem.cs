using System;

namespace SavexTracker.Models
{
    public class SearchResultItem
    {
        public string Date { get; set; }
        public string Type { get; set; } // "Savings" or "Expense"
        public double Amount { get; set; }
        public string Note { get; set; }
    }
} 