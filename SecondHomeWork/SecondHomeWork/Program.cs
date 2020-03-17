
using Model;
using System;

namespace SecondHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServerDbHelper sqlServerDbHelper = SqlServerDbHelper.GetInstance();
            var company = sqlServerDbHelper.GetDataById<Company>(1);
            Utils.ShowPropertiesAndDiscription<Company>(company);

            var staff = sqlServerDbHelper.GetDataById<StaffInfo>(1);
            Utils.ShowPropertiesAndDiscription<StaffInfo>(staff);
        }
    }
}
