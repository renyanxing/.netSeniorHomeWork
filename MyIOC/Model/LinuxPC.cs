using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class LinuxPC : IComputer
    {
        public LinuxPC()
        {
            Console.WriteLine("Linux PC is Construction ...");

        }
        public void StartPC()
        {
            Console.WriteLine("Hello World , I'm Linux!");
        }
    }
}
