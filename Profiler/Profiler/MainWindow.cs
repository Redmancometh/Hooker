using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using Mono.Cecil;

namespace Profiler
{
    public partial class MainWindow : Form
    {
        Dictionary<String, Process> processMap = new Dictionary<String, Process>();
        private String targetFileName { get; set; }
        public String injectFileName { get; set; } 
        private ProcessHook procHook;
        private IDEWindow ideView;
        public MainWindow(ProcessHook procHook)
        {
            this.procHook = procHook;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chooseTargetFile(object sender, EventArgs e)
        {
            getTargetFile();
        }

        public Process getProcess(String procLabel)
        {
            return processMap[procLabel];
        }

        private void hook(object sender, EventArgs e)
        {
            String sourceAssemblyName = this.injectFileLabel.Text;
            if(this.targetFileName!=null)
            {
                if(sourceAssemblyName!=null)
                {
                    ModuleDefinition module = ModuleDefinition.ReadModule(sourceAssemblyName);
                    Console.WriteLine("Assembly Name: " + sourceAssemblyName);
                    procHook.setSourceAssembly(module);
                    procHook.setTargetAssembly(this.targetFileName);
                    Console.WriteLine("Attempting hook...");
                    procHook.attemptHook();
                    Console.WriteLine("Hook Finished");
                }
            }
            else
            {
                MessageBox.Show("No target assembly selected");
            }

        }

        public void getInjectFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "DLL Files | *.dll";
            openFileDialog1.Multiselect = false;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                injectFileName = openFileDialog1.FileName;
                this.injectFileLabel.Text = this.injectFileName;
            }
        }

        public void getTargetFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Executable Files | *.exe|DLL Files| *.dll";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.targetFileName = openFileDialog1.FileName;
                this.fileLabel.Text = this.targetFileName;
            }
        }

        private void addFile(object sender, EventArgs e)
        {
            if (targetFileName != null)
            {
                this.comboBox1.Items.Add(targetFileName);
                this.comboBox1.SelectedIndex = comboBox1.Items.Count-1;
                this.fileLabel.Text = "File Added!";
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void openCodeView(object sender, EventArgs e)
        {
            if(ideView==null)
            {
                ideView = new IDEWindow();
                ideView.Show();
            }
        }

        private void chooseInjectAssembly(object sender, EventArgs e)
        {
            getInjectFile();
        }
    }
}

/*this.comboBox1.Items.Clear();
processMap.Clear();
Process[] processlist = Process.GetProcesses();
foreach (Process process in processlist)
{
    Console.WriteLine(process);
    this.comboBox1.Items.Add(process.ProcessName);
    if (!processMap.ContainsKey(process.ProcessName))
    {
        processMap.Add(process.ProcessName, process);
    }
    try
    {
        Console.WriteLine(process.Modules.Count);
        foreach(Module m in process.Modules)
        {

        }
    }
    catch(Exception ex)
    {
        continue;
    }
}*/
