using System;

class Program
{
    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("Choose the task programm (enter 1, 2, 3) or if you wanna leave, press 0:");
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CubeVolume();
                        break;
                    case 2:
                        Example();
                        break;
                    case 3:
                        IsInRange();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Incorrect input. Please, try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (choice != 0);
    }

    static void CubeVolume()
    {
        Console.Write("Enter the side length of the cube to calculate the volume: ");
        double sideOfCube = Convert.ToDouble(Console.ReadLine());

        double volume = Math.Pow(sideOfCube, 3);

        Console.WriteLine($"The side of the cube is {sideOfCube}, and its volume is {volume}");
    }

    static void Example()
    {
        Console.Write("Enter a value for x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"Result: {Math.Pow(Math.Abs(x + 1), 0.25) + Math.Pow(x, -2)}");
    }

    static void IsInRange()
    {
        Console.Write("Enter values for x and y separated by space: ");
        string[] input = Console.ReadLine().Split();
        double x = Convert.ToDouble(input[0]);
        double y = Convert.ToDouble(input[1]);

        bool isInRange = Math.Abs(x) <= 1 && y <= 2 && y >= Math.Abs(x) - 1;

        Console.WriteLine(isInRange ? "YES" : "NO");
    }
}
