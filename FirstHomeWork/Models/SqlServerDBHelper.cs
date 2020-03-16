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
        private string _sqlConnectString = ConfigurationManager.ConnectionStrings["First"].ConnectionString.ToString();


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

        public IEnumerable<TSource> GetDataArray<TSource>()
            where TSource : BaseModel
        {
            //string _sqlConnectString = ConfigurationManager.ConnectionStrings["First"].ToString();
            var type = typeof(TSource);
            string sqlCommandText = $"SELECT {string.Join(',', type.GetProperties().Select(p => { return $"[{p.Name}]"; }))} FROM [{type.Name}]";
            List<TSource> result = new List<TSource>();
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    yield return Trans<TSource>(type, sqlDataReader);
                }
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
                //DataTable dataTable = new DataTable();
                //sqlDataAdapter.Fill(dataTable);
                //foreach (DataRow item in dataTable.Rows)
                //{
                //    object oObject = Activator.CreateInstance(type);
                //    foreach (var property in type.GetProperties())
                //    {
                //        property.SetValue(oObject, item[property.Name] is DBNull ? null : item[property.Name]);
                //    }
                //    //result.Add((TSource)oObject);
                //    yield return (TSource)oObject;
                //}
            }

            //return result;
        }
        private TSource Trans<TSource>(Type type, SqlDataReader sqlDataReader)
        {
            object oObject = Activator.CreateInstance(type);
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(oObject, sqlDataReader[prop.Name] is DBNull ? null : sqlDataReader[prop.Name]);
            }
            return (TSource)oObject;
        }
        public TSource GetDataById<TSource>(int Id)
        where TSource : BaseModel
        {
            //string _sqlConnectString = ConfigurationManager.ConnectionStrings["First"].ConnectionString.ToString();
            var type = typeof(TSource);
            string sqlCommandText =
                $"SELECT {string.Join(',', type.GetProperties().Select(p => { return $"[{p.Name}]"; }))} FROM [{type.Name}] WHERE Id = {Id}";

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectString))
            {

                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
                sqlConnection.Open();
                var sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    return Trans<TSource>(type, sqlDataReader);
                }
                else
                {
                    return null;
                }
            }
        }

        public int AddData<TSource>(TSource source)
            where TSource : BaseModel
        {
            Type type = typeof(TSource);

            string sqlCommandText = $@"INSERT INTO [{type.Name}] 
            ({string.Join(',', type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Select(p => $"[{p.Name}]"))}) VALUES 
            ({string.Join(',', type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Select(p => $"@{p.Name}"))})";
            int Count = 0;
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
                sqlCommand.Parameters.AddRange(type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Select(prop => new SqlParameter($"@{prop.Name}", prop.GetValue(source)  ?? DBNull.Value )).ToArray());
                Count = sqlCommand.ExecuteNonQuery();
                //返回ID  
                //sqlCommandText+=" SELECT @@Identity"
                //sqlCommand.ExecuteScalar();
            }

            return Count;
        }
        public int ChangeData<TSource>(TSource source)
            where TSource : BaseModel
        {
            Type type = typeof(TSource);
            int count = 0;
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = @$"UPDATE [{type.Name}] SET {string.Join(',', type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Where(p =>
                {
                    sqlCommand.Parameters.Add(new SqlParameter($"@{p.Name}", p.GetValue(source))); 
                })
                .Select(p => $"[{p.Name}]=@{p.Name}"))} WHERE Id=@Id";
                count = sqlCommand.ExecuteNonQuery();
            }
            return count;
        }
        public int DeleteData<TSource>(TSource source)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectString))
            {
                Type type = typeof(TSource);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"DELETE FROM {type.Name} WHERE Id=@Id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("Id", type.GetProperty("Id").GetValue(source));
                return sqlCommand.ExecuteNonQuery();
            }

        }
    }
}
