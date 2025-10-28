class Program
{
    public delegate void Del(string s);
    public static void Hello(string s)
    {
        Console.WriteLine("hello" + s);
    }
    public static void Goodbye (string s)
    {
        Console.WriteLine ("goodbye" + s);
    }
    static void Main(string[] args)
    {
        Del a, b, c, d, k;
        a = new Del(Hello);
        b = Goodbye;
        c = a + b;
        k = null;
        k += a;
        k += b;
        d = c - a;
        System.Console.WriteLine("invoco il delegato a:");
        a(" A");
        System.Console.WriteLine("invoco il delegato b:");
        b(" B");
        System.Console.WriteLine("invoco il delegato c:");
        c(" C");
        System.Console.WriteLine("invoco il delegato d:");
        d(" D");
        System.Console.WriteLine("invoco il delegato k:");
        k(" K");

        Console.ReadKey();
    }
}