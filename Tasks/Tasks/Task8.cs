using System;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class Task8
    {
        public void Run()
        {
            if (!File.Exists("text.txt"))
            {
                Console.WriteLine("Файл text.txt не найден!");
                return;
            }

            char[] vowels = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            string text = File.ReadAllText("text.txt").ToLower();
            int totalChars = text.Length;

            if (totalChars == 0)
            {
                Console.WriteLine("Файл пуст!");
                return;
            }

            var vowelCounts = vowels.ToDictionary(v => v, v => text.Count(c => c == v));

            foreach (var item in vowelCounts.OrderByDescending(v => v.Value))
            {
                double ratio = (double)item.Value / totalChars;
                Console.WriteLine($"{item.Key}: {ratio:P2}");
            }
        }
    }
}