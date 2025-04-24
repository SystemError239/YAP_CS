using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

/// <summary>
/// ������������� ���������������� ��� ������ � ����� ������ ������� ���������,
/// ���������� � �������� ����� � ������� XML.
/// </summary>
public static class JournalManager
{
    /// <summary>
    /// ���� � ����� ���� ������.
    /// </summary>
    private const string _filePath = "journal.dat";

    /// <summary>
    /// ��������� ���� ������ �� ����� XML � ������.
    /// </summary>
    /// <param name="journal">������, ���� ����� ��������� ������ ���������.</param>
    public static void readDatabase(List<StudentRecord> journal)
    {
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("���� �� ������.");
            return;
        }

        try
        {
            using (FileStream stream = new FileStream(_filePath, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<StudentRecord>));

                // �������������� XML-������ � ������
                List<StudentRecord> loaded = (List<StudentRecord>)serializer.Deserialize(reader);

                // ��������� ������� ������
                journal.Clear();
                journal.AddRange(loaded);

                Console.WriteLine("���� ������ ������� ���������.");
            }
        }
        catch (Exception ex)
        {
            // � ������ ������ ������� ���������
            Console.WriteLine("������ ��� �������� ���� ������: " + ex.Message);
        }
    }

    /// <summary>
    /// ��������� ������� ������ ��������� � XML-����.
    /// </summary>
    /// <param name="journal">������ ������� ��������� ��� ����������.</param>
    public static void saveDatabase(List<StudentRecord> journal)
    {
        try
        {
            using (FileStream stream = new FileStream(_filePath, FileMode.Create))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<StudentRecord>));

                // ��������� ������ � XML � ����
                serializer.Serialize(writer, journal);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("������ ��� ���������� ���� ������: " + ex.Message);
        }
    }

    /// <summary>
    /// ���������� ��� ������ ��������� � �������.
    /// </summary>
    /// <param name="journal">������ ������� ��� �����������.</param>
    public static void viewDatabase(List<StudentRecord> journal)
    {
        if (journal.Count == 0)
        {
            Console.WriteLine("������ ����.");
            return;
        }

        foreach (StudentRecord record in journal)
        {
            // ������ ������ ������ � �������, �������� � ToString()
            Console.WriteLine(record.ToString());
        }
    }

    /// <summary>
    /// ��������� ����� ������ �������� � ������, ���������� ������ � ������������.
    /// </summary>
    /// <param name="journal">������, ���� ����� ��������� ����� ������.</param>
    public static void addRecord(List<StudentRecord> journal)
    {
        // ��������� ������ � ������������
        Console.Write("�������: ");
        string lastName = Console.ReadLine();

        Console.Write("���: ");
        string firstName = Console.ReadLine();

        // ���� � ���������
        int grade = readInt("����� (1-11): ", 1, 11);
        double averageScore = readDouble("������� ���� (0-5): ", 0, 5);

        Console.Write("���� �� ����� (�/�): ");
        bool hasDebts = Console.ReadLine()?.ToLower() == "�";

        // ��������� ������
        journal.Add(new StudentRecord(lastName, firstName, grade, averageScore, hasDebts));
        Console.WriteLine("������ ���������.");
    }

    /// <summary>
    /// ������� ��� ������ ��������� � �������� ��������.
    /// </summary>
    /// <param name="journal">������, �� �������� ��������� ������.</param>
    public static void deleteRecordByLastName(List<StudentRecord> journal)
    {
        Console.Write("������� ������� ��� ��������: ");
        string lastName = Console.ReadLine();

        // ������� ������ �� �������, ��������� �������
        int removed = journal.RemoveAll(r => r.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

        if (removed > 0)
        {
            Console.WriteLine($"������� �������: {removed}");
            return;
        }

        Console.WriteLine("������ � ����� �������� �� �������.");
    }

    /// <summary>
    /// ������: ������� ���� ��������� �� ������� ������ ���� 4.5.
    /// </summary>
    /// <param name="journal">������ ���������.</param>
    public static void query1(List<StudentRecord> journal)
    {
        // ����� �������� �� ������� ������ ���� 4.5
        List<StudentRecord> excellent = journal.Where(r => r.AverageScore > 4.5).ToList();

        Console.WriteLine("\n���������:");
        foreach (StudentRecord record in excellent)
        {
            Console.WriteLine(record.ToString());
        }
    }

    /// <summary>
    /// ������: ������� ���� ���������, � ������� ���� �����.
    /// </summary>
    /// <param name="journal">������ ���������.</param>
    public static void query2(List<StudentRecord> journal)
    {
        // ����� �������� � �������
        List<StudentRecord> withDebts = journal.Where(r => r.HasDebts).ToList();

        Console.WriteLine("\n������� � �������:");
        foreach (StudentRecord record in withDebts)
        {
            Console.WriteLine(record.ToString());
        }
    }

    /// <summary>
    /// ������: ��������� ������� ���� ��������� �� ��������� ������.
    /// </summary>
    /// <param name="journal">������ ���������.</param>
    public static void query3(List<StudentRecord> journal)
    {
        int grade = readInt("������� ����� ������ ��� ������� �������� �����: ", 1, 11);

        // �������� ���� �������� ����������� ������
        List<StudentRecord> filtered = journal.Where(r => r.Grade == grade).ToList();

        if (filtered.Count == 0)
        {
            Console.WriteLine("� ������ ������ ��� �������.");
            return;
        }

        // ������� ������� ���� � ���������� �������
        double average = filtered.Average(r => r.AverageScore);
        Console.WriteLine($"������� ���� � ������ {grade}: {average:F2}");
    }

    /// <summary>
    /// ������: ������� ���������� ��������� ��� ������.
    /// </summary>
    /// <param name="journal">������ ���������.</param>
    public static void query4(List<StudentRecord> journal)
    {
        // ������� ���� ��� ������
        int count = journal.Count(r => !r.HasDebts);
        Console.WriteLine($"���������� �������� ��� ������: {count}");
    }

    /// <summary>
    /// ��������� ����� ����� � ��������� ���������.
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
    /// ��������� ����� � ��������� ������ � ��������� ���������.
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
