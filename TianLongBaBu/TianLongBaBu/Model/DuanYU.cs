using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianLongBaBu.Model
{
    public class DuanYu : ActorBase
    {
        public DuanYu():base("段誉")
        {
            this.Actions = new List<string> {
                "钟灵儿","木婉清","王语嫣","大理国王"
            };
        }
    }
}
