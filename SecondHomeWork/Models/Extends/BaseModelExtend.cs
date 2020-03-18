
using Model;
using Model.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SecondHomeWork.Extends
{
    public static class BaseModelExtend
    {
        public static string GetAttributeDiscription(this PropertyInfo property)
        {
            return property.IsDefined(typeof(ModelDiscriptionAttribute), true) == true ? ((ModelDiscriptionAttribute)property.GetCustomAttribute(typeof(ModelDiscriptionAttribute), true)).GetDiscription() : property.Name;
        }

        public static string GetEntityToModelByProperty(this PropertyInfo property)
        {
            ModelsAndEntitiesAttribute modelDiscriptionAttribute = (ModelsAndEntitiesAttribute)property.GetCustomAttribute(typeof(ModelsAndEntitiesAttribute));
            return modelDiscriptionAttribute != null ? modelDiscriptionAttribute.EntityName : property.Name;
        }

    }
}
