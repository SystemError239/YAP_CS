using System;
using System.Xml.Serialization;

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
    /// Создаёт новый экземпляр записи об ученике с проверкой всех входных данных.
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
    /// Пустой конструктор необходим для XML-сериализации.
    /// </summary>
    public StudentRecord()
    {
    }

    /// <summary>
    /// Фамилия ученика.
    /// </summary>
    public string LastName
    {
        get => _lastName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Фамилия не может быть пустой.");
            }

            _lastName = value.Trim();
        }
    }

    /// <summary>
    /// Имя ученика.
    /// </summary>
    public string FirstName
    {
        get => _firstName;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Имя не может быть пустым.");
            }

            _firstName = value.Trim();
        }
    }

    /// <summary>
    /// Класс ученика (1–11).
    /// </summary>
    public int Grade
    {
        get => _grade;
        private set
        {
            if (value < 1 || value > 11)
            {
                throw new ArgumentOutOfRangeException(nameof(Grade), "Класс должен быть от 1 до 11.");
            }

            _grade = value;
        }
    }

    /// <summary>
    /// Средний балл ученика (0.00–5.00).
    /// </summary>
    public double AverageScore
    {
        get => _averageScore;
        private set
        {
            if (value < 0 || value > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(AverageScore), "Средний балл должен быть от 0 до 5.");
            }

            _averageScore = value;
        }
    }

    /// <summary>
    /// Наличие долгов у ученика.
    /// </summary>
    public bool HasDebts
    {
        get => _hasDebts;
        private set => _hasDebts = value;
    }

    /// <summary>
    /// Возвращает строковое представление записи об ученике.
    /// </summary>
    public override string ToString()
    {
        return $"{LastName} {FirstName}, класс {Grade}, ср. балл: {AverageScore:F2}, долги: {(HasDebts ? "есть" : "нет")}";
    }
}
