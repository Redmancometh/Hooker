using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profiler
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///
        public static MainWindow window;
        [STAThread]
        static void Main()
        {
            ProcessHook hook = new ProcessHook();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window = new MainWindow(hook);
            Application.Run(window);
        }

        public void hopMethod()
        {
            Console.WriteLine("YO");
        }
    }
}
