using System;

namespace Tasks
{
    public class Task2
    {
        public void Run()
        {
            uint[] array = new uint[100];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (uint)random.Next(0, 1000002);
            }

            int[] ranges = new int[7];
            int[] limits = { 10, 100, 1000, 10000, 100000, 1000000 };

            foreach (var num in array)
            {
                int rangeIndex = 0;
                while (rangeIndex < limits.Length && num > limits[rangeIndex])
                {
                    rangeIndex++;
                }
                ranges[rangeIndex]++;
            }

            for (int i = 0; i < ranges.Length; i++)
            {
                string rangeStr = i == 0 ? "0-10" :
                    i == limits.Length ? $"{limits[i - 1] + 1}+" :
                    $"{limits[i - 1] + 1}-{limits[i]}";
                Console.WriteLine($"{rangeStr}: {ranges[i]} элементов");
            }
        }
    }
}