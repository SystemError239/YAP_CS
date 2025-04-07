//проверка пользовательского ввода
class NumberSet
{
    protected int num1;
    protected int num2;
    protected int num3;

    // Конструктор для инициализации полей
    public NumberSet(int a, int b, int c)
    {
        num1 = a;
        num2 = b;
        num3 = c;
    }

    // Конструктор копирования
    public NumberSet(NumberSet other)
    {
        num1 = other.num1;
        num2 = other.num2;
        num3 = other.num3;
    }

    // Вычисление минимальной последней цифры среди полей
    public int GetMinLastDigit()
    {
        int last1 = Math.Abs(num1) % 10;
        int last2 = Math.Abs(num2) % 10;
        int last3 = Math.Abs(num3) % 10;
        return Math.Min(last1, Math.Min(last2, last3));
    }

    // Переопределение метода ToString() для формирования строки из полей
    public override string ToString()
    {
        return $"{num1}, {num2}, {num3}";
    }
}