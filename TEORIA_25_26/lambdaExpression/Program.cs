class Program
{
    public delegate double MathDelegate(double n1, double n2);
    static void Main(string[] args)
    {
        MathDelegate mathDelegate = (x, y) => x + y;
        double result = mathDelegate(4, 5);
        System.Console.WriteLine("sommma \n " + result);

        mathDelegate = (x, y) => x - y;
        result = mathDelegate(6, 5);
        System.Console.WriteLine("differenza \n" + result);

        mathDelegate = (x, y) =>
        {
            //posso inserire tutto il codice che voglio 
            System.Console.WriteLine("sto eseguendo il prodotto");
            return x * y;
        };
        result = mathDelegate(7, 8);
        System.Console.WriteLine(result);
        //potenza di x^y
        mathDelegate = (x, y) =>
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return Math.Pow(x, y);
            }
        };
        System.Console.WriteLine(mathDelegate(2, 3));
        
        Console.ReadKey();
    }
}