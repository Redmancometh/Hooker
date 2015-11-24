namespace Profiler
{
    partial class MainWindow
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
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.injectFileLabel = new System.Windows.Forms.Label();
            this.processButton = new System.Windows.Forms.Button();
            this.constructorInject = new System.Windows.Forms.CheckBox();
            this.searchExe = new System.Windows.Forms.CheckBox();
            this.searchDLL = new System.Windows.Forms.CheckBox();
            this.recursiveBox = new System.Windows.Forms.CheckBox();
            this.replaceEntryBox = new System.Windows.Forms.CheckBox();
            this.dllEntry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Choose File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.chooseTargetFile);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 480);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(279, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBoxUpdate);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 507);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Hook";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.hook);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(93, 507);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Add File";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.addFile);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(12, 453);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(88, 13);
            this.fileLabel.TabIndex = 4;
            this.fileLabel.Text = "Target Assembly:";
            this.fileLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(15, 417);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Choose Assembly";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.chooseInjectAssembly);
            // 
            // injectFileLabel
            // 
            this.injectFileLabel.AutoSize = true;
            this.injectFileLabel.Location = new System.Drawing.Point(12, 390);
            this.injectFileLabel.Name = "injectFileLabel";
            this.injectFileLabel.Size = new System.Drawing.Size(95, 13);
            this.injectFileLabel.TabIndex = 7;
            this.injectFileLabel.Text = "Assembly to Inject:";
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(124, 417);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(75, 23);
            this.processButton.TabIndex = 8;
            this.processButton.Text = "Process";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // constructorInject
            // 
            this.constructorInject.AutoSize = true;
            this.constructorInject.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.constructorInject.Location = new System.Drawing.Point(15, 359);
            this.constructorInject.Name = "constructorInject";
            this.constructorInject.Size = new System.Drawing.Size(135, 17);
            this.constructorInject.TabIndex = 9;
            this.constructorInject.Text = "Inject Into Constructors";
            this.constructorInject.UseVisualStyleBackColor = true;
            this.constructorInject.CheckedChanged += new System.EventHandler(this.constructorInject_CheckedChanged);
            // 
            // searchExe
            // 
            this.searchExe.AutoSize = true;
            this.searchExe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchExe.Location = new System.Drawing.Point(294, 421);
            this.searchExe.Name = "searchExe";
            this.searchExe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.searchExe.Size = new System.Drawing.Size(84, 17);
            this.searchExe.TabIndex = 10;
            this.searchExe.Text = "Search EXE";
            this.searchExe.UseVisualStyleBackColor = true;
            // 
            // searchDLL
            // 
            this.searchDLL.AutoSize = true;
            this.searchDLL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchDLL.Location = new System.Drawing.Point(205, 421);
            this.searchDLL.Name = "searchDLL";
            this.searchDLL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.searchDLL.Size = new System.Drawing.Size(83, 17);
            this.searchDLL.TabIndex = 11;
            this.searchDLL.Text = "Search DLL";
            this.searchDLL.UseVisualStyleBackColor = true;
            this.searchDLL.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // recursiveBox
            // 
            this.recursiveBox.AutoSize = true;
            this.recursiveBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.recursiveBox.Location = new System.Drawing.Point(387, 421);
            this.recursiveBox.Name = "recursiveBox";
            this.recursiveBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.recursiveBox.Size = new System.Drawing.Size(74, 17);
            this.recursiveBox.TabIndex = 12;
            this.recursiveBox.Text = "Recursive";
            this.recursiveBox.UseVisualStyleBackColor = true;
            // 
            // replaceEntryBox
            // 
            this.replaceEntryBox.AutoSize = true;
            this.replaceEntryBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.replaceEntryBox.Location = new System.Drawing.Point(15, 336);
            this.replaceEntryBox.Name = "replaceEntryBox";
            this.replaceEntryBox.Size = new System.Drawing.Size(159, 17);
            this.replaceEntryBox.TabIndex = 13;
            this.replaceEntryBox.Text = "Replace Entire EntryMethod";
            this.replaceEntryBox.UseVisualStyleBackColor = true;
            this.replaceEntryBox.CheckedChanged += new System.EventHandler(this.replaceEntry_CheckedChanged);
            // 
            // dllEntry
            // 
            this.dllEntry.Location = new System.Drawing.Point(255, 510);
            this.dllEntry.Name = "dllEntry";
            this.dllEntry.Size = new System.Drawing.Size(274, 20);
            this.dllEntry.TabIndex = 14;
            this.dllEntry.Text = "DLL Entry Point (Namespace.Type.Method)";
            this.dllEntry.TextChanged += new System.EventHandler(this.dllEntryChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 542);
            this.Controls.Add(this.dllEntry);
            this.Controls.Add(this.replaceEntryBox);
            this.Controls.Add(this.recursiveBox);
            this.Controls.Add(this.searchDLL);
            this.Controls.Add(this.searchExe);
            this.Controls.Add(this.constructorInject);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.injectFileLabel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "MainWindow";
            this.Text = "Profiler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label injectFileLabel;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.CheckBox constructorInject;
        private System.Windows.Forms.CheckBox searchExe;
        private System.Windows.Forms.CheckBox searchDLL;
        private System.Windows.Forms.CheckBox recursiveBox;
        private System.Windows.Forms.CheckBox replaceEntryBox;
        private System.Windows.Forms.TextBox dllEntry;
    }
}

