using System.ComponentModel.DataAnnotations;
using System.IO.Compression;

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
    public double Prezzo { get; set; }
    public override string ToString()
    {
        return $"romanzo id = {RomanzoId}, titolo = {Titolo}, anno di pubblicazione = {AnnoPubblicazione}, autore id  = {AutoreId}, prezzo = {Prezzo}";
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
            new Autore { AutoreId = 1, Cognome = "Levi", Nome = "Primo", Nazionalità = "Francese" },
            new Autore { AutoreId = 2, Cognome = "Eco", Nome = "Umberto", Nazionalità = "Inglese" },
            new Autore { AutoreId = 3, Cognome = "Calvino", Nome = "Italo", Nazionalità = "Italiana" },
            new Autore { AutoreId = 4, Cognome = "Moravia", Nome = "Alberto", Nazionalità = "Italiana" },
            new Autore { AutoreId = 5, Cognome = "Pirandello", Nome = "Luigi", Nazionalità = "Inglese" }
        };
    static List<Romanzo> Romanzi = new List<Romanzo>
        {
            new Romanzo {RomanzoId = 1, Titolo = "Se questo è un uomo", AnnoPubblicazione = 1947, AutoreId =1, Prezzo = 50},
            new Romanzo {RomanzoId = 2, Titolo = "Il nome della rosa", AnnoPubblicazione = 1980, AutoreId = 2, Prezzo = 40},
            new Romanzo {RomanzoId = 3, Titolo = "Il barone rampante", AnnoPubblicazione = 1957, AutoreId = 3, Prezzo = 30 },
            new Romanzo { RomanzoId = 4, Titolo = "Gli indifferenti", AnnoPubblicazione = 1929, AutoreId = 4, Prezzo = 17.20 },
            new Romanzo { RomanzoId = 5, Titolo = "Uno, nessuno e centomila", AnnoPubblicazione = 1926, AutoreId = 5, Prezzo = 10 },
            new Romanzo { RomanzoId = 6, Titolo = "La giornata di uno scrutatore", AnnoPubblicazione = 1963, AutoreId = 3,Prezzo = 100 },
            new Romanzo { RomanzoId = 7, Titolo = "La coscienza di Zeno", AnnoPubblicazione = 1957, AutoreId = 5, Prezzo = 95}
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

    static void Q1(string naz)
    {
        var autor = autori.Join(Romanzi,
        a => a.AutoreId,
        r => r.AutoreId,
        (a, r) => new { nazi = a.Nazionalità, prez = r.Prezzo }).Where(a => a.nazi == naz);
        System.Console.WriteLine(autor.Average(p => p.prez));
    }
    static void Q2()
    {
        var testiI = Romanzi.Where(r => r.AnnoPubblicazione > 1960).ToList();
        System.Console.WriteLine(testiI.Max(p => p.Prezzo));
    }
    static void Q3(string nazi, int annoMin)
    {
        var tutto = autori.Join(Romanzi,
        a => a.AutoreId,
        r => r.AutoreId,
        (a, r) => new { naz = a.Nazionalità, anno = r.AnnoPubblicazione, id = r.RomanzoId }).Join(personaggi,
        r => r.id,
        p => p.RomanzoId,
        (r, p) => new { nome = p.Nome, nazio = r.naz, ann = r.anno }).Where(a => a.nazio == nazi && a.ann > annoMin).ToList();
        foreach (var item in tutto)
        {
            System.Console.WriteLine(item.nome);
        }
    }
    static void Q4()
    {
        var nPer = Romanzi.Select(r => new { titolo = r.Titolo, numPer = personaggi.Count(p => p.RomanzoId == r.RomanzoId) });
        foreach (var item in nPer)
        {
            System.Console.WriteLine(item);
        }
    }
    static void Main(string[] args)
    {
        Console.ReadKey();
    }
}
