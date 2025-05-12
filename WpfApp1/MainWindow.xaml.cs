using System;
using System.Windows;

/// <summary>
/// Главное окно WPF-приложения для работы с квадратными уравнениями.
/// </summary>
public partial class MainWindow : Window
{
    private double a, b, c;

    /// <summary>
    /// Конструктор окна. Выполняет инициализацию интерфейса.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Обработчик кнопки "Рассчитать корни".
    /// Вычисляет корни квадратного уравнения и выводит их.
    /// </summary>
    private void OnCalculateRoots(object sender, RoutedEventArgs e)
    {
        if (!TryReadCoefficients()) return;

        double discriminant = b * b - 4 * a * c;

        // Вычисление корней на основе дискриминанта
        if (discriminant > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            textBoxResult.Text = $"Два корня: x1 = {x1:F2}, x2 = {x2:F2}";
        }
        else if (discriminant == 0)
        {
            double x = -b / (2 * a);
            textBoxResult.Text = $"Один корень: x = {x:F2}";
        }
        else
        {
            textBoxResult.Text = "Нет действительных корней.";
        }
    }

    /// <summary>
    /// Увеличивает коэффициенты A, B и C на 1.
    /// </summary>
    private void OnIncreaseCoefficients(object sender, RoutedEventArgs e)
    {
        if (!TryReadCoefficients()) return;

        a += 1;
        b += 1;
        c += 1;

        // Обновление текстбоксов новыми значениями
        textBoxA.Text = a.ToString();
        textBoxB.Text = b.ToString();
        textBoxC.Text = c.ToString();

        textBoxResult.Text = "Коэффициенты увеличены на 1.";
    }

    /// <summary>
    /// Уменьшает коэффициенты A, B и C на 1.
    /// </summary>
    private void OnDecreaseCoefficients(object sender, RoutedEventArgs e)
    {
        if (!TryReadCoefficients()) return;

        a -= 1;
        b -= 1;
        c -= 1;

        textBoxA.Text = a.ToString();
        textBoxB.Text = b.ToString();
        textBoxC.Text = c.ToString();

        textBoxResult.Text = "Коэффициенты уменьшены на 1.";
    }

    /// <summary>
    /// Показывает дискриминант уравнения.
    /// </summary>
    private void OnShowDiscriminant(object sender, RoutedEventArgs e)
    {
        if (!TryReadCoefficients()) return;

        double discriminant = b * b - 4 * a * c;
        textBoxResult.Text = $"Дискриминант: {discriminant:F2}";
    }

    /// <summary>
    /// Проверяет, есть ли действительные корни.
    /// </summary>
    private void OnCheckHasRoots(object sender, RoutedEventArgs e)
    {
        if (!TryReadCoefficients()) return;

        double discriminant = b * b - 4 * a * c;
        textBoxResult.Text = discriminant >= 0 ? "Уравнение имеет действительные корни." : "Корней нет.";
    }

    /// <summary>
    /// Считывает значения A, B, C из текстбоксов и проверяет правильность ввода.
    /// </summary>
    /// <returns>True, если удалось считать все значения, иначе false.</returns>
    private bool TryReadCoefficients()
    {
        // Проверка ввода коэффициентов
        bool validA = double.TryParse(textBoxA.Text, out a);
        bool validB = double.TryParse(textBoxB.Text, out b);
        bool validC = double.TryParse(textBoxC.Text, out c);

        if (!validA || !validB || !validC)
        {
            textBoxResult.Text = "Ошибка: введите корректные числовые значения для A, B и C.";
            return false;
        }

        return true;
    }
}
