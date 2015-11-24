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
using System.IO;
using System.Threading;

namespace Profiler
{
    public partial class MainWindow : Form
    {
        Dictionary<String, Process> processMap = new Dictionary<String, Process>();
        private String targetFileName { get; set; }
        public String injectFileName { get; set; }
        private String testDirectory { get; set; }
        public ProcessHook procHook = new ProcessHook();
        private IDEWindow ideView;
        public MainWindow()
        {
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
            procHook.replaceEntry = replaceEntryBox.Checked;
            String sourceAssemblyName = this.injectFileLabel.Text;
            if (this.targetFileName != null)
            {
                if (sourceAssemblyName != null)
                {
                    ModuleDefinition module = ModuleDefinition.ReadModule(sourceAssemblyName);
                    Console.WriteLine("Assembly Name: " + sourceAssemblyName);
                    procHook.setSourceAssembly(module);
                    procHook.setTargetAssembly(this.targetFileName);
                    Console.WriteLine("Attempting hook...");
                    procHook.attemptHook(constructorInject.Checked);
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

        public void getAssemblyDir()
        {
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                testDirectory = openFileDialog1.SelectedPath;
                if (searchDLL.Checked && searchExe.Checked)
                {
                    Parallel.Invoke(() => { searchFiles("*.dll", testDirectory); }, () => { searchFiles("*.exe", testDirectory); });
                }
                else if(searchDLL.Checked)
                {
                    Parallel.Invoke(() => { searchFiles("*.dll", testDirectory); } );
                }
                else if(searchExe.Checked)
                {
                    Parallel.Invoke(() => { searchFiles("*.exe", testDirectory); });
                }
            }
        }


        public void searchFiles(String filePattern, String fileDirectory)
        {
            Console.WriteLine("Searching");
            SearchOption option;
            if(recursiveBox.Checked)
            {
                option = SearchOption.AllDirectories;
            }
            else
            {
                option = SearchOption.TopDirectoryOnly;
            }
            foreach (String file in Directory.GetFiles(testDirectory, filePattern, option))
            {
                try
                {
                    AssemblyName testAssembly = AssemblyName.GetAssemblyName(file);
                    Console.WriteLine("Found assembly: " + file+"\r\n\r\n\r\n");
                    comboBox1.Items.Add(file);
                }
                catch (Exception e)
                {
                    continue;
                }
            }
            Console.WriteLine("Done Searching.");
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
                this.comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                this.fileLabel.Text = "File Added!";
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void openCodeView(object sender, EventArgs e)
        {
            if (ideView == null)
            {
                ideView = new IDEWindow();
                ideView.Show();
            }
        }

        private void chooseInjectAssembly(object sender, EventArgs e)
        {
            getInjectFile();
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            getAssemblyDir();
        }

        private void comboBoxUpdate(object sender, EventArgs e)
        {
            this.targetFileName = comboBox1.SelectedItem.ToString();
        }

        private void constructorInject_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void replaceEntry_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dllEntryChanged(object sender, EventArgs e)
        {
            procHook.dllEntry = dllEntry.Text;
        }
    }
}


