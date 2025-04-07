class ValidInput
{
    public static int IntVal(string prin)
    {
        int value;
        while (true)
        {
            Console.Write(prin);
            if (int.TryParse(Console.ReadLine(), out value))
                return value;
            Console.WriteLine("ќшибка! ¬ведите корректное целое число.");
        }
    }
}