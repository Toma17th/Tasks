using System;
using System.Globalization;
using System.IO;

namespace Tasks
{
    public class Task7
    {
        public void Run()
        {
            if (!File.Exists("Input7.txt"))
            {
                Console.WriteLine("Файл Input7.txt не найден!");
                return;
            }

            string[] lines = File.ReadAllLines("Input7.txt");
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(';');
                if (parts.Length != 2)
                {
                    Console.WriteLine($"Ошибка формата: {line.Trim()}");
                    continue;
                }

                string num1Str = parts[0].Trim();
                string num2Str = parts[1].Trim();

                if (!TryParseDouble(num1Str, out double num1) || !TryParseDouble(num2Str, out double num2))
                {
                    Console.WriteLine($"Ошибка парсинга: {line.Trim()}");
                    continue;
                }

                double expected = Math.Round(num1 * 0.18, 2, MidpointRounding.AwayFromZero);
                double actual = Math.Round(num2, 2, MidpointRounding.AwayFromZero);

                if (Math.Abs(actual - expected) > 0.001)
                {
                    Console.WriteLine($"Ошибка: {line.Trim()} (ожидалось {expected.ToString("F2", CultureInfo.InvariantCulture)})");
                }
            }
        }

        private bool TryParseDouble(string s, out double result)
        {
            // Пробуем стандартный парсинг
            if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                return true;

            // Пробуем заменить запятую на точку
            if (double.TryParse(s.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                return true;

            // Пробуем заменить точку на запятую (для европейского формата)
            if (double.TryParse(s.Replace('.', ','), NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                return true;

            result = 0;
            return false;
        }
    }
}