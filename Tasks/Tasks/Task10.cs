using System;
using System.Linq;

namespace Tasks
{
    public class Task10
    {
        public void Run()
        {
            Random random = new Random();
            string chars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";
            string result = new string(chars.OrderBy(c => random.Next()).Distinct().Take(10).ToArray());

            Console.WriteLine($"Случайная строка: {result}");
        }
    }
}