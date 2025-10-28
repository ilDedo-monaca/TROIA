public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}
class Program
{
    public delegate bool IsTeen(Student stud);
    public delegate bool IsYungerThan(Student s, int yungAge);
    static void Main(string[] args)
    {
        //IsTeen isTeen = delegate (Student stud) { return stud.Age > 12 && stud.Age < 20; };
        IsTeen isTeen = stud => stud.Age > 12 && stud.Age < 20;
        Student student = new() { Age = 20 };
        //student.Age = 20;
        System.Console.WriteLine(isTeen(student));
        IsYungerThan isYungerThan = (stud, yungAge) => stud.Age < yungAge;
        Student student2 = new() { Age = 20 };
        System.Console.WriteLine(isYungerThan(student2,15));
        
        Console.ReadKey();
    }
}