using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TianLongBaBu.Model
{
    public class QiaoFeng : ActorBase
    {
        public QiaoFeng():base("乔峰")
        {
            this.Actions = new List<string> {
                "丐帮帮主","契丹人","南院大王","挂印离开"
            };
        }
    }
}
