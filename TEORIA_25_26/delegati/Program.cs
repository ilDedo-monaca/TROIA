using System.ComponentModel;

class Program
{
    public delegate double? MathDelegate(double n1, double n2);
    public delegate void Print(int value);
    static void Main(string[] args)
    {
        Print pippo = PrintNumber;
        pippo(20);
        pippo(2000);
        pippo = PrintMoney;
        pippo(30);
        pippo(3000);
        System.Console.WriteLine("\n");
        MathDelegate mathDelegate = Add;
        System.Console.WriteLine("somma" + " = " + mathDelegate(3, 4));
        mathDelegate = Sub;
        System.Console.WriteLine("differenza" + " = " + mathDelegate(5, 2));
        mathDelegate = Divisione;
        System.Console.WriteLine("divisione " + " = " + mathDelegate(8, 2));



        Console.ReadKey();
    }
    public static void PrintNumber(int num)
    {
        System.Console.WriteLine($"il valore di num è = {num}");
    }
    public static void PrintMoney(int money)
    {
        System.Console.WriteLine("money {0:C}", money);
    }
    public static double? Add(double n1, double n2)
    {
        return n1 + n2;
    }
    public static double? Sub(double n1, double n2)
    {
        return n1 - n2;
    }
    public static double? Divisione(double n1, double n2)
    {
        if (n2 != 0)
        {
            return n1 / n2;
        }
        return null;
    }
}