using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Agent
{
    public class JumpClass
    {
        public void jumpMethod() //Direct entry method
        {
            startAgent(Assembly.GetCallingAssembly().EntryPoint.DeclaringType);
        }

        public static void startAgent(Type callType) //Called here for integrity of main() ILcode
        {
            Agent a = new Agent();
            a.start(callType);
        }

    }
}
