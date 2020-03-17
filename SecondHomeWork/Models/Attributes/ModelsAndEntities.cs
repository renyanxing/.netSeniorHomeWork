using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class ModelsAndEntitiesAttribute : Attribute
    {
        public string EntityName { get; private set; }
        public ModelsAndEntitiesAttribute(string entityName)
        {
            this.EntityName = entityName;
        }

    }
}
