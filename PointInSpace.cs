using System;



// Дочерний класс, представляющий координаты точки в 3D-пространстве
class PointInSpace : NumberSet
{
    // Конструктор, принимающий координаты x, y, z
    public PointInSpace(int x, int y, int z) : base(x, y, z) { }

    // Вычисление расстояния от точки до начала координат
    public double DistanceToOrigin()
    {
        return Math.Sqrt(num1 * num1 + num2 * num2 + num3 * num3);
    }

    // Сдвиг точки на указанные значения по осям X, Y и Z
    public void SDVG(int dx, int dy, int dz)
    {
        num1 += dx;
        num2 += dy;
        num3 += dz;
    }

    // Переопределение метода ToString() для вывода координат точки
    public override string ToString()
    {
        return $"Point({num1}, {num2}, {num3})";
    }
}

