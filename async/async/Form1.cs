using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task SearchWordInFile(string path, string word)
        {
            listView.Items.Clear();

            if (!File.Exists(path))
            {
                MessageBox.Show("File not found!");
                return;
            }

            int count = await CountWordAsync(path, word);

            listView.Invoke(new Action(() =>
            {
                listView.Items.Add($"Count: {count}");
            }));

            MessageBox.Show("Search complete!");
        }

        private async Task<int> CountWordAsync(string path, string word)
        {
            try
            {
                int count = 0;

                // async чтение содержимого файла
                using (StreamReader reader = new StreamReader(path))
                {
                    string content = await reader.ReadToEndAsync();

                    // Count вхождений слова
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


        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            string path = textBoxPath.Text;
            string word = textBoxWord.Text;

            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(word))
            {
                MessageBox.Show("Path and word cannot be empty!");
                return;
            }

            try
            {
                // Запуск поиска в асинхронном режиме
                await SearchWordInFile(path, word);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void listResults_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
