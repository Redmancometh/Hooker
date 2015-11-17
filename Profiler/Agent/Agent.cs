using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agent
{
    public class Agent
    {
        public static Dictionary<Type, List<object>> classDictionary = new Dictionary<Type, List<object>>();
        public void start()
        {
            new Thread((obj) =>
            {
                Thread.Sleep(1000);
                ProfilerWindow window = new ProfilerWindow();
                window.ShowDialog();
            }).Start();
        }

        public void beginConstructorHook()
        {

        }

        public void endConstructorHook()
        {
            Agent.addToDictionary(this);
        }

        public static void addToDictionary(Object o)
        {
            Console.WriteLine(o.GetType());
            if (!classDictionary.ContainsKey(o.GetType()))
            {
                List<object> objectList = new List<object>();
                objectList.Add(o);
                classDictionary.Add(o.GetType(), objectList);
            }
            else
            {
                classDictionary[o.GetType()].Add(o);
            }
        }
    }
}
