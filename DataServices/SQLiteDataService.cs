using System;
using System.Collections.Generic;
using System.Text;

namespace DataServices
{
    public class SQLiteDataService : DataServiceBase
    {
        public SQLiteDataService() 
            : base(new SqliteDbContext())
        {
        }
    }
}
