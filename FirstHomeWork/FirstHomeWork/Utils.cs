using System;
using System.Collections.Generic;
using System.Text;

namespace FirstHomeWork
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
    }
}
