using System;
 namespace RefactoringGuru.DesignPatterns.Prototype.Conceptual
 {
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person) this.MemberwiseClone();
        }
        public Person DeepCopy()
        {
            Person clone = (Person) this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = string.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;
        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jake Daniels";
            p1.IdInfo = new IdInfo(666);

            Person p2 = p1.ShallowCopy();
            Person p3 = p1.DeepCopy();

            Console.WriteLine("Valores originales de p1, p2, p3:");
            Console.WriteLine("  valores de instancia p1:");
            DisplayValues(p1);

            Console.WriteLine("  valores de instancia p2:");
            DisplayValues(p2);
            Console.WriteLine("  valores de instancia p3:");
            DisplayValues(p3);

            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\n Valores de p1, p2 y p3 despues de cambios a p1:");
            Console.WriteLine("  Valores de instancia p1: ");
            DisplayValues(p1);
            Console.WriteLine("  Valores de instancia p2 (los valores de referencia han cambiado): ");
            DisplayValues(p2);
            Console.WriteLine("  Valores de instancia p3 (todo se mantuvo igual): ");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("  Name: {0:s}, Age: {1:d}, BrithDate:{2:MM/dd/yy}", 
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("  IdInfo# {0:d}", p.IdInfo.IdNumber);
        }
    }
 }