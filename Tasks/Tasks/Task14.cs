using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class Task14
    {
        public void Run()
        {
            if (!File.Exists("months.txt"))
            {
                Console.WriteLine("Файл months.txt не найден!");
                return;
            }

            string[] monthsOrder = { "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь" };
            var monthIndices = monthsOrder.Select((name, index) => new { name, index })
                                        .ToDictionary(x => x.name, x => x.index);

            var data = new Dictionary<string, double>();
            string[] lines = File.ReadAllLines("months.txt");

            foreach (var line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length != 2)
                {
                    Console.WriteLine($"Ошибка формата: {line}");
                    continue;
                }

                string month = parts[0].ToLower();
                if (monthIndices.ContainsKey(month) && double.TryParse(parts[1], out double value))
                {
                    data[month] = value;
                }
                else
                {
                    Console.WriteLine($"Ошибка: некорректный месяц или значение в строке {line}");
                }
            }

            int increases = 0, decreases = 0;
            for (int i = 1; i < monthsOrder.Length; i++)
            {
                string currentMonth = monthsOrder[i];
                string previousMonth = monthsOrder[i - 1];

                if (data.TryGetValue(currentMonth, out double current) && data.TryGetValue(previousMonth, out double previous))
                {
                    if (current > previous) increases++;
                    else if (current < previous) decreases++;
                }
            }

            Console.WriteLine($"Увеличений: {increases}, уменьшений: {decreases}");
        }
    }
}