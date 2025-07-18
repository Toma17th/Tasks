using System;
using System.IO;
using System.Globalization;

namespace Tasks
{
    public class Task6
    {
        struct NumberPair
        {
            public double Original;
            public double Calculated;
        }

        public void Run()
        {
            if (!File.Exists("input.txt"))
            {
                Console.WriteLine("Файл input.txt не найден!");
                return;
            }

            string[] lines = File.ReadAllLines("input.txt");
            NumberPair[] pairs = new NumberPair[lines.Length];
            int processedCount = 0;

            // Устанавливаем культуру с точкой как разделителем
            CultureInfo culture = new CultureInfo("en-US");

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line))
                    continue;

                try
                {
                    double num = double.Parse(line, culture);
                    pairs[processedCount] = new NumberPair
                    {
                        Original = num,
                        Calculated = Math.Round(num * 0.18, 2)
                    };
                    processedCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Ошибка формата в строке {i + 1}: '{line}'");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при обработке строки {i + 1}: {ex.Message}");
                }
            }

            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                for (int i = 0; i < processedCount; i++)
                {
                    writer.WriteLine($"{pairs[i].Original.ToString("F2", culture)};{pairs[i].Calculated.ToString("F2", culture)}");
                }
            }

            Console.WriteLine($"Обработано {processedCount} из {lines.Length} строк. Результат записан в output.txt");
        }
    }
}