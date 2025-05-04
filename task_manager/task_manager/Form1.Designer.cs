namespace task_manager
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
            this.components = new System.ComponentModel.Container();
            this.listTask = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.buttonKill = new System.Windows.Forms.Button();
            this.buttonPriority = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listTask
            // 
            this.listTask.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listTask.FullRowSelect = true;
            this.listTask.HideSelection = false;
            this.listTask.Location = new System.Drawing.Point(83, 68);
            this.listTask.Name = "listTask";
            this.listTask.Size = new System.Drawing.Size(530, 115);
            this.listTask.TabIndex = 0;
            this.listTask.UseCompatibleStateImageBehavior = false;
            this.listTask.View = System.Windows.Forms.View.Details;
            this.listTask.SelectedIndexChanged += new System.EventHandler(this.listTask_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Priority";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Состояние";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Память";
            this.columnHeader5.Width = 80;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(83, 222);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(401, 20);
            this.textBoxID.TabIndex = 1;
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Items.AddRange(new object[] {
            "Idle",
            "BelowNormal",
            "Normal",
            "AboveNormal",
            "High",
            "RealTime"});
            this.comboBoxPriority.Location = new System.Drawing.Point(83, 297);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(401, 21);
            this.comboBoxPriority.TabIndex = 2;
            this.comboBoxPriority.Text = "Priority";
            // 
            // buttonKill
            // 
            this.buttonKill.Location = new System.Drawing.Point(193, 370);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(224, 74);
            this.buttonKill.TabIndex = 3;
            this.buttonKill.Text = "End process";
            this.buttonKill.UseVisualStyleBackColor = true;
            this.buttonKill.Click += new System.EventHandler(this.buttonKill_Click);
            // 
            // buttonPriority
            // 
            this.buttonPriority.Location = new System.Drawing.Point(478, 371);
            this.buttonPriority.Name = "buttonPriority";
            this.buttonPriority.Size = new System.Drawing.Size(224, 73);
            this.buttonPriority.TabIndex = 4;
            this.buttonPriority.Text = "Change priority";
            this.buttonPriority.UseVisualStyleBackColor = true;
            this.buttonPriority.Click += new System.EventHandler(this.buttonPriority_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 548);
            this.Controls.Add(this.buttonPriority);
            this.Controls.Add(this.buttonKill);
            this.Controls.Add(this.comboBoxPriority);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.listTask);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listTask;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.Button buttonKill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonPriority;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}

