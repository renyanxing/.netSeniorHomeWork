using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ThirdHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            North n = CreatePlayer<North>("张三", 15);
            ActionStart(n);
            South s = CreatePlayer<South>("李四", 20);
            ActionStart(s);
            East e = CreatePlayer<East>("王五", 25);
            ActionStart(e);
            West w = CreatePlayer<West>("赵六", 30);
            ActionStart(w);
            Console.ReadLine();
        }
        public static void ActionStart<T>(T TSource) where T : BaseModel, ICharge
        {

            Type type = TSource.GetType().BaseType ?? null;
            if (type != null)
            {
                foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    Console.WriteLine($"PropertyName : {property.Name}  PropertyName : {property.GetValue(TSource)}");
                }
            }

            TSource.Start();
            TSource.Prologue();
            TSource.ImitateDogBark();
            TSource.ImitatePersonSpeak();
            TSource.ImitateSoundOfWind();
            TSource.Tag();
            TSource.Charge();

        }
        public static T CreatePlayer<T>(string name, int age) where T : BaseModel
        {
            Person p = new Person(name, age);
            Table t = new Table();
            Chair c = new Chair();
            Ruler r = new Ruler();
            Fan f = new Fan();
            Object o = Activator.CreateInstance(typeof(T), new object[] { p, t, c, r, f });

            return (T)o;
        }
    }
}
