using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class North : BaseModel, ICharge
    {
        public North(Person p, Table t, Chair c, Ruler r, Fan f) : base(p, t, c, r, f)
        {

        }

        public void Charge()
        {
            Console.WriteLine("多少您给点呗！");
        }

        public override void ImitateDogBark()
        {
            Console.WriteLine("呜汪！呜汪！呜汪！");
        }

        public override void ImitatePersonSpeak()
        {
            Console.WriteLine("无形之刃，最为致命！");
        }

        public override void ImitateSoundOfWind()
        {
            Console.WriteLine("嘶嘶嘶嘶嘶嘶嘶嘶！");
        }
    }
}
