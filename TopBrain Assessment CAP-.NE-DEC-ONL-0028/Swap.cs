using System;

public class SolutionDefault
{

    public static void SwapUsingRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    public static void SwapUsingOut(int a, int b, out int x, out int y)
    {
        x = a + b;
        y = x - b;
        x = x - y;
    }

    public static void Main()
    {
        int num1 = 10;
        int num2 = 20;

        SwapUsingRef(ref num1, ref num2);
        Console.WriteLine("After ref swap:");
        Console.WriteLine(num1 + " " + num2);

        int a = 30;
        int b = 40;
        int x, y;

        SwapUsingOut(a, b, out x, out y);
        Console.WriteLine("After out swap:");
        Console.WriteLine(x + " " + y);
    }
}