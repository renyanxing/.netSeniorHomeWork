using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    public class Menu
    {
        private static volatile Menu menu = null;
        private Menu() { }
        static Menu()
        {
            menu = new Menu();
            //Assembly assembly = Assembly.Load("Restaurant");
            //foreach (var item in ConfigurationManager.AppSettings["Menu"].Split(','))
            //{
            //    Type type = assembly.GetType($"Restaurant.Model.Menus.{item}");
            //    menu.Foods.Add(item, (ChineseFoodBase)Activator.CreateInstance(type));
            //}
            menu.InitMenu(ConfigurationManager.AppSettings["Menu"].Split(','));

        }
        public static Menu GetMenuIntance()
        {
            return menu;
        }
        private void InitMenu(string[] menu)
        {
            for (int i = 0; i < menu.Count(); i++)
            {
                this.Foods.Add(i, menu[i]);
            }
        }
        public Dictionary<int, string> Foods { get; private set; } = new Dictionary<int, string>();

    }

}
