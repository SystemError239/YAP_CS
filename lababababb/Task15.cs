using System.Text;


class Task15
{
    public static void task1()
    {
        const string path = "task1.txt";
        int k = UserInput.readInteger("Сколько элементов сгенерировать: ");
        FileHelper.generateFileWithIntegers(path, k);
        List<int> numbers = FileHelper.readIntegersFromFile(path);
        
        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == i)
            {
                sum += numbers[i];
            }
        }

        Console.WriteLine($"Сумма элементов, равных своему индексу: {sum}");
    }


    public static void task2()
    {
        const string path = "task2.txt";
        FileHelper.generateFileWithMultipleIntegers(path, 20, 5);
        List<int> numbers = FileHelper.readIntegersFromFile(path);

        int k = UserInput.readInteger("Введите число k: ");
        int product = 1;
        bool found = false;

        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % k == 0)
            {
                product *= numbers[i];
                found = true;
            }
        }

        if (found)
        {
            Console.WriteLine($"Произведение элементов, кратных {k}: {product}");
            return;
        }

        Console.WriteLine($"Элементы, кратные {k}, не найдены.");
    }


    public static void task3()
    {
        const string sourcePath = "task3.txt";
        const string targetPath = "task3_output.txt";

        FileHelper.generateFileWithTextLines(sourcePath);
        string[] lines = File.ReadAllLines(sourcePath);
        List<string> result = new List<string>();

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            bool hasRussian = false;

            for (int j = 0; j < line.Length; j++)
            {
                char ch = line[j];
                if ((ch >= 'А' && ch <= 'я') || ch == 'ё' || ch == 'Ё')
                {
                    hasRussian = true;
                    break;
                }
            }

            if (!hasRussian)
            {
                result.Add(line);
            }
        }

        File.WriteAllLines(targetPath, result);
        Console.WriteLine("Файл успешно обработан. Результат записан в task3_output.txt");
    }


    public static void task4()
    {
        const string sourcePath = "task4.dat";
        const string targetPath = "task4_output.dat";

        FileHelper.generateBinaryFileWithIntegers(sourcePath, 100);
        int k = UserInput.readInteger("Введите число k: ");

        using (BinaryReader reader = new BinaryReader(File.Open(sourcePath, FileMode.Open)))
        using (BinaryWriter writer = new BinaryWriter(File.Open(targetPath, FileMode.Create)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int number = reader.ReadInt32();
                if (number % k == 0)
                {
                    writer.Write(number);
                }
            }
        }

        Console.WriteLine("Файл успешно обработан. Результат записан в task4_output.dat");
        Console.WriteLine("\nСодержимое исходного файла:");
        printBinaryFileIntegers(sourcePath);

        Console.WriteLine("\nСодержимое итогового файла (кратные " + k + "):");
        printBinaryFileIntegers(targetPath);
    }
    private static void printBinaryFileIntegers(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не найден: " + path);
            return;
        }

        using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int number = reader.ReadInt32();
                Console.Write(number + " ");
            }
        }

        Console.WriteLine();
    }

    public static void task5()
    {
        const string binaryPath = "task5.dat";
        const string xmlPath = "task5.xml";

        if (UserInput.readYesOrNo("Создать коллекцию игрушек заново? (д/н): "))

        {
            int count = UserInput.readInteger("Сколько игрушек сгенерировать? ");
            FileHelper.generateToyBinaryFile(binaryPath, count);
        }

        List<Toy> toys = FileHelper.readToysFromBinary(binaryPath);
        FileHelper.writeToysToXml(toys, xmlPath);

        double maxPrice = -1;
        bool found = false;

        for (int i = 0; i < toys.Count; i++)
        {
            if (toys[i].Name.Contains("Конструктор") && toys[i].Price > maxPrice)
            {
                maxPrice = toys[i].Price;
                found = true;
            }
        }

        if (found)
        {
            Console.WriteLine($"Стоимость самого дорогого конструктора: {maxPrice:F2} руб.");
            return;
        }

        Console.WriteLine("Конструкторы не найдены в файле.");
    }

    public static void task6()
    {
        int size = UserInput.readInteger("Введите количество элементов в списке: ");
        List<int> list = new List<int>();

        for (int i = 0; i < size; i++)
        {
            int number = UserInput.readInteger($"Введите элемент {i + 1}: ");
            list.Add(number);
        }

        bool hasDuplicates = false;

        // Двойной цикл — проверяем каждый элемент на совпадение с остальными
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[i] == list[j])
                {
                    hasDuplicates = true;
                    break;
                }
            }

            if (hasDuplicates)
            {
                break;
            }
        }

        if (hasDuplicates)
        {
            Console.WriteLine("В списке есть хотя бы два одинаковых элемента.");
            return;
        }

        Console.WriteLine("В списке нет одинаковых элементов.");
    }

    public static void task7()
    {
        int size = UserInput.readInteger("Введите количество элементов в связном списке: ");
        LinkedList<int> list = new LinkedList<int>();

        for (int i = 0; i < size; i++)
        {
            int number = UserInput.readInteger($"Введите элемент {i + 1}: ");
            list.AddLast(number);
        }

        int target = UserInput.readInteger("Введите значение для удаления: ");
        LinkedListNode<int>? current = list.First;

        while (current != null)
        {
            if (current.Value == target)
            {
                list.Remove(current);
                Console.WriteLine("Первое вхождение удалено.");
                printLinkedList(list);
                return;
            }

            current = current.Next;
        }

        Console.WriteLine("Элемент не найден.");
    }

    private static void printLinkedList(LinkedList<int> list)
    {
        foreach (int number in list)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }

    public static void task8()
    {
        
        bool manual = UserInput.readYesOrNo("Вы хотите ввести данные вручную? (д/н): ");

        HashSet<string> allTracks = new HashSet<string>();
        List<HashSet<string>> listeners = new List<HashSet<string>>();

        if (manual)
        {
            int trackCount = UserInput.readInteger("Введите количество музыкальных произведений: ");
            for (int i = 0; i < trackCount; i++)
            {
                Console.Write($"Произведение {i + 1}: ");
                allTracks.Add(Console.ReadLine());
            }

            int listenerCount = UserInput.readInteger("Введите количество меломанов: ");
            for (int i = 0; i < listenerCount; i++)
            {
                Console.WriteLine($"Меломан #{i + 1}:");
                int likedCount = UserInput.readInteger("Сколько произведений он любит: ");
                HashSet<string> liked = new HashSet<string>();

                for (int j = 0; j < likedCount; j++)
                {
                    Console.Write($"  Название {j + 1}: ");
                    liked.Add(Console.ReadLine());
                }

                listeners.Add(liked);
            }
        }
        else
        {
            // Автоматическая генерация списка произведений и предпочтений меломанов
            allTracks = new HashSet<string> { "HOT", "UNFORGIVEN", "CRAZY", "FEARLESS", "Perfect Night", "Smart (Remixes)", "Choices", "FEARLESS (Japanese ver.)", "Jewelry" };
            int listenerCount = UserInput.readInteger("Введите количество меломанов: ");
            Random rnd = new Random();

            for (int i = 0; i < listenerCount; i++)
            {
                HashSet<string> liked = new HashSet<string>();

                foreach (string song in allTracks)
                {
                    if (rnd.Next(3) == 0)
                    {
                        liked.Add(song);
                    }
                }

                listeners.Add(liked);
            }

            Console.WriteLine("Список всех произведений:");
            foreach (string song in allTracks)
            {
                Console.WriteLine("- " + song);
            }
        }

        // Выводим предпочтения каждого меломана
        Console.WriteLine("\nПредпочтения меломанов:");
        for (int i = 0; i < listeners.Count; i++)
        {
            Console.WriteLine($"Меломан #{i + 1}:");
            foreach (string song in listeners[i])
            {
                Console.WriteLine("  - " + song);
            }
        }

        HashSet<string> likedByAll = new HashSet<string>(allTracks);
        foreach (HashSet<string> set in listeners)
        {
            likedByAll.IntersectWith(set);
        }

        HashSet<string> likedBySome = new HashSet<string>();
        foreach (HashSet<string> set in listeners)
        {
            likedBySome.UnionWith(set);
        }

        HashSet<string> likedByNone = new HashSet<string>(allTracks);
        likedByNone.ExceptWith(likedBySome);

        Console.WriteLine("\nНравятся всем:");
        printSet(likedByAll);

        Console.WriteLine("Нравятся хотя бы одному:");
        printSet(likedBySome);

        Console.WriteLine("Не нравятся никому:");
        printSet(likedByNone);
    }

    private static void printSet(HashSet<string> set)
    {
        if (set.Count == 0)
        {
            Console.WriteLine("  — Нет");
            return;
        }

        foreach (string s in set)
        {
            Console.WriteLine("  - " + s);
        }
    }

    public static void task9()
    {
        const string path = "task9.txt";
        HashSet<char> vowels = new HashSet<char> { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };

        if (!File.Exists(path))
        {
            Console.WriteLine("Файл task9.txt не найден.");
            return;
        }

        string[] lines = File.ReadAllLines(path);
        Dictionary<char, int> vowelUsage = new Dictionary<char, int>();

        for (int i = 0; i < lines.Length; i++)
        {
            string[] words = lines[i].Split(new[] { ' ', ',', '.', ':', ';', '!', '?', '-', '—', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            List<HashSet<char>> wordVowels = new List<HashSet<char>>();

            for (int j = 0; j < words.Length; j++)
            {
                HashSet<char> vowelSet = new HashSet<char>();
                string word = words[j].ToLower();

                for (int k = 0; k < word.Length; k++)
                {
                    if (vowels.Contains(word[k]))
                    {
                        vowelSet.Add(word[k]);
                    }
                }

                wordVowels.Add(vowelSet);
            }

            for (int j = 0; j < wordVowels.Count; j++)
            {
                foreach (char ch in wordVowels[j])
                {
                    if (vowelUsage.ContainsKey(ch))
                    {
                        vowelUsage[ch]++;
                    }
                    else
                    {
                        vowelUsage[ch] = 1;
                    }
                }
            }
        }

        List<char> rareVowels = new List<char>();
        foreach (KeyValuePair<char, int> pair in vowelUsage)
        {
            if (pair.Value <= 1)
            {
                rareVowels.Add(pair.Key);
            }
        }

        rareVowels.Sort();

        Console.WriteLine("\nГласные, которые встречаются не более чем в одном слове:");
        if (rareVowels.Count == 0)
        {
            Console.WriteLine("— Таких нет.");
            return;
        }

        foreach (char ch in rareVowels)
        {
            Console.WriteLine("- " + ch);
        }
    }

    public static void task10()
    {
        string filePath = "task10.txt";
        List<Participant> participants = new List<Participant>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    Console.WriteLine("Файл пустой.");
                    return;
                }

                int n = int.Parse(line);

                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();

                    if (line == null)
                    {
                        Console.WriteLine("В файле меньше строк, чем указано.");
                        return;
                    }

                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 4)
                    {
                        Console.WriteLine("Ошибка в строке: " + line);
                        return;
                    }

                    string lastName = parts[0];
                    string firstName = parts[1];
                    int grade = int.Parse(parts[2]);
                    int score = int.Parse(parts[3]);

                    Participant p = new Participant(lastName, firstName, grade, score);
                    participants.Add(p);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
            return;
        }

        findWinners(participants);
    }

    private static void findWinners(List<Participant> participants)
    {
        int maxScore = -1;

        foreach (Participant p in participants)
        {
            if (p.Score > maxScore)
            {
                maxScore = p.Score;
            }
        }

        List<Participant> topScorers = new List<Participant>();

        foreach (Participant p in participants)
        {
            if (p.Score == maxScore && p.Score > 200)
            {
                topScorers.Add(p);
            }
        }

        int maxWinnersAllowed = participants.Count / 5;

        if (topScorers.Count > 0 && topScorers.Count <= maxWinnersAllowed)
        {
            // Победители найдены. Ищем лучших из оставшихся.
            int secondMax = -1;

            foreach (Participant p in participants)
            {
                if (p.Score < maxScore && p.Score > secondMax)
                {
                    secondMax = p.Score;
                }
            }

            List<Participant> secondBest = new List<Participant>();

            foreach (Participant p in participants)
            {
                if (p.Score == secondMax)
                {
                    secondBest.Add(p);
                }
            }

            printResult(secondBest);
        }
        else
        {
            // Победителей нет, ищем лучших.
            int bestScore = -1;

            foreach (Participant p in participants)
            {
                if (p.Score > bestScore)
                {
                    bestScore = p.Score;
                }
            }

            List<Participant> bestParticipants = new List<Participant>();

            foreach (Participant p in participants)
            {
                if (p.Score == bestScore)
                {
                    bestParticipants.Add(p);
                }
            }

            printResult(bestParticipants);
        }
    }

    private static void printResult(List<Participant> list)
    {
        if (list.Count == 1)
        {
            Console.WriteLine(list[0].LastName + " " + list[0].FirstName);
        }
        else
        {
            Console.WriteLine(list.Count);
        }
    }
}







