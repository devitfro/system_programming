using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SearchWordInFile(string path, string word)
        {
            listView.Items.Clear();
             
            if (!File.Exists(path))
            {
                MessageBox.Show("File not found!");
                return;
            }

            // Запускаем задачу в пуле потоков для поиска
            ThreadPool.QueueUserWorkItem(state =>
            {
                int count = CountWord(path, word);

                listView.Invoke(new Action(() =>
                {
                    listView.Items.Add($"Count: {count}");
                }));

                MessageBox.Show("Search complete!");
            });
        }

        private int CountWord(string path, string word)
        {
            try
            {
                int count = 0;

                using (StreamReader reader = new StreamReader(path))
                {
                    string content = reader.ReadToEnd(); // Синхронно читаем весь файл

                    count = (content.Length - content.Replace(word, "").Length) / word.Length;
                }

                return count;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file {path}: {ex.Message}");
                return 0;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string path = textBoxPath.Text;
            string word = textBoxWord.Text;

            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Path and word cannot be empty!");
                return;
            }

            SearchWordInFile(path, word);
        }
    }
}
