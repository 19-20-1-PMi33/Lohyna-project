namespace DataServices
{
    /// <summary>
    /// Service for obtaining data from SQLite DB.
    /// </summary>
    public class SQLiteDataService : DataServiceBase
    {
        public SQLiteDataService() 
            : base(new SqliteDbContext())
        {
        }
    }
}
