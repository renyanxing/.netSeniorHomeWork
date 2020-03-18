using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ModelDiscriptionAttribute : Attribute
    {
        private string Discripition { get; set; }
        public ModelDiscriptionAttribute(string discription)
        {
            this.Discripition = discription;
        }
        public string GetDiscription() {
            return this.Discripition;
        }
    }
}
