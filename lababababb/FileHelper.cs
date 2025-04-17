using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;


public static class FileHelper
{

    public static void generateFileWithIntegers(string path, int count)
    {
        var rnd = new Random();
        var sb = new StringBuilder();

        for (int i = 0; i < count; i++)
        {
            sb.Append(rnd.Next(0, 100)).Append(' ');
        }

        File.WriteAllText(path, sb.ToString().Trim());
    }

    public static void generateFileWithMultipleIntegers(string path, int count, int multipleOf)
    {
        var rnd = new Random();
        var sb = new StringBuilder();

        for (int i = 0; i < count; i++)
        {
            int value = rnd.Next(1, 20);
            sb.Append(value * multipleOf).Append(' ');
        }

        File.WriteAllText(path, sb.ToString().Trim());
    }

    public static List<int> readIntegersFromFile(string path)
    {
        var content = File.ReadAllText(path);
        var parts = content.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        var list = new List<int>();

        foreach (var part in parts)
        {
            if (int.TryParse(part, out var number))
            {
                list.Add(number);
            }
        }

        return list;
    }

    public static void generateFileWithTextLines(string path)
    {
        var lines = new[]
        {
            "Hello World!",
            "Я русский.",
            "1234567890",
            "Eng.",
            "Тестовая строка."
        };

        File.WriteAllLines(path, lines);
    }

    public static void generateBinaryFileWithIntegers(string path, int count)
    {
        var rnd = new Random();

        using var writer = new BinaryWriter(File.Open(path, FileMode.Create));
        for (int i = 0; i < count; i++)
        {
            writer.Write(rnd.Next(1, 100));
        }
    }

    public static void generateToyBinaryFile(string path, int count)
    {
        var toys = new List<Toy>();
        var rnd = new Random();

        for (int i = 0; i < count; i++)
        {
            string name = i % 2 == 0 ? $"Конструктор {i + 1}" : $"Игрушка {i + 1}";
            double price = rnd.Next(500, 5001) + rnd.NextDouble();

            toys.Add(new Toy
            {
                Name = name,
                Price = Math.Round(price, 2)
            });
        }

        using var fs = new FileStream(path, FileMode.Create);
        using var writer = new BinaryWriter(fs, Encoding.UTF8);

        writer.Write(toys.Count);
        foreach (var toy in toys)
        {
            writer.Write(toy.Name);
            writer.Write(toy.Price);
        }
    }

    public static List<Toy> readToysFromBinary(string path)
    {
        var toys = new List<Toy>();

        using var fs = new FileStream(path, FileMode.Open);
        using var reader = new BinaryReader(fs, Encoding.UTF8);

        int count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
        {
            string name = reader.ReadString();
            double price = reader.ReadDouble();
            toys.Add(new Toy { Name = name, Price = price });
        }

        return toys;
    }

    public static void writeToysToXml(List<Toy> toys, string path)
    {
        var serializer = new XmlSerializer(typeof(List<Toy>));
        using var stream = File.Open(path, FileMode.Create);
        serializer.Serialize(stream, toys);
    }
    
}

