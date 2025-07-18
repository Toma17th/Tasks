using System;
using Tasks;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите задачу (1-14) или 0 для выхода:");
            int taskNumber;
            if (!int.TryParse(Console.ReadLine(), out taskNumber) || taskNumber < 0 || taskNumber > 14)
            {
                Console.WriteLine("Некорректный ввод!");
                continue;
            }

            if (taskNumber == 0) break;

            switch (taskNumber)
            {
                case 1: new Task1().Run(); break;
                case 2: new Task2().Run(); break;
                case 3: new Task3().Run(); break;
                case 4: new Task4().Run(); break;
                case 5: new Task5().Run(); break;
                case 6: new Task6().Run(); break;
                case 7: new Task7().Run(); break;
                case 8: new Task8().Run(); break;
                case 9: new Task9().Run(); break;
                case 10: new Task10().Run(); break;
                case 11: new Task11().Run(); break;
                case 12: new Task12().Run(); break;
                case 13: new Task13().Run(); break;
                case 14: new Task14().Run(); break;
            }

            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}