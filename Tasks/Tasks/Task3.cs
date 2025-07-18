using System;

namespace Tasks
{
    public class Task3
    {
        public void Run()
        {
            int[] sizes = { 100, 1000, 10000 };
            Random random = new Random();

            foreach (int size in sizes)
            {
                int[] array = new int[size];
                int zeros = 0, ones = 0;

                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next(0, 2);
                    if (array[i] == 0) zeros++;
                    else ones++;
                }

                double ratio = (double)ones / zeros;
                Console.WriteLine($"Размер: {size}, 1/0: {ratio:F4}");
            }
        }
    }
}