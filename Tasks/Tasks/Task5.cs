using System;
using System.IO;

namespace Tasks
{
    public class Task5
    {
        public void Run()
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter("numbers.txt"))
            {
                for (int i = 0; i < 100; i++)
                {
                    double num = random.NextDouble() * 100;
                    writer.WriteLine($"{num:F2}");
                }
            }
            Console.WriteLine("Файл создан.");
        }
    }
}