using System;
using System.IO;
using System.Globalization;

namespace Tasks
{
    public class Task11
    {
        public void Run()
        {
            if (!File.Exists("input.txt"))
            {
                Console.WriteLine("Файл input.txt не найден!");
                return;
            }

            string[] lines = File.ReadAllLines("input.txt");
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (var line in lines)
                {
                    string[] words = line.Split(' ');
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(words[i]))
                        {
                            words[i] = textInfo.ToTitleCase(words[i].ToLower());
                        }
                    }
                    writer.WriteLine(string.Join(" ", words));
                }
            }

            Console.WriteLine("Результат записан в output.txt");
        }
    }
}