using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WindowsPC : IComputer
    {
        public WindowsPC()
        {
            Console.WriteLine("Windows PC is Construction ...");
        }
        public void StartPC()
        {
            Console.WriteLine("Hello World , I'm Windos 10 !");

        }
    }
}
