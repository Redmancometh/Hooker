using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agent;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window = new MainWindow();
            Application.Run(window);
        }
    }
}
