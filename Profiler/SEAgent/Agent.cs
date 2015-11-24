using Sandbox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VRage.FileSystem;
using VRage.Utils;

namespace Agent
{
    public class Agent
    {
        public enum InputResponse { START, EXIT, NOTHING };
        public static Dictionary<Type, List<object>> classDictionary = new Dictionary<Type, List<object>>();
        public void start(Type caller)
        {
            seHook(caller);
        }

        public void seHook(Type caller)
        {
            Console.WriteLine("Type init to initialize space engineers...");
            bool breakCondition = false;
            while(!breakCondition)
            {
                switch(readInput())
                {
                    case InputResponse.START:
                        breakCondition = true;
                        break;
                    case InputResponse.NOTHING:
                        break;
                    case InputResponse.EXIT:
                        return;
                }
            }
            MySingleProgramInstance mySingleProgramInstance = new MySingleProgramInstance(MyFileSystem.MainAssemblyName);
            MyInitializer.InvokeBeforeRun(244850u, "SpaceEngineers", Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SpaceEngineers"), false);
            MethodInfo initSplashScreen = caller.GetMethod("RunInternal", BindingFlags.NonPublic |BindingFlags.Static);
            if(initSplashScreen!=null)
            {
                try
                {
                    String[] innerArgs = null;
                    initSplashScreen.Invoke(null, new object[] { innerArgs });
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            while (true)
            {
                Console.WriteLine("Done with stuff");
                Thread.Sleep(30000);
                break;
            }
        }

        public InputResponse readInput()
        {
            String input; 
            if((input = Console.ReadLine())!=null)
            {
                switch(input.ToLower())
                {
                    case "exit":
                        return InputResponse.EXIT;
                    case "init":
                        return InputResponse.START;
                }
            }
            return InputResponse.NOTHING;
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
