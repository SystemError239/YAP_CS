using System;
class Program
{
    static void Main()
    {
        NumberSet set1 = null;
        PointInSpace point = null;
        
        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Создать массив из трех чисел");
            Console.WriteLine("2. Вывести массив из трех чисел");
            Console.WriteLine("3. Найти минимальную последнюю цифру");
            Console.WriteLine("4. Создать точку в пространстве");
            Console.WriteLine("5. Вывести точку в пространстве");
            Console.WriteLine("6. Найти расстояние до начала координат");
            Console.WriteLine("7. Сместить точку в пространстве");
            Console.WriteLine("8. Создать копию объекта");
            Console.WriteLine("9. Выход");

            int choice = ValidInput.IntVal("Введите номер действия: ");

            switch (choice)
            {
                case 1:
                    int a = ValidInput.IntVal("Введите первое число: ");
                    int b = ValidInput.IntVal("Введите второе число: ");
                    int c = ValidInput.IntVal("Введите третье число: ");
                    set1 = new NumberSet(a, b, c);
                    break;

                case 2:
                    if (set1 != null)
                    {
                        Console.WriteLine("NumberSet: " + set1.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Объект не создан");
                    }
                    break;

                case 3:
                    if (set1 != null)
                    {
                        Console.WriteLine("Минимальная последняя цифра: " + set1.GetMinLastDigit().ToString());
                    }
                    else
                    {
                        Console.WriteLine("Объект не создан");
                    }
                    break;

                case 4:
                    int x = ValidInput.IntVal("Введите X: ");
                    int y = ValidInput.IntVal("Введите Y: ");
                    int z = ValidInput.IntVal("Введите Z: ");
                    point = new PointInSpace(x, y, z);
                    break;

                case 5:
                    if (point != null)
                    {
                        Console.WriteLine(point.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Объект не создан");
                    }
                    break;

                case 6:
                    if (point != null)
                    {
                        Console.WriteLine("Расстояние до начала координат: " + point.DistanceToOrigin().ToString());
                    }
                    else
                    {
                        Console.WriteLine("Объект не создан");
                    }
                    break;

                case 7:
                    if (point != null)
                    {
                        int dx = ValidInput.IntVal("Введите смещение по X: ");
                        int dy = ValidInput.IntVal("Введите смещение по Y: ");
                        int dz = ValidInput.IntVal("Введите смещение по Z: ");
                        point.SDVG(dx, dy, dz);
                        Console.WriteLine("Новые координаты " + point.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Объект не создан");
                    }
                    break;
                case 8:
                    if (set1 != null)
                    {
                        NumberSet setCopy = new NumberSet(set1);  // Создаем копию
                        Console.WriteLine("Копия создана: " + setCopy.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Объект не создан");
                    }
                    break;

                case 9:
                    return;

                default:
                    Console.WriteLine("Неверный ввод, попробуйте снова.");
                    break;
            }

        }
    }
}
