using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MyBLL:IBLL
    {
        public MyBLL(IDAL iDAL)
        {
            Console.WriteLine("MyBLL is Construction ...");
        }
    }
}
