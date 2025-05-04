namespace searchFile
{
    partial class Form1
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.textDirectory = new System.Windows.Forms.TextBox();
            this.textMask = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.countFiles = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(380, 61);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(115, 72);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "SEARCH";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.bttnSearch_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(73, 197);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(352, 82);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // textDirectory
            // 
            this.textDirectory.Location = new System.Drawing.Point(73, 61);
            this.textDirectory.Name = "textDirectory";
            this.textDirectory.Size = new System.Drawing.Size(235, 20);
            this.textDirectory.TabIndex = 2;
            // 
            // textMask
            // 
            this.textMask.Location = new System.Drawing.Point(73, 107);
            this.textMask.Name = "textMask";
            this.textMask.Size = new System.Drawing.Size(235, 20);
            this.textMask.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Results:";
            // 
            // countFiles
            // 
            this.countFiles.Location = new System.Drawing.Point(87, 351);
            this.countFiles.Name = "countFiles";
            this.countFiles.Size = new System.Drawing.Size(126, 20);
            this.countFiles.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Count of founded files:";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(535, 61);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(115, 72);
            this.buttonStop.TabIndex = 7;
            this.buttonStop.Text = "STOP SEARCH";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.bttnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.countFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textMask);
            this.Controls.Add(this.textDirectory);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.buttonSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox textDirectory;
        private System.Windows.Forms.TextBox textMask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox countFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStop;
    }
}

