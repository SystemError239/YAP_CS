using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<StudentRecord> journal = new List<StudentRecord>();

        while (true)
        {
            Console.WriteLine("\nЖУРНАЛ КЛАССА:");
            Console.WriteLine("1. Загрузить базу данных");
            Console.WriteLine("2. Показать все записи");
            Console.WriteLine("3. Добавить запись");
            Console.WriteLine("4. Удалить запись по фамилии");
            Console.WriteLine("5. Запрос 1: Отличники (ср. балл > 4.5)");
            Console.WriteLine("6. Запрос 2: Ученики с долгами");
            Console.WriteLine("7. Запрос 3: Средний балл по классу");
            Console.WriteLine("8. Запрос 4: Кол-во учеников без долгов");
            Console.WriteLine("9. Сохранить и выйти");
            Console.Write("Выбор: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1": JournalManager.readDatabase(journal); break;
                case "2": JournalManager.viewDatabase(journal); break;
                case "3": JournalManager.addRecord(journal); break;
                case "4": JournalManager.deleteRecordByLastName(journal); break;
                case "5": JournalManager.query1(journal); break;
                case "6": JournalManager.query2(journal); break;
                case "7": JournalManager.query3(journal); break;
                case "8": JournalManager.query4(journal); break;
                case "9":
                    JournalManager.saveDatabase(journal);
                    Console.WriteLine("База данных сохранена. Выход...");
                    return;
                default:
                    Console.WriteLine("Некорректный ввод. Повторите попытку.");
                    break;
            }
        }
    }
}
