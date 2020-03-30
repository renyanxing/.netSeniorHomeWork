
using Model;
using SecondHomeWork.Extends;
using System;
using System.Collections.Generic;
using System.Linq;
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

        
        public static List<T> GetRandomList<T>(List<T> tList, int number)
        {
            if (tList == null || !tList.Any())
            {
                return null;
            }
            if (tList.Count < number)
            {
                return tList;
            }
            List<T> newList = new List<T>();
            while (newList.Count < number)
            {
                var item = GetItem(tList);
                if (!newList.Contains(item))
                {
                    newList.Add(item);
                }
            }
            return newList;
        }
        private static T GetItem<T>(List<T> tList) {
            Random random = new Random();
            int index = random.Next(tList.Count);
            return tList[index];
        }
    }
}
