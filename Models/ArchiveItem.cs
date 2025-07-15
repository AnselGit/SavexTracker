namespace SavexTracker.Models
{
    public class ArchiveItem
    {
        public int Aid { get; set; }
        public int? Sid { get; set; }
        public int? Eid { get; set; }
        public string Name { get; set; }
        public string Timestamp1 { get; set; }
        public double? Amount1 { get; set; }
        public string Timestamp2 { get; set; }
        public double? Amount2 { get; set; }
        public string Note { get; set; }
    }
} 