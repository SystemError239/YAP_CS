public static class UserInput
{
    public static bool readYesOrNo(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (input == "y" || input == "�")
            {
                return true;
            }
            else if (input == "n" || input == "�")
            {
                return false;
            }
            else
            {
                Console.WriteLine("������������ ����. ������� '�' ��� '�' (��� 'y' / 'n').");
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

            Console.WriteLine("������ �����. ������� ����� �����.");
        }
    }

    public static bool confirmFileGeneration(string message)
    {
        Console.Write(message);
        var input = Console.ReadLine()?.Trim().ToLower();
        return input == "�" || input == "y" || input == "yes";
    }
}
