using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tasks
{
    public class Task9
    {
        public void Run()
        {
            if (!File.Exists("products9.txt"))
            {
                Console.WriteLine("Файл products9.txt не найден!");
                return;
            }

            string[] lines = File.ReadAllLines("products9.txt");
            var cleanedLines = lines.Select(line => Regex.Replace(line, @"\(.*?\)", "").Trim());

            int uniqueCount = cleanedLines.Distinct().Count();
            Console.WriteLine($"Уникальных строк: {uniqueCount}");
        }
    }
}