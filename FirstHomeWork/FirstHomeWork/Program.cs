using System;
using Entities;

namespace FirstHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServerDbHelper sqlServerDbHelper = SqlServerDbHelper.GetInstance();
            #region SELECT All & By Id
            //var company = sqlServerDbHelper.GetDataById<Company>(Id: 1);
            //var companys = sqlServerDbHelper.GetDataArray<Company>();
            //var user = sqlServerDbHelper.GetDataById<User>(Id: 1);
            //var users = sqlServerDbHelper.GetDataArray<User>();
            //Utils.ShowProperties(company);
            //foreach (var c in companys)
            //{
            //    Utils.ShowProperties(c);
            //}
            //Utils.ShowProperties(user);
            //foreach (var c in users)
            //{
            //    Utils.ShowProperties(c);
            //}

            #endregion
            #region INSERT
            //int companyCount = sqlServerDbHelper.AddData<Company>(new Company
            //{
            //    Name = "Microsoft",
            //    CreateTime = DateTime.Now,
            //    CreatorId = 1,
            //    LastModifierId = 1,
            //    LastModifyTime = DateTime.Now
            //});
            //int userCount = sqlServerDbHelper.AddData<User>(new User
            //{
            //    Name = "小林",
            //    Account = "admin",
            //    PassWord = "e10adc3949ba59abbe56e057f20f883e",
            //    Email = "12",
            //    Mobile = "133",
            //    CompanyId = 4,
            //    CompanyName = "Microsoft",
            //    State = 0,
            //    UserType = 2,
            //    LastLoginTime = DateTime.Now,
            //    CreateTime = DateTime.Now,
            //    CreatorId = 1,
            //    LastModifierId = 1,
            //    LastModifyTime = DateTime.Now,

            //});
            //Console.WriteLine($"ConpanyCount:{companyCount}   UserCount:{userCount}");
            #endregion
            #region UPDATE
            //int companyCount = sqlServerDbHelper.ChangeData(new Company
            //{
            //    Id = 4,
            //    CreatorId = 2,
            //    LastModifierId = 2,
            //    LastModifyTime = DateTime.Now
            //});
            //int userCount = sqlServerDbHelper.ChangeData(new User
            //{
            //    Id = 7,
            //    Account = "manager"
            //});
            //Console.WriteLine($"CompanyCount:{companyCount}   UserCount:{userCount}");
            #endregion
            #region DELETE
            int count = sqlServerDbHelper.DeleteData(new Company { 
                Id=5
            });
            Console.WriteLine(count);
            #endregion
            Console.Read();
        }
    }
}
