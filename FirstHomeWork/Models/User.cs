using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class User : BaseModel
    {
        public string? Name { get; set; } = null;
        public string Account { get; set; }
        public string PassWord { get; set; }
        public string? Email { get; set; } = null;
        public string? Mobile { get; set; } = null;
        public int? CompanyId { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public int State { get; set; }
        public int UserType { get; set; };
        public DateTime? LastLoginTime { get; set; } = null;
        public DateTime CreateTime { get; set; }
        public int CreatorId { get; set; }
        public int? LastModifierId { get; set; } = null;
        public DateTime? LastModifyTime { get; set; } = null;

    }
}
