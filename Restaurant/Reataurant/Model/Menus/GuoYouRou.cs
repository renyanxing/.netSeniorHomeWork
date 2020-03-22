using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Restaurant.Model.Menus
{
    public class GuoYouRou : ChineseFoodBase
    {
        public override string Make()
        {
            Console.WriteLine($"开始制作{this.Name}.....");
            Thread.Sleep(1000);
            Random random = new Random();
            int level = random.Next(0, 4);
            return FoodLevel[level];
        }
    }
}
