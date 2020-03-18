using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using SecondHomeWork.Extends;
using Model.Attributes;

namespace Model
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

        public List<TSource> GetDataArray<TSource>()
            where TSource : BaseModel
        {
            //string _sqlConnectString = ConfigurationManager.ConnectionStrings["First"].ToString();
            var type = typeof(TSource);
            string sqlCommandText = $"SELECT {string.Join(',', type.GetProperties().Select(p => { return $"[{p.Name}]"; }))} FROM [{type.Name}]";

            return ExcuteSql(sqlCommandText, sqlCommand => {
                var sqlDataReader = sqlCommand.ExecuteReader();
                List<TSource> result = new List<TSource>();
                while (sqlDataReader.Read())
                {
                    result.Add(Trans<TSource>(type, sqlDataReader));
                   
                }
                return result;
            });
            
        }
        private TSource Trans<TSource>(Type type, SqlDataReader sqlDataReader)
        {
            object oObject = Activator.CreateInstance(type);

            foreach (var prop in type.GetProperties())
            {
                DateToAgeAttribute dateToAgeAttribute = (DateToAgeAttribute)prop.GetCustomAttribute(typeof(DateToAgeAttribute));
                if (dateToAgeAttribute != null)
                {
                    DateTime birth = Convert.ToDateTime(sqlDataReader[prop.Name]);
                    prop.SetValue(oObject, DateTime.Now.Year - birth.Year + 1);

                }
                else
                {
                    prop.SetValue(oObject, sqlDataReader[prop.Name] is DBNull ? null : sqlDataReader[prop.Name]);

                }
            }
            return (TSource)oObject;
        }
        public TSource GetDataById<TSource>(int Id)
        where TSource : BaseModel
        {
            //string _sqlConnectString = ConfigurationManager.ConnectionStrings["First"].ConnectionString.ToString();
            var type = typeof(TSource);

            ModelsAndEntitiesAttribute modelsAndEntitiesAttribute = (ModelsAndEntitiesAttribute)type.GetCustomAttribute(typeof(ModelsAndEntitiesAttribute));
            string sqlCommandText =
                $"SELECT {string.Join(',', type.GetProperties().Select(p => { return $"[{p.GetEntityToModelByProperty()}] as {p.Name}"; }))} FROM [{(modelsAndEntitiesAttribute == null ? type.Name : modelsAndEntitiesAttribute.EntityName)}] WHERE Id = {Id}";

            //using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectString))
            //{

            //    SqlCommand sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
            //    sqlConnection.Open();
            //    var sqlDataReader = sqlCommand.ExecuteReader();

            //    if (sqlDataReader.Read())
            //    {
            //        return Trans<TSource>(type, sqlDataReader);
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}

            return ExcuteSql(sqlCommandText, command =>
            {
                var sqlDataReader = command.ExecuteReader();

                if (sqlDataReader.Read())
                {
                    return Trans<TSource>(type, sqlDataReader);
                }
                else
                {
                    return null;
                }
            });

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
                sqlCommand.Parameters.AddRange(type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Select(prop => new SqlParameter($"@{prop.Name}", prop.GetValue(source) ?? DBNull.Value)).ToArray());
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
                sqlCommand.CommandText = @$"UPDATE [{type.Name}] SET {string.Join(',', type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Select(p =>
                {
                    sqlCommand.Parameters.Add(new SqlParameter($"@{p.Name}", p.GetValue(source)));
                    return $"[{p.Name}]=@{p.Name}";
                }))} WHERE Id=@Id";
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

        private T ExcuteSql<T>(string sql , Func<SqlCommand,T> func)
        {
            using (SqlConnection sqlConnection =new SqlConnection(_sqlConnectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                return func.Invoke(sqlCommand);
            }

        }
    }
}
