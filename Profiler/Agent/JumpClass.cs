using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent
{
    public class JumpClass
    {
        public void jumpMethod()
        {
            startAgent();
        }

        public static void startAgent()
        {
            Agent a = new Agent();
            a.start();
        }
    }
}
