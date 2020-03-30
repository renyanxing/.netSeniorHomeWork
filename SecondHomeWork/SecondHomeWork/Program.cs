
using Model;
using System;
using System.Collections.Generic;

namespace SecondHomeWork
{
    class Program
    {
       

        static void Main(string[] args)
        {
            //SqlServerDbHelper sqlServerDbHelper = SqlServerDbHelper.GetInstance();
            //var company = sqlServerDbHelper.GetDataById<Company>(1);
            //Utils.ShowPropertiesAndDiscription<Company>(company);

            //var staff = sqlServerDbHelper.GetDataById<StaffInfo>(1);
            //Utils.ShowPropertiesAndDiscription<StaffInfo>(staff);


            List<string> list = new List<string> { "111", "22", "333", "4444", "555", "666", "77777", "88", "9999", "0000" };
            foreach (var item in Utils.GetRandomList<string>(list, 9))
            {
                Console.WriteLine(item);
            }
        }
        public List<T> GetList<T>(List<T> tList) { 

        
        }
        public event EventHandler GetRandomListEvent;
    }
}
