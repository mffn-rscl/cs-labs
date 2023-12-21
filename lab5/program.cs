using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Random random = new Random();

        int choice;

        do
        {
            Console.WriteLine("Pick a task from the list below:\n");
            Console.WriteLine("To squares with two max values from list (1).");
            Console.WriteLine("Table (2).");
            Console.WriteLine("Game: 'Guess a Number!' (3).");
            Console.WriteLine("Searching elements in list 1 (4).");
            Console.WriteLine("Plurals operations (5).");
            Console.WriteLine("\nPick a task number from list: ");
            
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Incorrect input. Try again.");
                continue;
            }

            switch (choice)
            {
                case 0:
                    Console.WriteLine("Ending process..");
                    break;

                case 1:
                    Console.WriteLine("You chose 'To squares with two max values from list'.\n");
                    ToSquaresWithTwoMax();
                    break;

                case 2:
                    Console.WriteLine("You chose task 'Table'.\n");
                    Table();
                    break;

                case 3:
                    Console.WriteLine("You chose game 'Guess a Number!'\n");
                    Console.Write("Input range from a to b: ");
                    long a, b;
                    if (!long.TryParse(Console.ReadLine(), out a) || !long.TryParse(Console.ReadLine(), out b))
                    {
                        Console.WriteLine("Incorrect input. Try again.");
                        continue;
                    }
                    GuessedNumber(a, b);
                    break;

                case 4:
                    Console.WriteLine("You chose 'Searching elements in list 1.'\n");
                    SearchingElementsInArray1();
                    break;

                case 5:
                    Console.WriteLine("You chose 'Plurals operations'.\n");
                    Plurals();
                    break;

                default:
                    Console.WriteLine("Incorrect input. Try again.");
                    break;
            }
        } while (choice != 0);
    }

    static void ToSquaresWithTwoMax()
    {
        Console.Write("Enter the length of array: ");
        if (!int.TryParse(Console.ReadLine(), out int size) || size <= 0)
        {
            Console.WriteLine("Incorrect input. Try again.");
            return;
        }

        int[] array = new int[size];

        Console.Write("Do you want to fill array by random or fill it by yourself? ('r' - random, 'y' - by yourself): ");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (choice)
        {
            case 'r':
                Console.WriteLine("You chose to fill array by random.\n");
                Console.Write("Finished array: ");
                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next();
                    Console.Write(array[i] + " ");
                }
                break;

            case 'y':
                Console.WriteLine("You chose to fill array by yourself.\n");
                Console.Write("Fill the array in one line? (y/n): ");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == 'y')
                {
                    InputInOneLine(size, array);
                }
                else
                {
                    InputSeparately(size, array);
                }

                Console.Write("Finished array: ");
                for (int i = 0; i < size; i++)
                {
                    Console.Write(array[i] + " ");
                }
                break;

            default:
                Console.WriteLine("\nIncorrect input. Try again.");
                return;
        }

        Console.WriteLine("\nReplacing all positive numbers into their squares.. ");
        Console.Write("Result: ");
        for (int i = 0; i < size; i++)
        {
            if (array[i] > 0)
            {
                array[i] = array[i] * array[i];
            }

            Console.Write(array[i] + " ");
        }

        FindTheMaxValFromArray(size, array);
    }

    static void InputInOneLine(int size, int[] array)
    {
        Console.WriteLine($"Enter {size} values separated by space:");
        string[] values = Console.ReadLine().Split(' ');

        for (int i = 0; i < size; i++)
        {
            if (!int.TryParse(values[i], out array[i]))
            {
                Console.WriteLine("Incorrect input. Try again.");
                InputInOneLine(size, array);
                return;
            }
        }
    }

    static void InputSeparately(int size, int[] array)
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Enter the {i + 1} value of array: ");
            if (!int.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Incorrect input. Try again.");
                InputSeparately(size, array);
                return;
            }
        }
    }

    static void FindTheMaxValFromArray(int size, int[] array)
    {
        int max1 = array[0], max2 = array[1], temp;
        if (max1 < max2) { Swap(ref max1, ref max2); }

        for (int i = 2; i < size; i++)
        {
            if (array[i] > max1)
            {
                max2 = max1;
                max1 = array[i];
            }
            else if (array[i] > max2) { max2 = array[i]; }
        }

        Console.WriteLine($"\nFound two max values: {max1} and {max2}.\n");
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void Table()
    {
        Console.Write("Enter the size of array: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Incorrect input. Try again.");
            return;
        }

        List<int> arr = new List<int>(n);
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter the {i + 1} element of array: ");
            if (!int.TryParse(Console.ReadLine(), out int element))
            {
                Console.WriteLine("Incorrect input. Try again.");
                Table();
                return;
            }
            arr.Add(element);
        }

        Console.Write("Enter the value of k: ");
        if (!int.TryParse(Console.ReadLine(), out int k) || k <= 0 || k > n)
        {
            Console.WriteLine("Incorrect input. Try again.");
            return;
        }

        List<int> sortedArr = new List<int>(arr);
        // Implement the task without using sort
        sortedArr.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < n; i++)
        {
            if (sortedArr[k - 1] == arr[i])
            {
                Console.WriteLine(i + 1);
            }
        }
    }

    static void GuessedNumber(long a, long b)
    {
        long low = a, high = b, mid, answer = 0;
        string result;

        for (int i = 0; i < 50; i++)
        {
            mid = (low + high) / 2;
            Console.WriteLine($"try {mid}");
            Console.WriteLine();
            result = Console.ReadLine();

            if (result == "=")
            {
                Console.WriteLine($"answer {mid}");
                return;
            }
            else if (result == "+")
            {
                low = mid + 1;
            }
            else if (result == "-")
            {
                high = mid - 1;
                answer = mid;
            }
        }

        Console.WriteLine($"answer {answer}");
    }

    static void SearchingElementsInArray1()
    {
        Console.Write("Enter the size of array N: ");
        if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
        {
            Console.WriteLine("Incorrect input. Try again.");
            return;
        }

        List<int> arr1 = new List<int>(N);
        for (int i = 0; i < N; ++i)
        {
            Console.Write($"Enter the {i + 1} element of array arr1: ");
            if (!int.TryParse(Console.ReadLine(), out int element))
            {
                Console.WriteLine("Incorrect input. Try again.");
                SearchingElementsInArray1();
                return;
            }
            arr1.Add(element);
        }

        Console.Write("Enter the size of array M: ");
        if (!int.TryParse(Console.ReadLine(), out int M) || M <= 0)
        {
            Console.WriteLine("Incorrect input. Try again.");
            return;
        }

        List<int> arr2 = new List<int>(M);
        for (int i = 0; i < M; ++i)
        {
            Console.Write($"Enter the {i + 1} element of array arr2: ");
            if (!int.TryParse(Console.ReadLine(), out int element))
            {
                Console.WriteLine("Incorrect input. Try again.");
                SearchingElementsInArray1();
                return;
            }
            arr2.Add(element);
        }

        List<int> sortedArr1 = new List<int>(arr1);
        ChoiceSort(N, ref sortedArr1);

        Dictionary<int, int> indexMap = new Dictionary<int, int>();
        for (int i = 0; i < N; ++i)
        {
            indexMap[sortedArr1[i]] = i + 1;
        }

        for (int i = 0; i < M; ++i)
        {
            Console.Write($"{indexMap[arr2[i]]} ");
        }
    }

    static void Plurals()
    {
        Console.WriteLine("Enter the operation (UNION, INTERSECTION, DIFFERENCE): ");
        string operation = Console.ReadLine().ToUpper();

        Console.WriteLine("Enter the size of array A: ");
        if (!int.TryParse(Console.ReadLine(), out int size1) || size1 <= 0)
        {
            Console.WriteLine("Incorrect input. Try again.");
            return;
        }

        List<int> A = new List<int>(size1);
        for (int i = 0; i < size1; i++)
        {
            Console.Write($"Enter the {i + 1} element of array A: ");
            if (!int.TryParse(Console.ReadLine(), out int element))
            {
                Console.WriteLine("Incorrect input. Try again.");
                Plurals();
                return;
            }
            A.Add(element);
        }

        Console.WriteLine("Enter the size of array B: ");
        if (!int.TryParse(Console.ReadLine(), out int size2) || size2 <= 0)
        {
            Console.WriteLine("Incorrect input. Try again.");
            return;
        }

        List<int> B = new List<int>(size2);
        for (int i = 0; i < size2; i++)
        {
            Console.Write($"Enter the {i + 1} element of array B: ");
            if (!int.TryParse(Console.ReadLine(), out int element))
            {
                Console.WriteLine("Incorrect input. Try again.");
                Plurals();
                return;
            }
            B.Add(element);
        }

        if (operation == "UNION")
        {
            List<int> solution = A.Union(B).ToList();
            Console.Write("Result: ");
            foreach (int i in solution) { Console.Write($"{i} "); }
        }
        else if (operation == "INTERSECTION")
        {
            List<int> solution = A.Intersect(B).ToList();
            Console.Write("Result: ");
            foreach (int i in solution) { Console.Write($"{i} "); }
        }
        else if (operation == "DIFFERENCE")
        {
            List<int> solution = A.Except(B).ToList();
            Console.Write("Result: ");
            foreach (int i in solution) { Console.Write($"{i} "); }
        }
        else
        {
            Console.WriteLine("Invalid operation. Try again.");
        }
    }

    static void ChoiceSort(int size, ref List<int> array)
    {
        for (int i = 0; i < size - 1; i++)
        {
            int smallestIndex = i;

            for (int j = i + 1; j < size; j++)
            {
                if (array[j] < array[smallestIndex])
                {
                    smallestIndex = j;
                }
            }

            int temp = array[i];
            array[i] = array[smallestIndex];
            array[smallestIndex] = temp;
        }
    }
}
