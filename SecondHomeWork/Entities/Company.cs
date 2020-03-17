using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entities
{
    public class Company : BaseModel
    {
        [Description("公司名称")]
        public string Name { get; set; }
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }
        [Description("创建人ID")]
        public int CreatorId { get; set; }
        [Description("最后一次更改人Id")]
        public int LastModifierId { get; set; }
        [Description("最后一次更改时间")]
        public DateTime LastModifyTime { get; set; }

    }
}
