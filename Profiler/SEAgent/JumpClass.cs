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
        public void jumpMethod()
        {
            startAgent(Assembly.GetCallingAssembly().EntryPoint.DeclaringType);
        }

        public static void startAgent(Type type)
        {
            Agent a = new Agent();
            a.start(type);
        }
    }
}
