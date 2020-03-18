using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SqlServerHelper
{
    public class SqlHelper
    {
        private static SqlHelper sqlHelper { get; set; }
        static SqlHelper()
        {
            sqlHelper = new SqlHelper();
        }
        public static SqlHelper GetIntance()
        {
            return sqlHelper;
        }

        /// <summary>
        /// 获取数据库所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlConnectionString">数据库连接字符串</param>
        /// <param name="sqlCommandText">数据库查询语句</param>
        /// <returns></returns>
        public IEnumerable<T> GetData<T>(string sqlConnectionString, string sqlCommandText)
        {
            return Excute(sqlConnectionString, sqlCommandText,null, sqlCommand =>
            {
                return Read<T>(sqlCommand.ExecuteReader());
            });
        }
        /// <summary>
        /// 按条件查找数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="sqlConnectionString">数据库连接字符串</param>
        /// <param name="sqlCommandText">数据库查询语句</param>
        /// <param name="parameter">查询参数（参数匿名对象new { Id }</param>
        /// <returns></returns>
        public T GetData<T, S>(string sqlConnectionString, string sqlCommandText, S parameter)
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            string paramString = string.Join("AND", GetParameterStringList(parameter, out parameterList));

            return Excute(sqlConnectionString, $"{sqlCommandText} where {paramString }",parameterList.ToArray(), sqlCommand =>
            {

                return Read<T>(sqlCommand.ExecuteReader()).FirstOrDefault();
            });
        }
        /// <summary>
        /// 按自定义条件查找数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="sqlConnectionString">数据库连接字符串</param>
        /// <param name="sqlCommandText">数据库查询语句</param>
        /// <param name="parameterString">查询参数字符串where a=@a and b=@b or c=@c </param>
        /// <returns></returns>
        public T GetData<T,S>(string sqlConnectionString, string sqlCommandText, string parameterString,S parameter)
        {
            
            return Excute(sqlConnectionString, $"{sqlCommandText} where {parameterString}", GetSqlParametersList(parameter).ToArray(), sqlCommand =>
            {
                return Read<T>(sqlCommand.ExecuteReader()).FirstOrDefault();
            });
        }
        /// <summary>
        /// 按分页规则获取表中数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlConnectionString">数据库连接字符串</param>
        /// <param name="sqlCommandText">数据库查询语句</param>
        /// <param name="pageNumber">当前查询页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="sortField">排序字段（默认值：Id）</param>
        /// <param name="ascending">升降序(默认升序)</param>
        /// <returns></returns>
        public IEnumerable<T> GetData<T>(string sqlConnectionString, string sqlCommandText, int pageNumber, int pageSize, string sortField = "Id", string ascending = "asc")
        {
            return Excute(sqlConnectionString, $"{sqlCommandText} order by {sortField} {ascending} offset {(pageNumber - 1) * pageSize} rows fetch next {pageSize} rows only",null, sqlCommand =>
            {
                return Read<T>(sqlCommand.ExecuteReader());
            });
        }
        /// <summary>
        /// 按条件分页获取表中数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="sqlConnectionString">数据库连接字符串</param>
        /// <param name="sqlCommandText">数据库查询语句</param>
        /// <param name="pageNumber">当前查询页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="sortField">排序字段（默认值：Id）</param>
        /// <param name="ascending">升降序(默认升序)</param>
        /// <param name="parameter">查询参数（参数匿名对象new { Id }</param>
        /// <returns></returns>

        public IEnumerable<T> GetData<T, S>(string sqlConnectionString, string sqlCommandText, S parameter, int pageNumber, int pageSize, string sortField = "Id", string ascending = "asc")
        {
            List<SqlParameter> parameterList = new List<SqlParameter>();
            string paramString = string.Join("AND", GetParameterStringList(parameter,out parameterList));
            return Excute(sqlConnectionString, $"{sqlCommandText} where { paramString } order by {sortField} {ascending} offset {(pageNumber - 1) * pageSize} rows fetch next {pageSize} rows only", parameterList.ToArray(), sqlCommand =>
            {
                return Read<T>(sqlCommand.ExecuteReader());
            });
        }
        /// <summary>
        /// 按自定义条件分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlConnectionString">数据库连接字符串</param>
        /// <param name="sqlCommandText">数据库查询语句</param>
        /// <param name="pageNumber">当前查询页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="sortField">排序字段（默认值：Id）</param>
        /// <param name="ascending">升降序(默认升序)</param> 
        /// <param name="parameterString">查询参数字符串where xxx and xxx or xxx ???</param>
        /// <returns></returns>
        public IEnumerable<T> GetData<T,S>(string sqlConnectionString, string sqlCommandText, string parameterString, int pageNumber, int pageSize, S parameter, string sortField = "Id", string ascending = "asc")
        {
            return Excute(sqlConnectionString, $"{sqlCommandText} where { parameterString } order by {sortField} {ascending} offset {(pageNumber - 1) * pageSize} rows fetch next {pageSize} rows only", GetSqlParametersList(parameter).ToArray(), sqlCommand =>
            {
                return Read<T>(sqlCommand.ExecuteReader());
            });
        }

        public bool AddData<T>(T source)
        {


            return true;
        }
        public bool AddData<T>(List<T> sourceList)
        {


            return true;
        }



        private T Excute<T>(string sqlConnectionString, string sqlCommandText, SqlParameter[] parameters, Func<SqlCommand, T> func)
        {

            using (SqlConnection sqlConnection = new SqlConnection(sqlConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlCommandText, sqlConnection);
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                
                return func.Invoke(sqlCommand);
            }
        }
        private IEnumerable<T> Read<T>(SqlDataReader sqlDataReader)
        {

            while (sqlDataReader.Read())
            {
                var data = Activator.CreateInstance(typeof(T));
                foreach (var item in typeof(T).GetProperties())
                {
                    item.SetValue(data, sqlDataReader[item.Name]);
                }
                yield return (T)data;
            }

        }
        private List<string> GetParameterStringList<T>(T source, out List<SqlParameter> parameters)
        {
            List<string> returnSource = new List<string>();
            parameters = new List<SqlParameter>();
            foreach (var item in typeof(T).GetProperties())
            {
                parameters.Add(new SqlParameter($@"{item.Name}", item.GetValue(source)));
                returnSource.Add($"{item.Name}=@{item.Name}");
            }
            return returnSource;
        }
        private List<SqlParameter> GetSqlParametersList<T>(T source){

            List<SqlParameter>  parameters = new List<SqlParameter>();
            foreach (var item in typeof(T).GetProperties())
            {
                parameters.Add(new SqlParameter($@"{item.Name}", item.GetValue(source)));
            }
            return parameters;
        }

    }
}
