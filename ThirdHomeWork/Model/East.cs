using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class East : BaseModel,ICharge
    {
        public East(Person p, Table t, Chair c, Ruler r, Fan f) : base(p, t, c, r, f)
        {

        }

        public void Charge()
        {
            Console.WriteLine("有钱的捧个钱场没钱的捧个人场！");
        }

        public override void ImitateDogBark()
        {
            Console.WriteLine("汪汪汪！");
        }

        public override void ImitatePersonSpeak()
        {
            Console.WriteLine("刘大姐您吃了么！");
        }

        public override void ImitateSoundOfWind()
        {
            Console.WriteLine("呼呼呼~~~！");
        }
    }
}
