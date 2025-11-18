using ES_sqlit.data;
using ES_sqlit.model;

class Program
{
    static List<Libro> initL()
    {
        List<Libro> libri = new List<Libro>
        {
            // AutoreId = 1 → Italo Calvino
            new Libro
            {
                LibroId = 1,
                Titolo = "Il barone rampante",
                Anno = 1957,
                Pagine = 250,
                AutoreId = 1
            },
            new Libro
            {
                LibroId = 2,
                Titolo = "Le città invisibili",
                Anno = 1972,
                Pagine = 180,
                AutoreId = 1
            },

            // AutoreId = 2 → Umberto Eco
            new Libro
            {
                LibroId = 3,
                Titolo = "Il nome della rosa",
                Anno = 1980,
                Pagine = 550,
                AutoreId = 2
            },
            new Libro
            {
                LibroId = 4,
                Titolo = "Il pendolo di Foucault",
                Anno = 1988,
                Pagine = 640,
                AutoreId = 2
            },

            // AutoreId = 3 → Elena Ferrante
            new Libro
            {
                LibroId = 5,
                Titolo = "L'amica geniale",
                Anno = 2011,
                Pagine = 327,
                AutoreId = 3
            },
            new Libro
            {
                LibroId = 6,
                Titolo = "Storia del nuovo cognome",
                Anno = 2012,
                Pagine = 471,
                AutoreId = 3
            },

            // AutoreId = 4 → Alessandro Manzoni
            new Libro
            {
                LibroId = 7,
                Titolo = "I promessi sposi",
                Anno = 1840,
                Pagine = 720,
                AutoreId = 4
            },
            new Libro
            {
                LibroId = 8,
                Titolo = "Adelchi",
                Anno = 1822,
                Pagine = 230,
                AutoreId = 4
            },

            // AutoreId = 5 → Dante Alighieri
            new Libro
            {
                LibroId = 9,
                Titolo = "Divina Commedia",
                Anno = 1320,
                Pagine = 798,
                AutoreId = 5
            },
            new Libro
            {
                LibroId = 10,
                Titolo = "Vita nuova",
                Anno = 1295,
                Pagine = 120,
                AutoreId = 5
            }
        };
        foreach (var libro in libri)
        {
            Console.WriteLine($"{libro.LibroId}: \"{libro.Titolo}\" ({libro.Anno}) - {libro.Pagine} pagine, AutoreId = {libro.AutoreId}");
        }
                var db = new LibreriaContext();
                libri.ForEach(x => db.Add(x));
                db.SaveChanges();
        return libri;
    }
    static List<Autore> initA()
    {
        List<Autore> autori = new List<Autore>
        {
            new Autore
            {
                AutoreId = 1,
                Nome = "Italo",
                Cognome = "Calvino",
                DataNascita = new DateOnly(1923, 10, 15)
            },
            new Autore
            {
                AutoreId = 2,
                Nome = "Umberto",
                Cognome = "Eco",
                DataNascita = new DateOnly(1932, 1, 5)
            },
            new Autore
            {
                AutoreId = 3,
                Nome = "Elena",
                Cognome = "Ferrante",
                DataNascita = new DateOnly(1943, 10, 20)
            },
            new Autore
            {
                AutoreId = 4,
                Nome = "Alessandro",
                Cognome = "Manzoni",
                DataNascita = new DateOnly(1785, 3, 7)
            },
            new Autore
            {
                AutoreId = 5,
                Nome = "Dante",
                Cognome = "Alighieri",
                DataNascita = new DateOnly(1265, 5, 21)
            }
        };
        foreach (var autore in autori)
        {
            Console.WriteLine($"{autore.AutoreId}: {autore.Nome} {autore.Cognome} (nato il {autore.DataNascita})");
        }
        var db = new LibreriaContext();
        autori.ForEach(x => db.Add(x));
        db.SaveChanges();
        return autori;


    }
    

    static void Main(string[] args)
    {
        List<Autore> a = initA();
        List<Libro> l = initL();
        System.Console.WriteLine(a);
        System.Console.WriteLine(l);
        
        Console.ReadKey();
    }
}
