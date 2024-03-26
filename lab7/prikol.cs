using System;

class CDictionary
{
    public int Index { get; }
    public int Product { get; }

    public CDictionary(int index, int product)
    {
        Index = index;
        Product = product;
    }
}

class Program
{
    static void DictionarySwap(ref CDictionary a, ref CDictionary b)
    {
        var temp = a;
        a = b;
        b = temp;
    }

    static void Output(int[,] arr)
    {
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

static void Input(int[,] arr)
{
    int rows = arr.GetLength(0);
    int cols = arr.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        string input = Console.ReadLine();
        string[] elements = input.Split(',');
        for (int j = 0; j < cols; j++) 
        {
            arr[i, j] = int.Parse(elements[j]);
        }
    }
}

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void DictionarySelectionSort(CDictionary[] dictionary, int cols)
    {
        for (int i = cols - 1; i > 0; i--)
        {
            int smallestIndex = i;
            for (int j = i - 1; j >= 0; j--)
            {
                if (dictionary[smallestIndex].Product > dictionary[j].Product)
                {
                    smallestIndex = j;
                }
            }
            DictionarySwap(ref dictionary[smallestIndex], ref dictionary[i]);
        }
    }

    static void SortByProductOfNums()
    {
        Console.WriteLine("Enter the number of rows and columns:");
        string[] dimensions = Console.ReadLine().Split();
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        int[,] arr = new int[rows, cols];
        int[,] solution = new int[rows, cols];

        Console.WriteLine("Enter the elements of the matrix:");
        Input(arr);

        CDictionary[] dictionary = new CDictionary[cols];

        for (int i = 0; i < cols; i++)
        {
            int product = 1;
            for (int j = 0; j < rows; j++)
            {
                product *= arr[j, i];
            }
            dictionary[i] = new CDictionary(i, product);
        }

        DictionarySelectionSort(dictionary, cols);

        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                solution[j, i] = arr[j, dictionary[i].Index];
            }
        }

        Console.WriteLine("Solution:");
        Output(solution);
    }

    static void Main()
    {
        SortByProductOfNums();
    }
}
