using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace searchFile
{
    public partial class Form1: Form
    {
        static ManualResetEvent pauseEvent = new ManualResetEvent(true); // true - поток сразу активен

        private Thread searchThread;

        private bool isSearching = false;

        private string logFilePath = "search_log.txt"; // Путь к файлу лога

        public Form1()
        {
            InitializeComponent();
        }

        private void bttnSearch_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            string path = textDirectory.Text;
            string mask = textMask.Text;

            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(mask))
            {
                MessageBox.Show("Enter path and mask to file!");
                return;
            }

            if (!isSearching)
            {
                searchThread = new Thread(() => SearchFiles(path, mask));
                searchThread.IsBackground = true;
                searchThread.Start();
                isSearching = true;
            }
            else
            {
                MessageBox.Show("Search is already running!");
            }           
        }

        private void SearchFiles(string path, string mask)
        {
            int count = 0;
            countFiles.Text = $"{count}";

            try
            {
                WriteToLog($"Search started in directory: {path} with mask: {mask}");

                foreach (string file in Directory.EnumerateFiles(path, mask, SearchOption.AllDirectories))
                {
                    // Если нажата кнопка "Stop", прекращаем работу
                    if (!pauseEvent.WaitOne(0)) return;

                    Invoke(new Action(() =>
                    {
                        listBox.Items.Add(file);
                        count++;
                        countFiles.Text = $"{count}";
                    }));

                    // Записываем найденный файл в лог
                    WriteToLog($"Found file: {file}");
                }

                Invoke(new Action(() =>
                {
                    MessageBox.Show("end of research.");
                }));

                WriteToLog("Search completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bttnStop_Click(object sender, EventArgs e)
        {
            // Останавливаем поток
            if (isSearching)
            {
                // Блокируем поток
                pauseEvent.Reset();
                isSearching = false;
                MessageBox.Show("Search stopped.");
            }
            else
            {
                MessageBox.Show("No search in progress.");
            }
        }

        private void WriteToLog(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to log: {ex.Message}");
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
