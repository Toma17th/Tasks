using System;
using System.Linq;

namespace Tasks
{
    public class Task4
    {
        public void Run()
        {
            int[] array = new int[100];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-100, 101);
            }

            int[] positive = array.Where(x => x > 0).ToArray();
            int[] negative = array.Where(x => x < 0).ToArray();

            Console.WriteLine($"Положительные: {string.Join(", ", positive)}");
            Console.WriteLine($"Отрицательные: {string.Join(", ", negative)}");
        }
    }
}