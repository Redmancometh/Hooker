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
            Console.WriteLine("loading assembly...");
            Assembly.LoadFrom(@"C:\\Users\\Redman\\Documents\\Visual Studio 2015\\Projects\\Profiler\\Profiler\\bin\\Debug\\Agent.dll");
            Assembly.LoadFrom(@"C:\\Users\\Redman\\Documents\\Visual Studio 2015\\Projects\\Profiler\\Profiler\\bin\\Debug\\Mono.Cecil.dll");
            Agent o = new Agent();
            o.start();
           /* Console.WriteLine(Assembly.GetExecutingAssembly().EntryPoint.Module.GetTypes()[0]);*/
        }
    }

}
