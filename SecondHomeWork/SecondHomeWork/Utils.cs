
using Model;
using SecondHomeWork.Extends;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SecondHomeWork
{
    public static class Utils
    {
        public static void ShowProperties<T>(T tSource)
        {
            Type type = typeof(T);
            foreach (var propertyInfo in type.GetProperties())
            {
                Console.WriteLine($"PropertyName:{propertyInfo.Name}  PropertyValue:{propertyInfo.GetValue(tSource)}");
            }
        }

        public static void ShowPropertiesAndDiscription<T>(T tSource) where T : BaseModel
        {
            Type type = typeof(T);
            foreach (var propertyInfo in type.GetProperties())
            {
                Console.WriteLine($"{propertyInfo.GetAttributeDiscription()} : {propertyInfo.GetValue(tSource)}");
            }
        }

    }
}
