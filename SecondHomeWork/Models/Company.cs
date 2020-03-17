using Model.Attributes;
using System;

namespace Model
{
    public class Company : BaseModel
    {
        [ModelDiscription("公司名称")]
        public string Name { get; set; }
        [ModelDiscription("创建时间")]
        public DateTime CreateTime { get; set; }
        [ModelDiscription("创建人ID")]
        public int CreatorId { get; set; }
        [ModelDiscription("最后一次更改人Id")]
        public int LastModifierId { get; set; }
        [ModelDiscription("最后一次更改时间")]
        public DateTime LastModifyTime { get; set; }

    }
}
