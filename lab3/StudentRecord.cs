using System;
using System.Xml.Serialization;

/// <summary>
/// Представляет запись об ученике в журнале.
/// </summary>
[Serializable]
public class StudentRecord
{
    /// <summary>
    /// Фамилия ученика.
    /// </summary>
    [XmlElement]
    public string LastName { get; private set; }

    /// <summary>
    /// Имя ученика.
    /// </summary>
    [XmlElement]
    public string FirstName { get; private set; }

    /// <summary>
    /// Номер класса ученика.
    /// </summary>
    [XmlElement]
    public int Grade { get; private set; }

    /// <summary>
    /// Средний балл ученика.
    /// </summary>
    [XmlElement]
    public double AverageScore { get; private set; }

    /// <summary>
    /// Наличие долгов у ученика.
    /// </summary>
    [XmlElement]
    public bool HasDebts { get; private set; }

    /// <summary>
    /// Необходим для десериализации XML.
    /// </summary>
    public StudentRecord()
    {
    }

    /// <summary>
    /// Создаёт новый экземпляр записи об ученике.
    /// </summary>
    public StudentRecord(string lastName, string firstName, int grade, double averageScore, bool hasDebts)
    {
        LastName = lastName;
        FirstName = firstName;
        Grade = grade;
        AverageScore = averageScore;
        HasDebts = hasDebts;
    }

    /// <summary>
    /// Возвращает строку с информацией об ученике.
    /// </summary>
    public override string ToString()
    {
        return $"{LastName} {FirstName}, класс {Grade}, ср. балл: {AverageScore:F2}, долги: {(HasDebts ? "есть" : "нет")}";
    }
}
