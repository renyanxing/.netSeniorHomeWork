using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ModelDiscriptionAttribute : Attribute
    {
        public string Discripition { get; private set; }
        public ModelDiscriptionAttribute(string discription)
        {
            this.Discripition = discription;
        }
    }
}
