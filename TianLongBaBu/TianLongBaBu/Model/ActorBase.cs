using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TianLongBaBu.Model
{
    public abstract class ActorBase
    {
        public string Name { get; set; }
        public List<string> Actions { get; set; }
        public int ActionIndex = 0;
        public bool Doing(out string action) {
            Thread.Sleep(RandomSleep(1000,2000));
            action = Actions[ActionIndex++];
            return ActionIndex == Actions.Count;
        }
        public ActorBase(string name)
        {
            this.Name = name;
        }
        private int RandomSleep(int min, int max)
        {
            string sGuid = Guid.NewGuid().ToString();
            int seed = DateTime.Now.Millisecond;
            for (int i = 0; i < sGuid.Length; i++)
            {
                switch (sGuid[i])
                {
                    case 'a':
                    case 'b':
                    case 'c':
                    case 'd':
                    case 'e':
                    case 'f':
                    case 'g':
                        seed = seed + 1;
                        break;
                    case 'h':
                    case 'i':
                    case 'j':
                    case 'k':
                    case 'l':
                    case 'm':
                    case 'n':
                        seed = seed + 2;
                        break;
                    case 'o':
                    case 'p':
                    case 'q':
                    case 'r':
                    case 's':
                    case 't':
                        seed = seed + 3;
                        break;
                    case 'u':
                    case 'v':
                    case 'w':
                    case 'x':
                    case 'y':
                    case 'z':
                        seed = seed + 3;
                        break;
                    default:
                        seed = seed + 4;
                        break;
                }
                
            }
            return new Random(seed).Next(1000, 2000);
        }
    }
}
