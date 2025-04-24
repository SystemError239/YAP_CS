using System;

/// <summary>
/// Представляет запись об ученике в журнале.
/// Содержит ФИО, номер класса, средний балл и информацию о наличии долгов.
/// </summary>
[Serializable]
public class StudentRecord
{
    /// <summary>
    /// Фамилия ученика.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Имя ученика.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Класс ученика (от 1 до 11).
    /// </summary>
    public int Grade { get; set; }

    /// <summary>
    /// Средний балл ученика.
    /// </summary>
    public double AverageScore { get; set; }

    /// <summary>
    /// Наличие долгов у ученика (true — есть долги, false — нет долгов).
    /// </summary>
    public bool HasDebts { get; set; }

    /// <summary>
    /// Пустой конструктор, необходимый для работы XmlSerializer.
    /// </summary>
    public StudentRecord()
    {
    }

    /// <summary>
    /// Создаёт экземпляр записи об ученике.
    /// </summary>
    /// <param name="lastName">Фамилия</param>
    /// <param name="firstName">Имя</param>
    /// <param name="grade">Класс</param>
    /// <param name="averageScore">Средний балл</param>
    /// <param name="hasDebts">Наличие долгов</param>
    public StudentRecord(string lastName, string firstName, int grade, double averageScore, bool hasDebts)
    {
        LastName = lastName;
        FirstName = firstName;
        Grade = grade;
        AverageScore = averageScore;
        HasDebts = hasDebts;
    }

    /// <summary>
    /// Возвращает строковое представление записи.
    /// </summary>
    /// <returns>Фамилия, имя, класс, средний балл и информация о долгах.</returns>
    public override string ToString()
    {
        return $"{LastName} {FirstName}, класс {Grade}, ср. балл: {AverageScore:F2}, долги: {(HasDebts ? "есть" : "нет")}";
    }
}
