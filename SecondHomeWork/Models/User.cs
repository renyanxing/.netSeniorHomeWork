using Model.Attributes;
using System;

namespace Model
{
    public class User : BaseModel
    {
        [ModelDiscription("用户名")]
        public string Name { get; set; }
        [ModelDiscription("账号")]
        public string Account { get; set; }
        [ModelDiscription("密码")]
        public string PassWord { get; set; }
        [ModelDiscription("邮箱")]
        public string Email { get; set; }
        [ModelDiscription("手机号码")]
        public string Mobile { get; set; }
        [ModelDiscription("公司Id")]
        public int CompanyId { get; set; }
        [ModelDiscription("公司名")]
        public string CompanyName { get; set; }
        [ModelDiscription("状态")]
        public int State { get; set; }
        [ModelDiscription("用户类型")]
        public int UserType { get; set; }
        [ModelDiscription("最后一次登录时间")]
        public DateTime LastLoginTime { get; set; }
        [ModelDiscription("创建时间")]
        public DateTime CreateTime { get; set; }
        [ModelDiscription("创建人Id")]
        public int CreatorId { get; set; }
        [ModelDiscription("最后更新人Id")]
        public int LastModifierId { get; set; }
        [ModelDiscription("最后更新时间")]
        public DateTime LastModifyTime { get; set; }

    }
}
