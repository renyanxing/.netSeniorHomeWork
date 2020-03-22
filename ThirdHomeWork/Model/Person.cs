using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Person
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Person(string name,int age)
        {
            this.Name = name;
            this.Age = age;
            Console.WriteLine($"{this.Name}{this.Age}岁");
        }
    }
}
