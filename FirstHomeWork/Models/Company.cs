using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Company : BaseModel
    {
        public string? Name { get; set; } = null;
        public DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public int? LastModifierId { get; set; } = null;
        public DateTime? LastModifyTime { get; set; } = null;

    }
}
