using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BLL;
using DAL;
using Model;
using MyContainer;

namespace MyIOC
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container();
            container.RegisterType<IComputer, WindowsPC>(LifeTimeType.PerThread);
            container.RegisterType<IBLL, MyBLL>();
            container.RegisterType<IDAL, MyDAL>();
            IComputer computer1 = null;
            IComputer computer2 = null;
            IComputer computer3 = null;
            Task.Factory.StartNew(() =>
            {
                computer1 = container.Resolve<IComputer>();
                Console.WriteLine($"computer1由线程id={Thread.CurrentThread.ManagedThreadId}");
            });

            Task.Factory.StartNew(() => {
                computer2 = container.Resolve<IComputer>();
                Console.WriteLine($"pad2由线程id={Thread.CurrentThread.ManagedThreadId}");

                computer3 = container.Resolve<IComputer>();
                Console.WriteLine($"computer3由线程id={Thread.CurrentThread.ManagedThreadId}");

            });



            Thread.Sleep(3000);
            Console.WriteLine(Object.ReferenceEquals(computer1,computer2));
            Console.WriteLine(Object.ReferenceEquals(computer3, computer2));

            Console.ReadKey();
        }
    }
}
