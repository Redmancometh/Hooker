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
        private Type callType { get; set; }
        public void start(Type callType)
        {
            while(true)
            {
                Thread.Sleep(1000);
                break;
            }
            new Thread((obj) =>
            {
                Thread.Sleep(100);
                ProfilerWindow window = new ProfilerWindow();
                window.ShowDialog();
            }).Start();
        }

        public void beginConstructorHook() // Inserts instructions at beginning of all constructors
        {

        }

        public void endConstructorHook() // Insert instructions at end of all constructors, "this" is in the context of the constructor's position
        {
            Agent.addToDictionary(this);
        }

        public void beginMethod() // Add instructions at beginning of all methods
        {

        }

        public void endMethod() //Add instructions at end of all methods
        {

        }

        public static void addToDictionary(Object o)  // Method called from end of constructor that attaches object
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
