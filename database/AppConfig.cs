
namespace SavexTracker
{
    public static class AppConfig
    {
        public static string DbPath => @"C:\Users\22-65\Desktop\Personal Projects\SavexTracker\database\CRUD.db";
        public static string ConnectionString => $"Data Source={DbPath};Version=3;";
    }
}