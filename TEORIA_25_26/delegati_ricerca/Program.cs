﻿    class Student
    {
        public int StudentID { get; set; }
        public String? StudentName { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return String.Format($"[StudentID = {StudentID}, StudentName = {StudentName}, Age = {Age}]");
        }
    }
class Program
{
    static void Main(string[] args)
    {
        Student[] studentArray = {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve", Age = 21 } ,
            new Student() { StudentID = 3, StudentName = "Bill", Age = 25 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 31 } ,
            new Student() { StudentID = 6, StudentName = "Chris", Age = 17 } ,
            new Student() { StudentID = 7, StudentName = "Rob",Age = 19 } ,
        };
        Student[] teenAgersStudents = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();
        foreach (var item in teenAgersStudents)
        {
            System.Console.WriteLine(item);
        }
        Student sBill = studentArray.Where(s => s.StudentName.Equals("Bill")).FirstOrDefault();
        System.Console.WriteLine(sBill);
        System.Console.WriteLine("metodo con il profm");
        var teenAgers = from s in studentArray
                        where s.Age > 12 && s.Age < 20
                        select s;
        foreach (var item in teenAgers)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("metodo fluent");
        teenAgers = studentArray.Where(s => s.Age > 12 && s.Age < 20).ToArray();
        foreach (var item in teenAgers)
        {
            System.Console.WriteLine(item);
        }
    }


}
 