using System;

class Program
{
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static int RandNums()
    {
        Random rand = new Random();
        int randNum = (rand.Next(0, 100) % 100) - ((rand.Next(0, 10) % 10) * 5);
        return randNum;
    }

    static void InitRandomSeed()
    {
        Random rand = new Random();
    }

    static void FindTheMaxValFromArray(int[] array)
    {
        int max1 = array[0];
        int max2 = array[1];

        if (max1 < max2)
        {
            Swap(ref max1, ref max2);
        }

        for (int i = 2; i < array.Length; i++)
        {
            if (array[i] > max1)
            {
                max2 = max1;
                max1 = array[i];
            }
            else if (array[i] > max2)
            {
                max2 = array[i];
            }
        }

        Console.WriteLine($"\nFound two max values: {max1} and {max2}.\n");
    }

    static void InputInOneLine(int[] array)
    {
        string[] input = Console.ReadLine().Split(' ');

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(input[i]);
        }
    }

    static void InputSeparately(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"Enter the {i + 1} value of array: ");
            array[i] = int.Parse(Console.ReadLine());
        }
    }

    static void ToSquaresWithTwoMax()
    {
        Console.Write("Enter the length of array: ");
        int size = int.Parse(Console.ReadLine());
        int[] array = new int[size];

        Console.Write("Do you want to fill array by random or fill it by yourself? ('r' - random, 'y' - by yourself): ");
        char choice = Console.ReadKey().KeyChar;

        switch (choice)
        {
            case 'r':
                Console.WriteLine("\nYou chose to fill array by random.");
                Console.Write("Finished array: ");

                for (int i = 0; i < size; i++)
                {
                    array[i] = RandNums();
                    Console.Write($"{array[i]} ");
                }

                break;

            case 'y':
                Console.WriteLine("\nYou chose to fill array by yourself.");
                Console.Write("Fill the array in one line? (y/n): ");

                choice = Console.ReadKey().KeyChar;

                if (choice == 'y')
                {
                    Console.WriteLine();
                    InputInOneLine(array);
                }
                else
                {
                    Console.WriteLine();
                    InputSeparately(array);
                }

                Console.Write("Finished array: ");

                foreach (int num in array)
                {
                    Console.Write($"{num} ");
                }

                break;

            default:
                Console.Error.WriteLine("\nIncorrect input. Try again.");
                Environment.Exit(0);
                break;
        }

        Console.WriteLine("\nReplacing all positive numbers into their squares.. ");
        Console.Write("Result: ");

        for (int i = 0; i < size; i++)
        {
            if (array[i] > 0)
            {
                array[i] = array[i] * array[i];
            }

            Console.Write($"{array[i]} ");
        }

        FindTheMaxValFromArray(array);
    }

    static void Main()
    {
        InitRandomSeed();
        Console.WriteLine("Need to change all positive numbers to their squares, then find two max numbers.");
        ToSquaresWithTwoMax();
    }
}
