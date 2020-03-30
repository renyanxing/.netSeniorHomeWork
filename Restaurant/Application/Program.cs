
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            //Menu menu = Menu.GetMenuIntance();
            //foreach (var item in menu.Foods)
            //{
            //    Console.WriteLine(item.Key);
            //    Console.WriteLine(item.Value.Make());
            //}
            List<AbstractChef> chefs = new List<AbstractChef>();
            chefs.AddRange(Program.InitChef().ToList());
            Menu menu = Menu.GetMenuIntance();
            foreach (var item in menu.Foods)
            {
                Console.WriteLine($"菜品名称：{item.Value}  菜品编码：{item.Key}");
            }
            Console.WriteLine("请输入菜品编码点餐！");
            string foodIdStr = Console.ReadLine();
            int foodId;
            while (!int.TryParse(foodIdStr,out foodId))
            {
                Console.WriteLine("只能输入数字");
                foodIdStr = Console.ReadLine();
            }
            Console.WriteLine($"您点了 {menu.Foods[foodId]}");
            ChineseFoodBase food = chefs[2].MakeNext(foodId);
            
            Console.WriteLine(food.Make());


            Console.ReadLine();
        }
        static private List<AbstractChef> InitChef()
        {
            List<AbstractChef> chefs = new List<AbstractChef>();
            string[] chefNames = ConfigurationManager.AppSettings["Chefs"].Split(',');
            for (int i = chefNames.Length - 1, j = 0; i > -1; i--,j++)
            {
                if (i == chefNames.Length - 1)
                {
                    chefs.Add(new AbstractChef(SetChefMenus().ToList(), chefNames[i], null));
                    continue;
                }
                chefs.Add(new AbstractChef(SetChefMenus().ToList(), chefNames[i], chefs[j-1]));
            }

            return chefs;
        }
        static private IEnumerable<int> SetChefMenus()
        {
            Random random = new Random();
            int foodNumber = random.Next(0, Menu.GetMenuIntance().Foods.Count - 2);
            for (int i = 0; i < foodNumber; i++)
            {
                yield return random.Next(0, Menu.GetMenuIntance().Foods.Count - 1);
            }
        }
    }
}
