using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

/// <summary>
/// Предоставляет функциональность для работы с базой данных записей студентов,
/// хранящейся в бинарном файле в формате XML.
/// </summary>
public static class JournalManager
{
    /// <summary>
    /// Путь к файлу базы данных.
    /// </summary>
    private const string _filePath = "journal.dat";

    /// <summary>
    /// Загружает базу данных из файла XML в список.
    /// </summary>
    /// <param name="journal">Список, куда будут загружены записи студентов.</param>
    public static void readDatabase(List<StudentRecord> journal)
    {
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        try
        {
            using (FileStream stream = new FileStream(_filePath, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<StudentRecord>));

                // Десериализация XML-данных в список
                List<StudentRecord> loaded = (List<StudentRecord>)serializer.Deserialize(reader);

                // Обновляем текущий список
                journal.Clear();
                journal.AddRange(loaded);

                Console.WriteLine("База данных успешно загружена.");
            }
        }
        catch (Exception ex)
        {
            // В случае ошибки выводим сообщение
            Console.WriteLine("Ошибка при загрузке базы данных: " + ex.Message);
        }
    }

    /// <summary>
    /// Сохраняет текущий список студентов в XML-файл.
    /// </summary>
    /// <param name="journal">Список записей студентов для сохранения.</param>
    public static void saveDatabase(List<StudentRecord> journal)
    {
        try
        {
            using (FileStream stream = new FileStream(_filePath, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<StudentRecord>));

                // Сохраняем список в XML в файл
                serializer.Serialize(writer, journal);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при сохранении базы данных: " + ex.Message);
        }
    }

    /// <summary>
    /// Отображает все записи студентов в консоли.
    /// </summary>
    /// <param name="journal">Список записей для отображения.</param>
    public static void viewDatabase(List<StudentRecord> journal)
    {
        if (journal.Count == 0)
        {
            Console.WriteLine("Журнал пуст.");
            return;
        }

        foreach (StudentRecord record in journal)
        {
            // Печать каждой записи в формате, заданном в ToString()
            Console.WriteLine(record.ToString());
        }
    }

    /// <summary>
    /// Добавляет новую запись студента в журнал, запрашивая данные у пользователя.
    /// </summary>
    /// <param name="journal">Список, куда будет добавлена новая запись.</param>
    public static void addRecord(List<StudentRecord> journal)
    {
        // Считываем данные у пользователя
        Console.Write("Фамилия: ");
        string lastName = Console.ReadLine();

        Console.Write("Имя: ");
        string firstName = Console.ReadLine();

        // Ввод с проверкой
        int grade = readInt("Класс (1-11): ", 1, 11);
        double averageScore = readDouble("Средний балл (0-5): ", 0, 5);

        Console.Write("Есть ли долги (д/н): ");
        bool hasDebts = Console.ReadLine()?.ToLower() == "д";

        // Добавляем запись
        journal.Add(new StudentRecord(lastName, firstName, grade, averageScore, hasDebts));
        Console.WriteLine("Запись добавлена.");
    }

    /// <summary>
    /// Удаляет все записи студентов с заданной фамилией.
    /// </summary>
    /// <param name="journal">Список, из которого удаляются записи.</param>
    public static void deleteRecordByLastName(List<StudentRecord> journal)
    {
        Console.Write("Введите фамилию для удаления: ");
        string lastName = Console.ReadLine();

        // Удаляем записи по фамилии, игнорируя регистр
        int removed = journal.RemoveAll(r => r.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

        if (removed > 0)
        {
            Console.WriteLine($"Удалено записей: {removed}");
            return;
        }

        Console.WriteLine("Записи с такой фамилией не найдены.");
    }

    /// <summary>
/// Запрос: выводит всех студентов со средним баллом выше 4.5.
/// </summary>
public static void query1(List<StudentRecord> journal)
{
    // Выбираем всех, у кого средний балл больше 4.5
    var excellent =
        from student in journal
        where student.AverageScore > 4.5
        select student;

    Console.WriteLine("\nОтличники:");
    foreach (StudentRecord record in excellent)
    {
        Console.WriteLine(record.ToString());
    }
}

/// <summary>
/// Запрос: выводит всех студентов, у которых есть долги.
/// </summary>
public static void query2(List<StudentRecord> journal)
{
    // Отбираем учеников с долгами
    var withDebts =
        from student in journal
        where student.HasDebts
        select student;

    Console.WriteLine("\nУченики с долгами:");
    foreach (StudentRecord record in withDebts)
    {
        Console.WriteLine(record.ToString());
    }
}

/// <summary>
/// Запрос: вычисляет средний балл студентов по заданному классу.
/// </summary>
public static void query3(List<StudentRecord> journal)
{
    int grade = readInt("Введите номер класса для расчёта среднего балла: ", 1, 11);

    // Отбираем учеников заданного класса
    var filtered =
        from student in journal
        where student.Grade == grade
        select student;

    if (!filtered.Any())
    {
        Console.WriteLine("В данном классе нет записей.");
        return;
    }

    // Считаем средний балл
    double average = filtered.Average(s => s.AverageScore);
    Console.WriteLine($"Средний балл в классе {grade}: {average:F2}");
}

/// <summary>
/// Запрос: выводит количество студентов без долгов.
/// </summary>
public static void query4(List<StudentRecord> journal)
{
    var noDebts =
        from student in journal
        where !student.HasDebts
        select student;

    int count = noDebts.Count();
    Console.WriteLine($"Количество учеников без долгов: {count}");
}


    /// <summary>
    /// Считывает целое число в указанном диапазоне.
    /// </summary>
    private static int readInt(string prompt, int min, int max)
    {
        int value;

        do
        {
            Console.Write(prompt);
        }
        while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max);

        return value;
    }

    /// <summary>
    /// Считывает число с плавающей точкой в указанном диапазоне.
    /// </summary>
    private static double readDouble(string prompt, double min, double max)
    {
        double value;

        do
        {
            Console.Write(prompt);
        }
        while (!double.TryParse(Console.ReadLine(), out value) || value < min || value > max);

        return value;
    }
}
