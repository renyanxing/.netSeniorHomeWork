using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Entities
{
    public sealed class SqlServerDbHelper
    {
        private static readonly SqlServerDbHelper Helper = null;


        private SqlServerDbHelper()
        {

        }


        static SqlServerDbHelper()
        {
            Helper = new SqlServerDbHelper();
        }
        public static SqlServerDbHelper GetInstance()
        {
            return Helper;
        }

        public List<T> GetDataTable<T>()
            where T : BaseModel
        {
            string _sqlConnectString = ConfigurationManager.ConnectionStrings["First"].ToString();
            var type = typeof(T);
            string sql = $"SELECT {string.Join(',', type.GetProperties().Select(p => { return $"[{p.Name}]"; }))} FROM [{type.Name}]";
            List<T> result = new List<T>();
            using (SqlConnection conn = new SqlConnection(_sqlConnectString))
            {
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow item in dataTable.Rows)
                {
                    object oObject = Activator.CreateInstance(type);
                    foreach (var property in type.GetProperties())
                    {
                        property.SetValue(oObject, item[property.Name]);
                    }
                    result.Add((T)oObject);
                }
            }

            return result;
        }

        public T GetDataById<T>(int Id)
        where T : BaseModel
        {
            string _sqlConnectString = ConfigurationManager.ConnectionStrings["First"].ConnectionString.ToString();
            var type = typeof(T);
            string sql =
                $"SELECT {string.Join(',', type.GetProperties().Select(p => { return $"[{p.Name}]"; }))} FROM [{type.Name}] WHERE Id = {Id}";
            object oObject = Activator.CreateInstance(type);
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectString))
            {
                
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    foreach (var prop in type.GetProperties())
                    {
                        prop.SetValue(oObject, sqlDataReader[prop.Name]);

                    }
                }
            }



            return (T)oObject;
        }
    }

    //public sealed class SqlServerDbHelper
    //{
    //    private static SqlServerDbHelper helper = null;
    //    private static string _sqlConnectString = ConfigurationManager.ConnectionStrings["First"].ToString();
    //    private SqlServerDbHelper()
    //    {

    //    }

    //    static SqlServerDbHelper()
    //    {
    //        helper = new SqlServerDbHelper();
    //    }

    //    public static SqlServerDbHelper GetInstance()
    //    {
    //        return helper;
    //    }
    //    public List<T> GetDataTable<T>()
    //        where T : BaseModel
    //    {
    //        var type = typeof(T);
    //        string sql = $"SELECT {string.Join(',', type.GetProperties().Select(p => { return $"[{p.Name}]"; }))} FROM [{type.Name}]";
    //        List<T> result = new List<T>();
    //        using (SqlConnection conn = new SqlConnection(_sqlConnectString))
    //        {
    //            conn.Open();
    //            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
    //            DataTable dataTable = new DataTable();
    //            sqlDataAdapter.Fill(dataTable);
    //            foreach (DataRow item in dataTable.Rows)
    //            {
    //                object oObject = Activator.CreateInstance(type);
    //                foreach (var property in type.GetProperties())
    //                {
    //                    property.SetValue(oObject, item[property.Name]);
    //                }
    //                result.Add((T)oObject);
    //            }
    //        }

    //        return result;
    //    }
    //}
}
