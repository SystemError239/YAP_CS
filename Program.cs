using System;
class Program
{
    static void Main()
    {
        NumberSet set1 = null;
        PointInSpace point = null;

        while (true)
        {
            Console.WriteLine("\n�������� ��������:");
            Console.WriteLine("1. ������� ������ �� ���� �����");
            Console.WriteLine("2. ������� ������ �� ���� �����");
            Console.WriteLine("3. ����� ����������� ��������� �����");
            Console.WriteLine("4. ������� ����� � ������������");
            Console.WriteLine("5. ������� ����� � ������������");
            Console.WriteLine("6. ����� ���������� �� ������ ���������");
            Console.WriteLine("7. �������� ����� � ������������");
            Console.WriteLine("8. ������� ����� �������");
            Console.WriteLine("9. �����");

            int choice = ValidInput.IntVal("������� ����� ��������: ");

            switch (choice)
            {
                case 1:
                    int a = ValidInput.IntVal("������� ������ �����: ");
                    int b = ValidInput.IntVal("������� ������ �����: ");
                    int c = ValidInput.IntVal("������� ������ �����: ");
                    set1 = new NumberSet(a, b, c);
                    break;

                case 2:
                    if (set1 != null)
                    {
                        Console.WriteLine("NumberSet: " + set1.ToString());
                    }
                    else
                    {
                        Console.WriteLine("������ �� ������");
                    }
                    break;

                case 3:
                    if (set1 != null)
                    {
                        Console.WriteLine("����������� ��������� �����: " + set1.GetMinLastDigit().ToString());
                    }
                    else
                    {
                        Console.WriteLine("������ �� ������");
                    }
                    break;

                case 4:
                    int x = ValidInput.IntVal("������� X: ");
                    int y = ValidInput.IntVal("������� Y: ");
                    int z = ValidInput.IntVal("������� Z: ");
                    point = new PointInSpace(x, y, z);
                    break;

                case 5:
                    if (point != null)
                    {
                        Console.WriteLine(point.ToString());
                    }
                    else
                    {
                        Console.WriteLine("������ �� ������");
                    }
                    break;

                case 6:
                    if (point != null)
                    {
                        Console.WriteLine("���������� �� ������ ���������: " + point.DistanceToOrigin().ToString());
                    }
                    else
                    {
                        Console.WriteLine("������ �� ������");
                    }
                    break;

                case 7:
                    if (point != null)
                    {
                        int dx = ValidInput.IntVal("������� �������� �� X: ");
                        int dy = ValidInput.IntVal("������� �������� �� Y: ");
                        int dz = ValidInput.IntVal("������� �������� �� Z: ");
                        point.SDVG(dx, dy, dz);
                        Console.WriteLine("����� ���������� " + point.ToString());
                    }
                    else
                    {
                        Console.WriteLine("������ �� ������");
                    }
                    break;
                case 8:
                    if (set1 != null)
                    {
                        NumberSet setCopy = new NumberSet(set1);  // ������� �����
                        Console.WriteLine("����� �������: " + setCopy.ToString());
                    }
                    else
                    {
                        Console.WriteLine("������ �� ������");
                    }
                    break;

                case 9:
                    return;

                default:
                    Console.WriteLine("�������� ����, ���������� �����.");
                    break;
            }

        }
    }
}
