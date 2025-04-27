using System;

/// <summary>
/// Представляет запись об ученике в журнале.
/// </summary>
[Serializable]
public class StudentRecord
{
    private string _lastName;
    private string _firstName;
    private int _grade;
    private double _averageScore;
    private bool _hasDebts;

    /// <summary>
    /// Фамилия ученика.
    /// </summary>
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    /// <summary>
    /// Имя ученика.
    /// </summary>
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }

    /// <summary>
    /// Номер класса ученика.
    /// </summary>
    public int Grade
    {
        get { return _grade; }
        set { _grade = value; }
    }

    /// <summary>
    /// Средний балл ученика.
    /// </summary>
    public double AverageScore
    {
        get { return _averageScore; }
        set { _averageScore = value; }
    }

    /// <summary>
    /// Наличие долгов у ученика.
    /// </summary>
    public bool HasDebts
    {
        get { return _hasDebts; }
        set { _hasDebts = value; }
    }

    /// <summary>
    /// Пустой конструктор для сериализации.
    /// </summary>
    public StudentRecord()
    {
    }

    /// <summary>
    /// Создаёт новый объект записи об ученике.
    /// </summary>
    public StudentRecord(string lastName, string firstName, int grade, double averageScore, bool hasDebts)
    {
        _lastName = lastName;
        _firstName = firstName;
        _grade = grade;
        _averageScore = averageScore;
        _hasDebts = hasDebts;
    }

    /// <summary>
    /// Возвращает строковое представление записи об ученике.
    /// </summary>
    public override string ToString()
    {
        return $"{LastName} {FirstName}, класс {Grade}, ср. балл: {AverageScore:F2}, долги: {(HasDebts ? "есть" : "нет")}";
    }
}
