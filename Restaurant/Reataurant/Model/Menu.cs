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
        static Menu() {
            menu = new Menu();
            Assembly assembly = Assembly.Load("Restaurant");
            foreach (var item in ConfigurationManager.AppSettings["Menu"].Split(','))
            {
                Type type = assembly.GetType($"Restaurant.Model.Menus.{item}");
                menu.Foods.Add(item, (ChineseFoodBase)Activator.CreateInstance(type));
            }

        }
        public static Menu GetMenuIntance()
        {
            return menu;
        }
        public Dictionary<string, ChineseFoodBase> Foods { get; private set; } = new Dictionary<string, ChineseFoodBase>();
    }

}
