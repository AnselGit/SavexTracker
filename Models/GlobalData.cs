using System.Collections.Generic;
using SavexTracker.Database;
using SavexTracker.Models;

namespace SavexTracker
{
    /// <summary>
    /// Holds global state and shared data for the application.
    /// </summary>
    public static class GlobalData
    {
        /// <summary>Currently selected record ID.</summary>
        public static int CurrentID;
        /// <summary>Currently selected record type ("Savings" or "Expenses").</summary>
        public static string CurrentType;
        /// <summary>Currently selected record timestamp.</summary>
        public static string CurrentTimestamp;
        /// <summary>Currently selected record amount.</summary>
        public static double CurrentAmount;
        /// <summary>Currently selected record note.</summary>
        public static string CurrentNote;

        /// <summary>Current goal amount.</summary>
        public static double CurrentGoal;

        /// <summary>Type of the currently selected archive item.</summary>
        public static string Archive_type;
        /// <summary>Note of the currently selected archive item.</summary>
        public static string Archive_note;

        public static int? Archive_sid;
        public static int? Archive_eid;

        public static string Archive_timestamp1;
        public static string Archive_timestamp2;

        public static double? Archive_amount1;
        public static double? Archive_amount2;
        
        public static int? Archive_rowid;        

        /// <summary>All savings records loaded in memory.</summary>
        public static List<Saving> AllSavings;
        /// <summary>All expenses records loaded in memory.</summary>
        public static List<Expense> AllExpenses;
        /// <summary>All archive records loaded in memory.</summary>
        public static List<ArchiveItem> AllArchive;
        /// <summary>All history records loaded in memory.</summary>
        public static List<HistoryItem> AllHistory;
    }
} 