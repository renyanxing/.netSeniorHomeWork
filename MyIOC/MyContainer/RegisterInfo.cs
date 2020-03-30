using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContainer
{
    public class RegisterInfo
    {
        public Type TargetType { get; set; }

        public LifeTimeType LifeTime { get; set; }
        public RegisterInfo(Type targetType, LifeTimeType lifeTime)
        {
            this.TargetType = targetType;
            this.LifeTime = lifeTime;
        }
    }
}
