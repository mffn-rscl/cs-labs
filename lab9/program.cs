using System;

public class Program
{
        public struct MyFrac
    {
        public long nom, denom;

        public MyFrac(long nom_, long denom_)
        {
            if (denom_ < 0)
            {
                nom_ = -nom_;
                denom_ = -denom_;
            }
            long gcd = GCD(Math.Abs(nom_), Math.Abs(denom_));
            nom = nom_ / gcd;
            denom = denom_ / gcd;
        }

        public override string ToString()
        {
            return $"{nom}/{denom}";
        }

        private static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }

    public static string ToStringWithIntPart(MyFrac f)
    {
        long intPart = f.nom / f.denom;
        MyFrac fracPart = new MyFrac(f.nom % f.denom, f.denom);
        string sign = intPart < 0 || (intPart == 0 && f.nom < 0) ? "-" : ""; 
        return $"{sign}({intPart}+{fracPart})";
    }
    

    public static double DoubleValue(MyFrac f)
    {
        return (double)f.nom / f.denom;
    }

    public static MyFrac Plus(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom, f1.denom * f2.denom);
    }

    public static MyFrac Minus(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom, f1.denom * f2.denom);
    }

    public static MyFrac Multiply(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
    }

    public static MyFrac Divide(MyFrac f1, MyFrac f2)
    {
        return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
    }

    public static MyFrac CalcExpr1(int n)
    {
        MyFrac result = new MyFrac(n, n + 1);
        return result;
    }

    public static MyFrac CalcExpr2(int n)
    {
        MyFrac result = new MyFrac(n + 1, 2 * n);
        return result;
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Введіть чисельник першого дробу:");
        long nom1 = long.Parse(Console.ReadLine());
        Console.WriteLine("Введіть знаменник першого дробу:");
        long denom1 = long.Parse(Console.ReadLine());
        MyFrac f1 = new MyFrac(nom1, denom1);
    
        Console.WriteLine("Введіть чисельник другого дробу:");
        long nom2 = long.Parse(Console.ReadLine());
        Console.WriteLine("Введіть знаменник другого дробу:");
        long denom2 = long.Parse(Console.ReadLine());
        MyFrac f2 = new MyFrac(nom2, denom2);
    
        Console.WriteLine($"f1 + f2 = {Plus(f1, f2)}");
        Console.WriteLine($"f1 - f2 = {Minus(f1, f2)}");
        Console.WriteLine($"f1 * f2 = {Multiply(f1, f2)}");
        Console.WriteLine($"f1 / f2 = {Divide(f1, f2)}");
        Console.WriteLine($"Рядкове представлення f1: {f1}");
        Console.WriteLine($"Рядкове представлення з цілою частиною f1: {ToStringWithIntPart(f1)}");
        Console.WriteLine($"Дійсне значення f1: {DoubleValue(f1)}");
    
        Console.WriteLine("Введіть значення для обчислення результату CalcExpr1:");
        int input1 = int.Parse(Console.ReadLine());
        Console.WriteLine($"Результат CalcExpr1({input1}): {CalcExpr1(input1)}");
        Console.WriteLine("Введіть значення для обчислення результату CalcExpr2:");
        int input2 = int.Parse(Console.ReadLine());
        Console.WriteLine($"Результат CalcExpr2({input2}): {CalcExpr2(input2)}");
}

}

