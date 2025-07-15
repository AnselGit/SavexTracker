using System.Collections.Generic;
using SavexTracker.Database;
using SavexTracker.Models;

namespace SavexTracker
{
    public static class GlobalData
    {
        public static int CurrentID;
        public static string CurrentType;
        public static string CurrentTimestamp;
        public static double CurrentAmount;
        public static string CurrentNote;

        public static double CurrentGoal;

        public static string Archive_type;
        public static string Archive_note;

        public static int? Archive_sid;
        public static int? Archive_eid;

        public static string Archive_timestamp1;
        public static string Archive_timestamp2;

        public static double? Archive_amount1;
        public static double? Archive_amount2;
        
        public static int? Archive_rowid;        

        public static List<Saving> AllSavings;
        public static List<Expense> AllExpenses;
        public static List<ArchiveItem> AllArchive;
        public static List<HistoryItem> AllHistory;


    }
} 