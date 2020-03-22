using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class West : BaseModel, ICharge
    {
        public West(Person p, Table t, Chair c, Ruler r, Fan f) : base(p, t, c, r, f)
        {

        }

        public void Charge()
        {
            Console.WriteLine("各位衣食父母，赏点钱花吧！");
        }

        public override void ImitateDogBark()
        {
            Console.WriteLine("汪呜！汪呜！汪呜！");
        }

        public override void ImitatePersonSpeak()
        {
            Console.WriteLine("梦多，想去哪儿就去哪儿！");
        }

        public override void ImitateSoundOfWind()
        {
            Console.WriteLine("呼哧呼哧");
        }
    }
}
