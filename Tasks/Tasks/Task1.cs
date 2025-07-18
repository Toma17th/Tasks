using System;

namespace Tasks
{
    public class Task1
    {
        public void Run()
        {
            uint[] array = new uint[100];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (uint)random.Next(0, 1001);
            }

            uint max = array[0], min = array[0];
            int maxIndex = 0, minIndex = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxIndex = i;
                }
                if (array[i] < min)
                {
                    min = array[i];
                    minIndex = i;
                }
            }

            Console.WriteLine($"Максимальный элемент: {max} (индекс {maxIndex})");
            Console.WriteLine($"Минимальный элемент: {min} (индекс {minIndex})");
        }
    }
}