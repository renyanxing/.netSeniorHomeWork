using Model.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    [ModelsAndEntitiesAttribute("Staff")]
    public class StaffInfo : BaseModel
    {
        [ModelDiscription("员工姓名")]
        [ModelsAndEntitiesAttribute("Name")]
        public string StaffName { get; set; }
        [DateToAge]
        [ModelDiscription("年龄")]
        [ModelsAndEntitiesAttribute("Birthday")]
        public int Age {
            get;set;
        }

    }
}
