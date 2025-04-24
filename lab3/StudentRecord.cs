using System;

/// <summary>
/// ������������ ������ �� ������� � �������.
/// �������� ���, ����� ������, ������� ���� � ���������� � ������� ������.
/// </summary>
[Serializable]
public class StudentRecord
{
    /// <summary>
    /// ������� �������.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// ��� �������.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// ����� ������� (�� 1 �� 11).
    /// </summary>
    public int Grade { get; set; }

    /// <summary>
    /// ������� ���� �������.
    /// </summary>
    public double AverageScore { get; set; }

    /// <summary>
    /// ������� ������ � ������� (true � ���� �����, false � ��� ������).
    /// </summary>
    public bool HasDebts { get; set; }

    /// <summary>
    /// ������ �����������, ����������� ��� ������ XmlSerializer.
    /// </summary>
    public StudentRecord()
    {
    }

    /// <summary>
    /// ������ ��������� ������ �� �������.
    /// </summary>
    /// <param name="lastName">�������</param>
    /// <param name="firstName">���</param>
    /// <param name="grade">�����</param>
    /// <param name="averageScore">������� ����</param>
    /// <param name="hasDebts">������� ������</param>
    public StudentRecord(string lastName, string firstName, int grade, double averageScore, bool hasDebts)
    {
        LastName = lastName;
        FirstName = firstName;
        Grade = grade;
        AverageScore = averageScore;
        HasDebts = hasDebts;
    }

    /// <summary>
    /// ���������� ��������� ������������� ������.
    /// </summary>
    /// <returns>�������, ���, �����, ������� ���� � ���������� � ������.</returns>
    public override string ToString()
    {
        return $"{LastName} {FirstName}, ����� {Grade}, ��. ����: {AverageScore:F2}, �����: {(HasDebts ? "����" : "���")}";
    }
}
