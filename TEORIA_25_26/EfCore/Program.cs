using System.Runtime.ConstrainedExecution;
using EFGetStarted;

class Program
{
    static void Main(string[] args)
    {
        BloggingContext db = new BloggingContext();
        // db.Add(new Blog { Url = "mio blog" });
        // db.Add(new Blog { Url = "mio blog 1" });
        // db.SaveChanges();
        db.Blogs.ToList().ForEach(b => System.Console.WriteLine(b.Url));
        Console.ReadKey();
    }
}