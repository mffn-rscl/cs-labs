using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Среди задач ниже:");
        Console.WriteLine("1. Лабораторная работа (вариант 12).");
        Console.WriteLine("2. Дополнительная задача №18.");
        Console.WriteLine("3. Дополнительная задача №19.");
        Console.WriteLine("4. Дополнительная задача №20.");
        Console.WriteLine("Выберите номер задачи, которую вы хотите выполнить, нажмите 0 для выхода:");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.WriteLine("\nМагазин, который продает только целые отдельные товары, провел распродажу, по правилам которой покупатели имеют право по своему усмотрению группировать любые выбранные ими товары по группам по 5 товаров и платить только за 4 дорогих из них, а 5-й (самый дешевый в группе) получать бесплатно.\n");
                Solution();
                break;
            case 2:
                Console.WriteLine("\nЕсть два набора положительных целых чисел. Один представляет ширину тех промежутков, которые очень желательно перекрыть мостами. Какое максимальное количество промежутков удастся перекрыть мостами?\n");
                ExtraTaskOne();
                break;
            case 3:
                Console.WriteLine("\nДан набор из n (n≥4) действительных положительных чисел, представляющих длины отрезков. Из этих отрезков следует выбрать три различных, чтобы сформировать из них треугольник. Какие отрезки следует выбрать, чтобы полученный треугольник имел максимально возможную площадь (Программа должна вывести длины выбранных трех отрезков и вычисленную на их основе площадь).\n");
                ExtraTaskTwo();
                break;
            case 4:
                Console.WriteLine("\nДан набор из n (n≥4) действительных положительных чисел, представляющих длины отрезков.");
                Console.WriteLine("Сколько существует различных способов выбрать три различных из них так, чтобы из них можно было сформировать невырожденный треугольник?\n");
                ExtraTaskThree();
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Некорректный ввод, пожалуйста, попробуйте еще раз.");
                break;
        }
    }

    static void Input(int[] arr, int size)
    {
        for (int i = 0; i < size; i++)
            arr[i] = Convert.ToInt32(Console.ReadLine());
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void ShellSort(int[] data, int size)
    {
        for (int interval = size / 2; interval > 0; interval /= 2)
        {
            for (int i = interval; i < size; i += 1)
            {
                int temp = data[i];
                int j;
                for (j = i; j >= interval && data[j - interval] > temp; j -= interval)
                {
                    data[j] = data[j - interval];
                }
                data[j] = temp;
            }
        }
    }

    static void ExtraTaskOne()
    {
        int size, counter = 0;

        Console.WriteLine("Введите длину двух массивов:");
        size = Convert.ToInt32(Console.ReadLine());
        int[] holes = new int[size];
        int[] bridges = new int[size];
        Console.WriteLine("Введите промежутки:");
        Input(holes, size);
        Console.WriteLine("Введите мосты:");
        Input(bridges, size);

        for (int i = size - 1; i >= 0; i--)
        {
            for (int j = size - 1; j >= 0; j--)
            {
                if (bridges[j] > holes[i])
                {
                    counter++;
                }
            }
        }
        Console.WriteLine("Максимальное количество перекрытых промежутков: " + counter);
    }

    static void ExtraTaskTwo()
    {
        int n;
        Console.WriteLine("Введите количество сегментов:");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите сегменты:");
        double[] arr = new double[n];
        Input(arr, n);
        ShellSort(arr, n);

        for (int i = n - 1; i >= 2; i--)
        {
            if (arr[i] < arr[i - 1] + arr[i - 2])
            {
                double p = (arr[i] + arr[i - 1] + arr[i - 2]) / 2;
                Console.WriteLine("Стороны треугольника: " + arr[i] + " " + arr[i - 1] + " " + arr[i - 2]);
                Console.WriteLine("Площадь: " + Math.Sqrt(p * (p - arr[i]) * (p - arr[i - 1]) * (p - arr[i - 2])));
                return;
            }
        }
        Console.WriteLine("\nНеопределено.");
    }

    static void ExtraTaskThree()
    {
        int n;
        Console.WriteLine("Введите количество сегментов:");
        n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите сегменты:");
        double[] arr = new double[n];
        Input(arr, n);
        ShellSort(arr, n);

        int counter = 0;
        for (int i = n - 1; i >= 2; i--)
        {
            for (int j = i - 1; j >= 1; j--)
            {
                for (int k = j - 1; k >= 0; k--)
                {
                    if (arr[i] - arr[j] - arr[k] < 0)
                    {
                        counter++;
                    }
                }
            }
        }
        Console.WriteLine("\nКоличество невырожденных треугольников: " + counter);
    }

    static void Solution()
    {
        int size;
        Console.WriteLine("Введите количество магазинов:");
        size = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[size];
        Console.WriteLine("Введите цену каждого товара:");
        Input(arr, size);

        int sum = 0;
        ShellSort(arr, size);
        for (int count = size / 5; count < size; count++) sum += arr[count];
        Console.WriteLine(sum);
    }
}
