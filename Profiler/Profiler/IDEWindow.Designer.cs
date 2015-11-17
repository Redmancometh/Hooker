namespace Profiler
{
    partial class IDEWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.compilerOutput = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ideLabel = new System.Windows.Forms.Label();
            this.classNameLabel = new System.Windows.Forms.Label();
            this.classNameField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.assemblyNameField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 38);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(763, 451);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "public void jumpMethod()\r\n{\r\n\r\n}";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 627);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Compile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.compile);
            // 
            // compilerOutput
            // 
            this.compilerOutput.FormattingEnabled = true;
            this.compilerOutput.Location = new System.Drawing.Point(12, 513);
            this.compilerOutput.Name = "compilerOutput";
            this.compilerOutput.Size = new System.Drawing.Size(1408, 108);
            this.compilerOutput.TabIndex = 2;
            this.compilerOutput.SelectedIndexChanged += new System.EventHandler(this.compilerOutput_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 495);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Compiler Output";
            // 
            // ideLabel
            // 
            this.ideLabel.AutoSize = true;
            this.ideLabel.Location = new System.Drawing.Point(11, 15);
            this.ideLabel.Name = "ideLabel";
            this.ideLabel.Size = new System.Drawing.Size(338, 13);
            this.ideLabel.TabIndex = 4;
            this.ideLabel.Text = "Assembly Body (Methods Only!) entry point is public void jumpMethod()";
            // 
            // classNameLabel
            // 
            this.classNameLabel.AutoSize = true;
            this.classNameLabel.Location = new System.Drawing.Point(782, 43);
            this.classNameLabel.Name = "classNameLabel";
            this.classNameLabel.Size = new System.Drawing.Size(69, 13);
            this.classNameLabel.TabIndex = 5;
            this.classNameLabel.Text = "Class Name: ";
            this.classNameLabel.Click += new System.EventHandler(this.classNameLabel_Click);
            // 
            // classNameField
            // 
            this.classNameField.Location = new System.Drawing.Point(926, 38);
            this.classNameField.Name = "classNameField";
            this.classNameField.Size = new System.Drawing.Size(143, 20);
            this.classNameField.TabIndex = 6;
            this.classNameField.TextChanged += new System.EventHandler(this.classNameTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(782, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Assembly Name: ";
            // 
            // assemblyNameField
            // 
            this.assemblyNameField.Location = new System.Drawing.Point(926, 64);
            this.assemblyNameField.Name = "assemblyNameField";
            this.assemblyNameField.Size = new System.Drawing.Size(143, 20);
            this.assemblyNameField.TabIndex = 8;
            this.assemblyNameField.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // IDEWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 662);
            this.Controls.Add(this.assemblyNameField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.classNameField);
            this.Controls.Add(this.classNameLabel);
            this.Controls.Add(this.ideLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.compilerOutput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "IDEWindow";
            this.Text = "IDEWindow";
            this.Load += new System.EventHandler(this.IDEWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox compilerOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ideLabel;
        private System.Windows.Forms.Label classNameLabel;
        private System.Windows.Forms.TextBox classNameField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox assemblyNameField;
    }
}