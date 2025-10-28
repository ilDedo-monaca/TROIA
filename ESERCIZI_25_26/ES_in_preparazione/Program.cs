using System.ComponentModel.DataAnnotations;

public class Autore
{
    public int AutoreId { get; set; }
    public string Cognome { get; set; }
    public string Nome { get; set; }
    public string Nazionalità { get; set; }
    public override string ToString()
    {
        return $"autoreId = {AutoreId}, cognome = {Cognome}, nome = {Nome}, nazionalità = {Nazionalità}";
    }
}
public class Romanzo
{
    public int RomanzoId { get; set; }
    public string Titolo { get; set; }
    public int AnnoPubblicazione { get; set; }
    public int AutoreId { get; set; }
    public override string ToString()
    {
        return $"romanzo id = {RomanzoId}, titolo = {Titolo}, anno di pubblicazione = {AnnoPubblicazione}, autore id  = {AutoreId}";
    }
}
public class Personaggio
{
    public int PersonaggioId { get; set; }
    public string Nome { get; set; }
    public string Ruolo { get; set; }
    public string Sesso { get; set; }
    public int RomanzoId { get; set; }
    public override string ToString()
    {
        return $"personaggio id = {PersonaggioId}, nome = {Nome}, ruolo = {Ruolo}, sesso = {Sesso}, romanzo id  = {RomanzoId}";
    }
}
class Program
{
    static List<Autore> autori = new List<Autore>
        {
            new Autore { AutoreId = 1, Cognome = "Levi", Nome = "Primo", Nazionalità = "Italiana" },
            new Autore { AutoreId = 2, Cognome = "Eco", Nome = "Umberto", Nazionalità = "Italiana" },
            new Autore { AutoreId = 3, Cognome = "Calvino", Nome = "Italo", Nazionalità = "Italiana" },
            new Autore { AutoreId = 4, Cognome = "Moravia", Nome = "Alberto", Nazionalità = "Italiana" },
            new Autore { AutoreId = 5, Cognome = "Pirandello", Nome = "Luigi", Nazionalità = "Italiana" }
        };
    static List<Romanzo> Romanzi = new List<Romanzo>
        {
            new Romanzo {RomanzoId = 1, Titolo = "Se questo è un uomo", AnnoPubblicazione = 1947, AutoreId =1},
            new Romanzo {RomanzoId = 2, Titolo = "Il nome della rosa", AnnoPubblicazione = 1980, AutoreId = 2},
            new Romanzo {RomanzoId = 3, Titolo = "Il barone rampante", AnnoPubblicazione = 1957, AutoreId = 3 },
            new Romanzo { RomanzoId = 4, Titolo = "Gli indifferenti", AnnoPubblicazione = 1929, AutoreId = 4 },
            new Romanzo { RomanzoId = 5, Titolo = "Uno, nessuno e centomila", AnnoPubblicazione = 1926, AutoreId = 5 },
            new Romanzo { RomanzoId = 6, Titolo = "La giornata di uno scrutatore", AnnoPubblicazione = 1963, AutoreId = 3 },
            new Romanzo { RomanzoId = 7, Titolo = "La coscienza di Zeno", AnnoPubblicazione = 1957, AutoreId = 5 }
        };
    static List<Personaggio> personaggi = new List<Personaggio>
        {
            new Personaggio { PersonaggioId = 1, Nome = "Jean Valjean", Ruolo = "Protagonista", Sesso = "M", RomanzoId = 1 },
            new Personaggio { PersonaggioId = 2, Nome = "Cosette", Ruolo = "Protagonista", Sesso = "F", RomanzoId = 1 },
            new Personaggio { PersonaggioId = 3, Nome = "Guglielmo da Baskerville", Ruolo = "Protagonista", Sesso = "M", RomanzoId = 2 },
            new Personaggio { PersonaggioId = 4, Nome = "Adso da Melk", Ruolo = "Protagonista", Sesso = "M", RomanzoId = 2 },
            new Personaggio { PersonaggioId = 5, Nome = "Cosimo Piovasco di Rondò", Ruolo = "Protagonista", Sesso = "M", RomanzoId = 3 },
            new Personaggio { PersonaggioId = 6, Nome = "Marcello", Ruolo = "Protagonista", Sesso = "M", RomanzoId = 4 },
            new Personaggio { PersonaggioId = 7, Nome = "Vitangelo Moscarda", Ruolo = "Protagonista", Sesso = "M", RomanzoId = 5 },
            new Personaggio { PersonaggioId = 8, Nome = "Amerigo Ormea", Ruolo = "Protagonista", Sesso = "M", RomanzoId = 6 },
            new Personaggio { PersonaggioId = 9, Nome = "Zeno Cosini", Ruolo = "Protagonista", Sesso = "M", RomanzoId = 7 },
            new Personaggio { PersonaggioId = 10, Nome = "Augusta", Ruolo = "Protagonista", Sesso = "F", RomanzoId = 7 }
        };

    static void Q1(string nazionalità)
    {
        var nazionalit = autori.Where(a => a.Nazionalità == nazionalità).ToList();
        foreach (var item in nazionalit)
        {
            System.Console.WriteLine(item);
        }
    }
    static void Q2(string nome, string cognome)
    {
        var autor = autori.Where(a => a.Nome == nome && a.Cognome == cognome).Join(Romanzi,
        a => a.AutoreId,
        b => b.AutoreId,

        (a, b) => new { Romanzi = b }
        );
        foreach (var item in autor)
        {
            System.Console.WriteLine(item);
        }
    }
    static void Q3(string nazionalita)
    {
        var romNaz = autori.Where(a => a.Nazionalità == nazionalita).Join(Romanzi,
        a => a.AutoreId,
        r => r.AutoreId,
        (a, r) => new { }
        ).ToList();
        System.Console.WriteLine(romNaz.Count());

    }
    static void Q4()
    {
        var romanzNaz = autori.Join(Romanzi,
        a => a.AutoreId,
        r => r.AutoreId,
        (a, r) => new { nazionalità = a.Nazionalità }).GroupBy(a => a.nazionalità).ToList();
        foreach (var item in romanzNaz)
        {
            System.Console.WriteLine(item.Key + "= " + item.Count());
        }
    }
    static void Q5(string nazion)
    {
        var personNaz = autori.Where(a => a.Nazionalità == nazion).Join(Romanzi,
        a => a.AutoreId,
        r => r.AutoreId,
        (a, r) => new { r.RomanzoId }).Join(personaggi,
        r => r.RomanzoId,
        p => p.RomanzoId,
        (r, p) => new { p.Nome });
        foreach (var item in personNaz)
        {
            System.Console.WriteLine(item.Nome);
        }
    }
    static void Q6(string nazion)
    {
        var personag = autori.Join(Romanzi,
        a => a.AutoreId,
        r => r.AutoreId,
        (a, r) => new { nazion = a.Nazionalità, romanzID = r.RomanzoId }).Join(personaggi,
        ro => ro.romanzID,
        p => p.RomanzoId,
        (ro, p) => new { nazio = ro.nazion, personaggi = p }).Where(a => a.nazio == nazion).ToList();
        foreach (var item in personag)
        {
            System.Console.WriteLine(item.personaggi);
            
        }
    }
    static void Main(string[] args)
    {
        // Q1("Italiana");
        // Q2("Italo", "Calvino");
        // Q3("Italiana");
        // Q4();
        Q6("Italiana");
        Console.ReadKey();
    }
}  