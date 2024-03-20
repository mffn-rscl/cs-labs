using System;

class Program
{
    static void Main(string[] args)
    {
        int choice;
        Console.WriteLine("Choose one of the tasks(1,2,3,4), or press 0 to leave:");
        int.TryParse(Console.ReadLine(), out choice);

        switch (choice)
        {
            case 1:
                Console.WriteLine("You chose #1: Find the number of elements divisible by five for each row of an integer matrix and the largest of these results.");
                MultiplesOfFive();
                break;
            case 2:
                Console.WriteLine("You chose #2: Find the first maximum and minimum elements in each row and place them in the first and last positions of the row.");
                MaxAndMinOfEachRow();
                break;
            case 3:
                Console.WriteLine("You chose #3: Sort all columns with even indices in non-decreasing order, and all columns with odd indices in non-increasing order.");
                SortedCols();
                break;
            case 4:
                Console.WriteLine("You chose #4: Sort the columns of the matrix in non-decreasing order of the products of the elements in those columns.");
                SortByProductOfNumbers();
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Invalid input, try again.");
                break;
        }
    }

    static void MultiplesOfFive()
    {
        Console.WriteLine("Enter the number of rows and columns:");
        int rows, cols;
        if (!int.TryParse(Console.ReadLine(), out rows) || !int.TryParse(Console.ReadLine(), out cols))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        int countOfElements = 0;
        int maxValue = int.MinValue;
        for (int i = 0; i < rows; i++)
        {
            string[] rowInput = Console.ReadLine().Split();
            foreach (string input in rowInput)
            {
                int temp;
                if (int.TryParse(input, out temp))
                {
                    if (temp % 5 == 0 && temp != 0)
                    {
                        if (maxValue < temp)
                            maxValue = temp;
                        countOfElements++;
                    }
                }
            }
            Console.WriteLine($"Elements multiples of five in row {i + 1} is: {countOfElements}");
            countOfElements = 0;
        }
        Console.WriteLine($"The max element multiple of five is {maxValue}.");
    }

    static void MaxAndMinOfEachRow()
    {
        Console.WriteLine("Enter the number of rows and columns:");
        int rows, cols;
        if (!int.TryParse(Console.ReadLine(), out rows) || !int.TryParse(Console.ReadLine(), out cols))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        int[][] arr = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            string[] rowInput = Console.ReadLine().Split();
            arr[i] = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                if (int.TryParse(rowInput[j], out arr[i][j]))
                    continue;
                else
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }
            }

            int minIndex = 0, maxIndex = 0;
            int minValue = int.MaxValue, maxValue = int.MinValue;
            for (int j = 0; j < cols; j++)
            {
                if (arr[i][j] > maxValue)
                {
                    maxValue = arr[i][j];
                    maxIndex = j;
                }
                if (arr[i][j] < minValue)
                {
                    minValue = arr[i][j];
                    minIndex = j;
                }
            }
            if (arr[i][cols - 1] == maxValue && arr[i][0] == minValue)
            {
                Swap(ref arr[i][cols - 1], ref arr[i][0]);
            }
            else
            {
                Swap(ref arr[i][0], ref arr[i][maxIndex]);
                Swap(ref arr[i][cols - 1], ref arr[i][minIndex]);
            }
        }
        Console.WriteLine("Swapped array:");
        Output(arr);
    }

    static void SortedCols()
    {
        Console.WriteLine("Enter the number of rows and columns:");
        int rows, cols;
        if (!int.TryParse(Console.ReadLine(), out rows) || !int.TryParse(Console.ReadLine(), out cols))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        int[][] arr = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            string[] rowInput = Console.ReadLine().Split();
            arr[i] = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                if (int.TryParse(rowInput[j], out arr[i][j]))
                    continue;
                else
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }
            }
        }

        for (int i = 0; i < cols; i++)
        {
            if ((i + 1) % 2 != 0)
                ModifiedBubbleSort(arr, i);
            else
                ReversedSelectionSort(arr, i);
        }

        Console.WriteLine("\nResult:");
        Output(arr);
    }

    static void SortByProductOfNumbers()
    {
        Console.WriteLine("Enter the number of rows and columns:");
        int rows, cols;
        if (!int.TryParse(Console.ReadLine(), out rows) || !int.TryParse(Console.ReadLine(), out cols))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        int[][] arr = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            string[] rowInput = Console.ReadLine().Split();
            arr[i] = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                if (int.TryParse(rowInput[j], out arr[i][j]))
                    continue;
                else
                {
                    Console.WriteLine("Invalid input.");
                    return;
                }
            }
        }

        int[] solution = new int[cols];
        for (int i = 0; i < cols; i++)
        {
            int product = 1;
            for (int j = 0; j < rows; j++)
                product *= arr[j][i];
            Console.WriteLine($"Product of {i + 1} column is {product}");
            solution[i] = product;
        }
        Array.Sort(solution);

        Console.Write("Sorted array of product of numbers: ");
        foreach (int item in solution)
            Console.Write($"{item} ");
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void ModifiedBubbleSort(int[][] arr, int columnIndex)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j][columnIndex] > arr[j + 1][columnIndex])
                {
                    Swap(refarr[j][columnIndex], ref arr[j + 1][columnIndex]);
                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }
    }

    static void ReversedSelectionSort(int[][] arr, int columnIndex)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int smallestIndex = i;
            for (int j = i - 1; j >= 0; j--)
            {
                if (arr[smallestIndex][columnIndex] > arr[j][columnIndex])
                    smallestIndex = j;
            }
            Swap(ref arr[smallestIndex][columnIndex], ref arr[i][columnIndex]);
        }
    }

    static void Output(int[][] arr)
    {
        foreach (int[] row in arr)
        {
            foreach (int num in row)
                Console.Write($"{num} ");
            Console.WriteLine();
        }
    }
}

