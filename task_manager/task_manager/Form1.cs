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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;


namespace task_manager
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10000;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            LoadProcess();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            LoadProcess();
        }

        private void LoadProcess()
        {
            listTask.Items.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process processItem in processes)
            {
                try
                {
                    var item = new ListViewItem(processItem.ProcessName);
                    item.SubItems.Add(processItem.Id.ToString());
                    item.SubItems.Add(processItem.BasePriority.ToString());

                    // Состояние
                    string status = processItem.Responding ? "Выполняется" : "Не отвечает";
                    item.SubItems.Add(status);

                    // Память
                    double memoryMB = processItem.WorkingSet64 / (1024.0 * 1024.0);
                    item.SubItems.Add($"{memoryMB:0.0}");

                    listTask.Items.Add(item);
                }
                catch
                {
                    continue;
                }
            }
        }

        private void buttonKill_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBoxID.Text);
                Process.GetProcessById(id).Kill();
                LoadProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonPriority_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBoxID.Text);
                var process = Process.GetProcessById(id);
                process.PriorityClass = (ProcessPriorityClass)Enum.Parse(typeof(ProcessPriorityClass), comboBoxPriority.SelectedItem.ToString());
                LoadProcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void listTask_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
