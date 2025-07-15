namespace SavexTracker.Models
{
    public class HistoryItem
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public double? Amount { get; set; }
        public string Timestamp { get; set; }
    }
} 