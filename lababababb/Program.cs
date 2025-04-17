
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Задание 1: Сумма элементов, равных своему индексу");
            Console.WriteLine("2. Задание 2: Произведение элементов, кратных заданному числу");
            Console.WriteLine("3. Задание 3: Строки без русских букв");
            Console.WriteLine("4. Задание 4: Кратные k из бинарного файла");
            Console.WriteLine("5. Задание 5: Самый дорогой конструктор (XML)");
            Console.WriteLine("6. Задание 6: List");
            Console.WriteLine("7. Задание 7: LinkedList");
            Console.WriteLine("8. Задание 8: HashSet");
            Console.WriteLine("9. Задание 9: HashSet");
            Console.WriteLine("10. Задание 10: Dictionary/SortedList");
            Console.WriteLine("11. Выход");

            int choice = UserInput.readInteger("Введите номер действия: ");

            switch (choice)
            {
                case 1:
                    Task15.task1();
                    break;
                case 2:
                    Task15.task2();
                    break;
                case 3:
                    Task15.task3();
                    break;
                case 4:
                    Task15.task4();
                    break;
                case 5:
                    Task15.task5();
                    break;
                case 6:
                    Task15.task6();
                    break;
                case 7:
                    Task15.task7();
                    break;
                case 8:
                    Task15.task8();
                    break;
                case 9:
                    Task15.task9();
                    break;
                case 10:
                    Task15.task10();
                    break;
                case 11:
                    return;
                default:
                    Console.WriteLine("Некорректный ввод, попробуйте снова.");
                    break;
            }
        }
    }

    
}

