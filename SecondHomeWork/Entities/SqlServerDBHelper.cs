using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SqlServerDBHelper
    {
        private static SqlServerDBHelper sqlServerDBHelper { get; set; } = new SqlServerDBHelper();

        private static SqlConnection sqlConnection = new SqlConnection();
        private SqlServerDBHelper()
        {
            
        }
        public static SqlServerDBHelper GetInstance()
        {
            return sqlServerDBHelper ?? new SqlServerDBHelper();
        }
        
    }
}
