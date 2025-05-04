using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int[] numbers = { -5, 10, -15, 20, 25, 30, 35, 0, 45, 50 };


        private Task<int> FindMinValue(int[] array)
        {
            return Task.Run(() => array.Min());
        }

        private Task<int> FindMaxValue(int[] array)
        {
            return Task.Run(() => array.Max());
        }

        private Task<double> CalculateAverage(int[] array)
        {
            return Task.Run(() => array.Average());
        }

        private Task<int> CalculateSum(int[] array)
        {
            return Task.Run(() => array.Sum());
        }

        // выполняем все операции параллельно
        private async Task PerformArrayOperationsAsync()
        {
            // запуск всех операций параллельно (с использованием Task.WhenAll)
            var minTask = FindMinValue(numbers);
            var maxTask = FindMaxValue(numbers);
            var avgTask = CalculateAverage(numbers);
            var sumTask = CalculateSum(numbers);

            // ожидание завершения всех задач
            await Task.WhenAll(minTask, maxTask, avgTask, sumTask);

            int minValue = minTask.Result;
            int maxValue = maxTask.Result;
            double averageValue = avgTask.Result;
            int sumValue = sumTask.Result;

            MessageBox.Show($"Min Value: {minValue}\nMax Value: {maxValue}\nAverage Value: {averageValue}\nSum: {sumValue}");
        }

        private async void buttonRun_Click(object sender, EventArgs e)
        {
            await PerformArrayOperationsAsync();
        }
    }
}
