using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Tasks
{
    public class Task12
    {
        public void Run()
        {
            if (!File.Exists("story.txt"))
            {
                Console.WriteLine("Файл story.txt не найден!");
                return;
            }

            string[] lines = File.ReadAllLines("story.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                var matches = Regex.Matches(lines[i], @"(^|[.!?]\s+)([а-яё])");
                foreach (Match match in matches)
                {
                    if (char.IsLower(match.Groups[2].Value[0]))
                    {
                        Console.WriteLine($"Строка {i + 1}: '{match.Groups[2].Value}'");
                    }
                }
            }
        }
    }
}