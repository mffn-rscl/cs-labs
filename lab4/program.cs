using System;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections.Generic;


namespace Task
{
    class Task
    {
        static void DoBlock1()
        {
            static void AnalyzeMethod(Action<int> method, int n)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                long startMemory = GC.GetTotalMemory(true);

                Stopwatch stopwatch = Stopwatch.StartNew();

                method(n);

                stopwatch.Stop();

                long endMemory1 = GC.GetTotalMemory(false);
                long memoryUsage1 = endMemory1 - startMemory;

                long endMemory2 = GC.GetTotalMemory(true);
                long memoryUsage2 = endMemory2 - startMemory;

                Console.WriteLine($"Кількість використаної пам'яті: {memoryUsage1} {memoryUsage2} байт");
                Console.WriteLine($"Час роботи програми: {stopwatch.Elapsed}");
            }


            static void FirstVersion(int n)
            {
                string result = "";

                for(int i = 1; i <= n; i++)
                {
                    result += i + " "; 
                }
                result = result.TrimEnd();
                Console.WriteLine(result);
            }
            static void SecondVersion(int n)
            {
                string result = "";

                for (int i = n; i >= 1; i--)
                {
                    result = i + " " + result;
                }
                Console.WriteLine(result);
            }
            static void ThirdVersion(int n)
            {
                StringBuilder result = new StringBuilder(n);

                for (int i = 1; i <= n; i++)
                {
                    result.Append(i+" ");
                }
                Console.WriteLine(result.Remove(result.Length-1, 1));
            }                     

            static void FourthVersion(int n)
            {
                StringBuilder result = new StringBuilder(n);

                for (int i = n; i >= 1; i--)
                {
                    result.Insert(0, i+" ");
                }
                Console.WriteLine(result.Remove(result.Length - 1, 1));
            }


            Console.WriteLine("Введіть число: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Оберіть бажану реалізацію програми:\n1 - Перша\n2 - Друга\n3 - Третя\n4 - Четверта");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Реалізація 1:");
                    AnalyzeMethod(FirstVersion,n );
                    break;

                case "2":
                    Console.WriteLine("Реалізація 2:");
                    AnalyzeMethod(SecondVersion, n);
                    break;

                case "3":
                    Console.WriteLine("Реалізація 3");
                    AnalyzeMethod(ThirdVersion, n);
                    break;

                case "4":
                    Console.WriteLine("Реалізація 4");
                    AnalyzeMethod(FourthVersion, n);
                    break;

                default:
                    Console.WriteLine("Команда не розпізнана");
                    break;
            }
        }

        static string TransformString()
        {
            Console.WriteLine("Введіть рядок: ");
            string input = Console.ReadLine();
            var characters = input.Where(char.IsDigit).Concat(input.Where(char.IsLetter)).ToArray();

            var digits = new string(characters.Where(char.IsDigit).ToArray());

            var letters = new string(characters.Where(char.IsLetter).Reverse().ToArray());

            string result = digits + letters;

            return result;
        }

        static void DoBonusTask()
        {
            static void Task15()
            {
                Console.WriteLine("Введіть перший рядок: ");
                string line1 = Console.ReadLine();
                Console.WriteLine("Введіть другий рядок: ");
                string line2 = Console.ReadLine();

                bool writeYes = Compare_Strings(line1, line2);

                if (writeYes)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }

                static bool Compare_Strings(string s1, string s2)
                {
                    int index1 = 0;
                    int index2 = 0;

                    while (index1 < s1.Length && index2 < s2.Length)
                    {

                        index1 = Ignore_Spaces(s1, index1);
                        index2 = Ignore_Spaces(s2, index2);

                        if (index1 < s1.Length && index2 < s2.Length && s1[index1] != s2[index2]) {  return false; }

                        index1++;
                        index2++;
                    }
                    index1 = Ignore_Spaces(s1, index1);
                    index2 = Ignore_Spaces(s2, index2);

                    return index1 == s1.Length && index2 == s2.Length;
                }

                static int Ignore_Spaces(string s, int index)
                {
                    while (index < s.Length && s[index] == ' ')
                    {
                        index++;
                    }
                    return index;
                }
            }
            static void Task16()
            {
                string firstSen = Console.ReadLine().ToLower();
                string secondSen = Console.ReadLine().ToLower();

                bool anagrama = true;

                for (int i = 0; i < firstSen.Length; i++)
                {
                    if (95 <= firstSen[i] && firstSen[i] <= 120)
                    {
                        if (firstSen.Split(firstSen[i]).Length - 1 != secondSen.Split(firstSen[i]).Length - 1)
                        {
                            anagrama = false;
                        }
                    }
                }
                if (anagrama)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
            static void Task17()
            {
                string line = Console.ReadLine();
                int counter = 0;

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '(')
                    {
                        counter++;
                    }
                    else if (line[i] == ')')
                    {
                        counter--;
                    }
                    if (counter < 0) {  break; }
                    
                }

                (counter == 0) ? Console.WriteLine("YES") : Console.WriteLine("NO");

            }

            Console.WriteLine("Оберіть номер задачі:");
            Console.WriteLine("Можливі варіанти:\n15\n16\n17");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "15":
                    Console.WriteLine("Виконуємо задачу 15");
                    Task15();
                    break;

                case "16":
                    Console.WriteLine("Виконуємо задачу 16");
                    Task16();
                    break;

                case "17":
                    Console.WriteLine("Виконуємо задачу 17");
                    Task17();
                    break;

                default:
                    Console.WriteLine("Команда не розпізнана");
                    break;
            }
        }

        static void Main(string[] args)
        {
            char a;
            Console.WriteLine("Оберіть блок для виконання.");
            do
            {
                Console.WriteLine("1 - виконати перший блок.\n2 - виконати другий блок\n3 - додаткові задачі\n0 - завершити роботу програми");
                a = char.Parse(Console.ReadLine());
                switch (a)
                {
                    case '1':
                        Console.WriteLine("Виконуємо блок 1");
                        DoBlock1();
                        break;
                    case '2':
                        Console.WriteLine("Виконуємо блок 2");
                        TransformString();
                        break;
                    case '3':
                        Console.WriteLine("Відкриваємо додаткову задачу");
                        DoBonusTask();
                        break;
                    case '0':
                        Console.WriteLine("Завершуємо роботу програми.");
                        break;
                    default:
                        Console.WriteLine("Дані не опізнані, повторіть спробу.");
                        break;
                }
            } while (a != '0');
        }
    }
}