using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianLongBaBu.Model
{
    public class XuZhu : ActorBase
    {
        public XuZhu():base("虚竹")
        {
            this.Actions = new List<string> {
                "小和尚","逍遥掌门","灵鹫宫宫主","西夏驸马"
            };
        }
    }
}
