using System;

class Program
{
    static double CalcTriangleSquare(int Bx, int By, int Cx, int Cy)
    {
        return 0.5 * Math.Abs(Bx * (Cy - 0) + Cx * (0 - By));
    }

    static void CalcTriangleSquareByPoints(int a, int b)
    {
        int MODULE_A = Math.Abs(a);
        int MODULE_B = Math.Abs(b);
        double tempSquare, solutionSquare = int.MaxValue;
        int Ax = 0, Ay = 0, Cx = 0, Cy = 0;

        for (int x = 0; x <= MODULE_A; x++)
        {
            for (int y = 0; y <= MODULE_B; y++)
            {
                tempSquare = CalcTriangleSquare(MODULE_A, MODULE_B, x, y);
                if (tempSquare != 0 && tempSquare < solutionSquare)
                {
                    solutionSquare = tempSquare;
                    Cx = x;
                    Cy = y;
                }
            }
        }

        Console.WriteLine($"\nSmallest square of triangle equals: {solutionSquare}");
        Console.WriteLine($"Coordinates of point C equals: ({(a < 0 && Cx != 0 ? '-' : ' ')}{Cx}; {(b < 0 && Cy != 0 ? '-' : ' ')}{Cy})");
    }

    static void Main()
    {
        Console.WriteLine("Task #3. Lab #3\n");
        Console.WriteLine("The coordinates of point A(0,0) are given, we need to find the coordinates of point C(x;y) so that the area of the triangle is minimal and at the same time canceled from zero.");
        Console.WriteLine("The program receives two values, a and b - the coordinates of point B on the Cartesian coordinate system, and calculates the minimum area of the triangle.\n");

        Console.Write("Enter here the value x of point B:");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter here the value y of point B:");
        int b = int.Parse(Console.ReadLine());

        CalcTriangleSquareByPoints(a, b);
    }
}