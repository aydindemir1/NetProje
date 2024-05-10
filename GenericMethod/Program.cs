using System;

public class Program
{
    // Generic metot tanımı
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    static void Main(string[] args)
    {
        int num1 = 10;
        int num2 = 20;

        // Swap metodu çağrılıyor
        Console.WriteLine("Before swap: num1 = " + num1 + ", num2 = " + num2);
        Swap(ref num1, ref num2);
        Console.WriteLine("After swap: num1 = " + num1 + ", num2 = " + num2);

        string str1 = "hello";
        string str2 = "world";

        // Swap metodu çağrılıyor
        Console.WriteLine("Before swap: str1 = " + str1 + ", str2 = " + str2);
        Swap(ref str1, ref str2);
        Console.WriteLine("After swap: str1 = " + str1 + ", str2 = " + str2);
    }
}
