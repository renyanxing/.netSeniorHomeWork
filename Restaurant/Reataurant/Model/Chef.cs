using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Restaurant.Model
{
    public class Chef
    {
        public string Name { get; private set; }
        public Dictionary<string, ChineseFoodBase> Menu { get; private set; }
        public Chef(Dictionary<string, ChineseFoodBase> menu,string name) {
            this.Name = name;
            this.Menu = menu;
        }
        public void LearnMenu(ChineseFoodBase chineseFood) => this.Menu.Add(chineseFood.Name, chineseFood);

    }
}

