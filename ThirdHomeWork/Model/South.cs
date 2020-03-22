using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class South : BaseModel, ICharge
    {
        public South(Person p, Table t, Chair c, Ruler r, Fan f) : base(p, t, c, r, f)
        {

        }

        public void Charge()
        {
            Console.WriteLine("大家伙有钱给钱，没钱给个掌声！");
        }

        public override void ImitateDogBark()
        {
            Console.WriteLine("嗷呜~~~");
        }

        public override void ImitatePersonSpeak()
        {
            Console.WriteLine("大哥，您介是要起飞啊！");
        }

        public override void ImitateSoundOfWind()
        {
            Console.WriteLine("咻咻咻~~~");
        }
    }
}
