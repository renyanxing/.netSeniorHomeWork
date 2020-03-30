using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MacOSPC : IComputer
    {
        public MacOSPC()
        {
            Console.WriteLine("MacOS PC is Construction ...");
        }
        public void StartPC()
        {
            Console.WriteLine("Hello World , I'm MacOS !");

        }
    }
}
