
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
        public static string GetAttributeDiscription<T>(this T property) where T : PropertyInfo
        {
            ModelDiscriptionAttribute modelDiscriptionAttribute = (ModelDiscriptionAttribute)property.GetCustomAttribute(typeof(ModelDiscriptionAttribute));
            return modelDiscriptionAttribute != null ? modelDiscriptionAttribute.Discripition : property.Name;
        }

        public static string GetEntityToModelByProperty<T>(this T property) where T : PropertyInfo
        {
            ModelsAndEntitiesAttribute modelDiscriptionAttribute = (ModelsAndEntitiesAttribute)property.GetCustomAttribute(typeof(ModelsAndEntitiesAttribute));
            return modelDiscriptionAttribute != null ? modelDiscriptionAttribute.EntityName : property.Name;
        }

    }
}
