using System;
using Entities;

namespace FirstHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServerDbHelper sqlServerDbHelper = SqlServerDbHelper.GetInstance();
            var company = sqlServerDbHelper.GetDataById<Company>(Id: 1);
            var companys = sqlServerDbHelper.GetDataTable<Company>();
            var user = sqlServerDbHelper.GetDataById<User>(Id: 1);
            var users = sqlServerDbHelper.GetDataTable<User>();
            Utils.ShowProperties(company);
            foreach (var c in companys)
            {
                Utils.ShowProperties(c);
            }
            Utils.ShowProperties(user);
            foreach (var c in users)
            {
                Utils.ShowProperties(c);
            }
            Console.Read();
        }
    }
}
