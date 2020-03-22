using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    public abstract class ChineseFoodBase
    {
        internal Dictionary<int, string> FoodLevel = new Dictionary<int, string> { { 0,"难吃"}, { 1, "一般" }, { 2, "还行" }, { 3, "好吃" }, { 4, "美味" } };
        public string Name { get; set; }

        public string Discription { get; set; }
        public abstract string Make();
    }
}
