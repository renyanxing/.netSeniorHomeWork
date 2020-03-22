using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class BaseModel
    {
        private Person PerFormer { get; set; }
        private Table ActionTable { get; set; }
        private Chair ActionChair { get; set; }
        private Ruler ActionRuler { get; set; }
        private Fan ActionFan { get; set; }
        public BaseModel(Person p, Table t, Chair c, Ruler r, Fan f)
        {
            this.PerFormer = p;
            this.ActionTable = t;
            this.ActionChair = c;
            this.ActionRuler = r;
            this.ActionFan = f;
        }
        public void Start() {
            Console.WriteLine("表演开始了！");
        }
        public abstract void ImitateDogBark();
        public abstract void ImitatePersonSpeak();
        public abstract void ImitateSoundOfWind();
        public virtual void Prologue() {
            Console.WriteLine($"大家好，我是{PerFormer.Name},今天由我给大家带来口技表演！");    
        }
        public virtual void Tag() {
            Console.WriteLine($"谢谢大家观看，我是{PerFormer.Name}。");
        }
    }
}
