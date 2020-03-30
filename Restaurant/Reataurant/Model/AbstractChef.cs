using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Restaurant.Model
{
    public class AbstractChef
    {
        public string Name { get; private set; }
        private AbstractChef nextChef = null;
        public List<int> ChefMenu { get; private set; }
        public AbstractChef(List<int> menu, string name,AbstractChef nextChef)
        {
            this.Name = name;
            this.ChefMenu = menu;
            this.nextChef = nextChef;
        }
        private ChineseFoodBase Make(int foodId)
        {
            Assembly assembly = Assembly.Load("Restaurant");
            Type type = assembly.GetType($"Restaurant.Model.Menus.{Menu.GetMenuIntance().Foods[foodId]}");
            ChineseFoodBase food= (ChineseFoodBase)Activator.CreateInstance(type, true);
            food.Name = type.Name;
            return food;
        }
        public ChineseFoodBase MakeNext(int foodId)
        {
            if (this.nextChef == null)
            {
                return Make(foodId);
            }
            else if (this.ChefMenu.Contains(foodId))
            {
                return Make(foodId);
            }
            else
            {
                Console.WriteLine($"我不会做,{nextChef.Name}你来做！");
                return nextChef.MakeNext(foodId);
            }
        }
    }
}

