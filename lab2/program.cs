using System;
using System.Collections.Generic;
class Program
{
    static int cycles;

    static void DoBlockOne(int n)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int number;
        int maxNum = int.MinValue;
        int minNum = int.MaxValue;
        int i = 0;
        Console.Write("Виберіть один із циклів, який ви хочете використати в програмі(for - 1, while - 2, do while - 3): ");
        cycles = int.Parse(Console.ReadLine());

        switch (cycles)
        {
            case 1:
                for (i = 1; i <= n; i++)
                {
                    Console.Write("Введіть " + i + " число: ");
                    number = int.Parse(Console.ReadLine());

                    if (number > maxNum)
                    {
                        maxNum = number;
                    }
                    if (number < minNum)
                    {
                        minNum = number;
                    }
                }
                break;
            case 2:
                while (i < n)
                {
                    i++;
                    Console.Write("Введіть " + i + " число: ");
                    number = int.Parse(Console.ReadLine());

                    if (number > maxNum)
                    {
                        maxNum = number;
                    }
                    if (number < minNum)
                    {
                        minNum = number;
                    }
                }
                break;
            case 3:
                do
                {
                    i++;
                    Console.Write("Введіть " + i + " число: ");
                    number = int.Parse(Console.ReadLine());

                    if (number > maxNum)
                    {
                        maxNum = number;
                    }
                    if (number < minNum)
                    {
                        minNum = number;
                    }
                } while (i < n);
                break;
            default:
                Console.WriteLine("команда не розпізнана, Зробіть, будь ласка, вибір із 1,2,3.");
                break;
        }

        int difference = maxNum - minNum;
        Console.WriteLine("Різниця максимального і мінімального чисел дорівнює: " + difference);
    }

    static void DoBlockTwo()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int number = 1;
        int i = 1;
        int posCounter = 0;
        int negCounter = 0;
        Console.WriteLine("\nпрограма буде працювати, допоки ви не введете 0.");
        Console.Write("Виберіть один із циклів, який ви хочете використати в програмі(for - 1, while - 2, do while - 3): ");
        cycles = int.Parse(Console.ReadLine());

        switch (cycles)
        {
            case 1:
                for (i = 1; i < 100; i++)
                {
                    Console.Write("Введіть " + i + " число: ");
                    number = int.Parse(Console.ReadLine());

                    if (number == 0)
                    {
                        i = 100;
                    }
                    if (number > 0)
                    {
                        posCounter++;
                    }
                    else if (number < 0)
                    {
                        negCounter++;
                    }
                }
                break;
            case 2:
                while (number != 0)
                {
                    Console.Write("Введіть " + i + " число: ");
                    number = int.Parse(Console.ReadLine());

                    if (number > 0)
                    {
                        posCounter++;
                    }
                    else if (number < 0)
                    {
                        negCounter++;
                    }
                    i++;
                }
                break;
            case 3:
                do
                {
                    Console.Write("Введіть " + i + " число: ");
                    number = int.Parse(Console.ReadLine());

                    if (number > 0)
                    {
                        posCounter++;
                    }
                    else if (number < 0)
                    {
                        negCounter++;
                    }
                    i++;
                } while (number != 0);
                break;
            default:
                Console.WriteLine("команда не розпізнана, Зробіть, будь ласка, вибір із 1,2,3.");
                break;
        }

        if (negCounter > posCounter)
        {
            Console.WriteLine("від'ємних чисел більше, ніж додатніх.\n");
        }
        else if (negCounter < posCounter)
        {
            Console.WriteLine("додатніх чисел більше, ніж від'ємних.\n");
        }
        else
        {
            Console.WriteLine("кількість додатних та від'ємних чисел рівна.\n");
        }
    }

    static void DoBlockThree(int x, int n)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        double S = 0;

        Console.Write("\nВиберіть один із циклів, який ви хочете використати в програмі(for - 1, while - 2, do while - 3): ");
        cycles = int.Parse(Console.ReadLine());

        switch (cycles)
        {
            case 1:
                if (n % 2 == 0)
                {
                    S = (n - 1) * x + Math.Pow(-1, 1 + ((n + 2) % 3 / 2)) * Math.Cos(n * x);
                }
                else
                {
                    S = (n - 1) * x + Math.Pow(-1, 1 + ((n + 2) % 3 / 2)) * Math.Sin(x * n);
                }
                n--;
                if (n >= 1)
                {
                    for (int i = n - 1; i >= 1; i--)
                    {
                        S = i * x + Math.Sin(S);

                        if (i % 2 == 0)
                        {
                            S = i * x + Math.Pow(-1, 1 + ((i + 1) % 3 / 2)) * Math.Cos(n * x);
                        }
                        else
                        {
                            S = i * x + Math.Pow(-1, 1 + ((i + 1) % 3 / 2)) * Math.Sin(x * i);
                        }
                    }
                    Console.WriteLine(Math.Sin(S) + "\n\n");
                }
                else
                {
                    Console.WriteLine(Math.Sin(S) + "\n\n");
                }
                break;
            case 2:
                if (n >= 1)
                {
                    while (n > 1)
                    {
                        if (n % 2 == 0)
                        {
                            S = (n - 1) * x + Math.Pow(-1, 1 + ((n + 2) % 3 / 2)) * Math.Cos(n * x);
                        }
                        else
                        {
                            S = (n - 1) * x + Math.Pow(-1, 1 + ((n + 2) % 3 / 2)) * Math.Sin(x * n);
                        }
                        S = (n - 1) * x + Math.Sin(S);
                        n--;
                    }
                    Console.WriteLine(Math.Sin(S) + "\n\n");
                }
                else
                {
                    Console.WriteLine(Math.Sin(S) + "\n\n");
                }
                break;
            case 3:
                if (n >= 1)
                {
                    do
                    {
                        if (n % 2 == 0)
                        {
                            S = (n - 1) * x + Math.Pow(-1, 1 + ((n + 2) % 3 / 2)) * Math.Cos(n * x);
                        }
                        else
                        {
                            S = (n - 1) * x + Math.Pow(-1, 1 + ((n + 2) % 3 / 2)) * Math.Sin(x * n);
                        }
                        S = (n - 1) * x + Math.Sin(S);
                        n--;
                    } while (n > 1);
                    Console.WriteLine(Math.Sin(S) + "\n\n");
                }
                else
                {
                    Console.WriteLine(Math.Sin(S) + "\n\n");
                }
                break;
            default:
                Console.WriteLine("команда не розпізнана, Зробіть, будь ласка, вибір із 1,2,3.");
                break;
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int choice, n;
        do
        {
            Console.WriteLine("Для виконання блоку 1 (варіант 11) введіть 1");
            Console.WriteLine("Для виконання блоку 2 (варіант 34) введіть 2");
            Console.WriteLine("Для виконання блоку 3 (варіант 63) введіть 3");
            Console.WriteLine("Для виходу з програми введіть 0\n");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Виконую блок 1(11 задача)");
                    Console.WriteLine("В першому блоці дана пословність n чисел. Програма знаходить різницю максимального та мінімального чисел.");
                    Console.Write("Введіть значення n: ");
                    n = int.Parse(Console.ReadLine());
                    DoBlockOne(n);
                    break;
                case 2:
                    Console.WriteLine("Виконую блок 2(34 задача)");
                    DoBlockTwo();
                    break;
                case 3:
                    Console.WriteLine("Ви обрали блок 3(63 задача).");
                    Console.WriteLine(" умова до задачі:\n S = sin(x + cos(2x −sin(3x + cos(4x + sin(5x − cos(6x +...)...) (до sin(nx) чи cos(nx)включно, sin(nx) чи cos(nx) залежить від парності n; на кожні три рази двічі відбувається додавання, один раз віднімання).");
                    Console.Write("\nВведіть значення n та х відповідно: ");
                    int x;
                    n = int.Parse(Console.ReadLine());
                    x = int.Parse(Console.ReadLine());
                    DoBlockThree(x, n);
                    break;
                default:
                    Console.WriteLine("команда не розпізнана, Зробіть, будь ласка, вибір із 0,1,2,3.");
                    break;
            }
        } while (choice != 0);
    }
}