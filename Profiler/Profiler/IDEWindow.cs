using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Profiler
{
    public partial class IDEWindow : Form
    {
        private RuntimeCompiler compiler = new RuntimeCompiler();
        private static Regex errorRegex = new Regex("error CS.*");
        public IDEWindow()
        {
            InitializeComponent();
        }

        private void compile(object sender, EventArgs e)
        {
            compilerOutput.Items.Clear();
            CompilerResults output = compiler.compileCode(classNameField.Text,textBox1.Text, this.assemblyNameField.Text);
            if (output.Errors.Count > 0)
            {
                foreach (String outputLine in output.Output)
                {
                    if (errorRegex.Match(outputLine).Success)
                    {
                        compilerOutput.Items.Add(outputLine);
                    }
                }
            }
            else
            {
                compilerOutput.Items.Clear();
                compilerOutput.Items.Add("Successfully Compiled!");
                Program.window.injectFileName = output.PathToAssembly;
            }
        }

        private void classNameTextChanged(object sender, EventArgs e)
        {
            this.classNameLabel.Text = "Class Name: "+this.classNameField.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void IDEWindow_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void compilerOutput_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void classNameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
