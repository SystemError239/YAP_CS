public static class UserInput
{
    public static bool readYesOrNo(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (input == "y" || input == "д")
            {
                return true;
            }
            else if (input == "n" || input == "н")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите 'д' или 'н' (или 'y' / 'n').");
            }
        }
    }

    public static int readInteger(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result))
            {
                return result;
            }

            Console.WriteLine("Ошибка ввода. Введите целое число.");
        }
    }

    public static bool confirmFileGeneration(string message)
    {
        Console.Write(message);
        var input = Console.ReadLine()?.Trim().ToLower();
        return input == "д" || input == "y" || input == "yes";
    }
}
