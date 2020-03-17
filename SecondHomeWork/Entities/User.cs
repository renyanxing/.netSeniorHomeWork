using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entities
{
    public class User : BaseModel
    {
        [Description("用户名")]
        public string Name { get; set; }
        [Description("账号")]
        public string Account { get; set; }
        [Description("密码")]
        public string PassWord { get; set; }
        [Description("邮箱")]
        public string Email { get; set; }
        [Description("手机号码")]
        public string Mobile { get; set; }
        [Description("公司Id")]
        public int CompanyId { get; set; }
        [Description("公司名")]
        public string CompanyName { get; set; }
        [Description("状态")]
        public int State { get; set; }
        [Description("用户类型")]
        public int UserType { get; set; }
        [Description("最后一次登录时间")]
        public DateTime LastLoginTime { get; set; }
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }
        [Description("创建人Id")]
        public int CreatorId { get; set; }
        [Description("最后更新人Id")]
        public int LastModifierId { get; set; }
        [Description("最后更新时间")]
        public DateTime LastModifyTime { get; set; }

    }
}
