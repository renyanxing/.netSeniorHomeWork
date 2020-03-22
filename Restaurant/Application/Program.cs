
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = Menu.GetMenuIntance();
            foreach (var item in menu.Foods)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine(item.Value.Make());
            }

            Console.ReadLine();
        }
    }
}
