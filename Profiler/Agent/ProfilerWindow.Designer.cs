namespace Agent
{
    public partial class ProfilerWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            this.objectList = new System.Windows.Forms.ListBox();
            this.checkButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.methodList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // objectList
            // 
            this.objectList.FormattingEnabled = true;
            this.objectList.Location = new System.Drawing.Point(12, 31);
            this.objectList.Name = "objectList";
            this.objectList.Size = new System.Drawing.Size(754, 95);
            this.objectList.TabIndex = 0;
            this.objectList.SelectedIndexChanged += new System.EventHandler(this.objectListChanged);
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(12, 132);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(75, 23);
            this.checkButton.TabIndex = 1;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Invoke";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.invokeClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Invoke";
            // 
            // methodList
            // 
            this.methodList.FormattingEnabled = true;
            this.methodList.Location = new System.Drawing.Point(92, 193);
            this.methodList.Name = "methodList";
            this.methodList.Size = new System.Drawing.Size(262, 21);
            this.methodList.TabIndex = 5;
            this.methodList.SelectedIndexChanged += new System.EventHandler(this.methodList_SelectedIndexChanged);
            this.methodList.SelectedValueChanged += new System.EventHandler(this.methodListUpdated);
            // 
            // ProfilerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 495);
            this.Controls.Add(this.methodList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.objectList);
            this.Name = "ProfilerWindow";
            this.Text = "ProfilerWindow";
            this.Load += new System.EventHandler(this.ProfilerWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListBox objectList;
        public System.Windows.Forms.Button checkButton;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox methodList;
    }
}