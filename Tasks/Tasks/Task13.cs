using System;
using System.IO;

namespace Tasks
{
    public class Task13
    {
        public void Run()
        {
            if (!File.Exists("products13.txt"))
            {
                Console.WriteLine("Файл products.txt не найден!");
                return;
            }

            string[] lines = File.ReadAllLines("products13.txt");
            double totalQuantity = 0, totalSum = 0;

            using (StreamWriter writer = new StreamWriter("report.txt"))
            {
                foreach (var line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length != 3)
                    {
                        Console.WriteLine($"Ошибка формата: {line}");
                        continue;
                    }

                    if (double.TryParse(parts[1], out double price) && double.TryParse(parts[2], out double quantity))
                    {
                        double sum = price * quantity;
                        writer.WriteLine($"{parts[0]};{price:F2};{quantity:F3};{sum:F2}");

                        totalQuantity += quantity;
                        totalSum += sum;
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка парсинга: {line}");
                    }
                }

                writer.WriteLine($"ИТОГО;;{totalQuantity:F3};{totalSum:F2}");
            }

            Console.WriteLine("Отчёт сформирован в report.txt");
        }
    }
}