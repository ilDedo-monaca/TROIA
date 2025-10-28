public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}
class Program
{
    //public delegate double MathDelegate(double n1, double n2);
    static void Main(string[] args)
    {
        Func<double, double, double> MathDelegate = (x, y) => x + y;
        System.Console.WriteLine(MathDelegate(4, 5));
        Func<Student,bool> isTeen = s => s.Age >12 && s.Age < 20;
        System.Console.WriteLine(isTeen(new(){Age = 15}));
        Console.ReadKey();
    }
}