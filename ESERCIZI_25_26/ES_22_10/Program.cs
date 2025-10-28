﻿public class Libro
{
    public int LibroID { get; set; }
    public string Titolo { get; set; }
    public int AutoreID { get; set; }
    public string Genere { get; set; }
    public int AnnoPubblicazione { get; set; }
    public int NumeroPagine { get; set; }
    public decimal Prezzo { get; set; }
    public bool Disponibile { get; set; }
    public override string ToString()
{
    return $"LibroID: {LibroID}, " +
           $"Titolo: {Titolo}, " +
           $"AutoreID: {AutoreID}, " +
           $"Genere: {Genere}, " +
           $"AnnoPubblicazione: {AnnoPubblicazione}, " +
           $"NumeroPagine: {NumeroPagine}, " +
           $"Prezzo: {Prezzo:C}, " +
           $"Disponibile: {(Disponibile ? "Sì" : "No")}";
}
}
public class Autore
{
    public int AutoreID { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public string Nazionalita { get; set; }
    public int AnnoNascita { get; set; }
    public override string ToString()
{
    return $"AutoreID: {AutoreID}, Nome: {Nome}, Cognome: {Cognome}, Nazionalità: {Nazionalita}, Anno di nascita: {AnnoNascita}";
}
}
public class Prestito
{
    public int PrestitoID { get; set; }
    public int LibroID { get; set; }
    public string NomeUtente { get; set; }
    public DateTime DataPrestito { get; set; }
    public DateTime? DataRestituzione { get; set; }
    
    public override string ToString()
    {
        return $"PrestitoID: {PrestitoID}, LibroID: {LibroID}, NomeUtente: {NomeUtente}, DataPrestito: {DataPrestito:dd/MM/yyyy}, DataRestituzione: {(DataRestituzione.HasValue ? DataRestituzione.Value.ToString("dd/MM/yyyy") : "Non restituito")}";
    }

}
class Program
{

    static List<Libro> libri = new List<Libro>()
{
    new Libro { LibroID = 1, Titolo = "I Promessi Sposi", AutoreID = 1, Genere = "Romanzo Storico", AnnoPubblicazione = 1840, NumeroPagine = 720, Prezzo = 12.50m, Disponibile = true },
    new Libro { LibroID = 2, Titolo = "La Divina Commedia", AutoreID = 2, Genere = "Poesia Epica", AnnoPubblicazione = 1320, NumeroPagine = 798, Prezzo = 15.00m, Disponibile = false },
    new Libro { LibroID = 3, Titolo = "Cent'anni di solitudine", AutoreID = 3, Genere = "Realismo Magico", AnnoPubblicazione = 1967, NumeroPagine = 417, Prezzo = 18.90m, Disponibile = true },
    new Libro { LibroID = 4, Titolo = "1984", AutoreID = 4, Genere = "Distopia", AnnoPubblicazione = 1949, NumeroPagine = 328, Prezzo = 14.50m, Disponibile = true },
    new Libro { LibroID = 5, Titolo = "La fattoria degli animali", AutoreID = 4, Genere = "Satira", AnnoPubblicazione = 1945, NumeroPagine = 112, Prezzo = 9.90m, Disponibile = true },
    new Libro { LibroID = 6, Titolo = "Orgoglio e Pregiudizio", AutoreID = 5, Genere = "Romanzo", AnnoPubblicazione = 1813, NumeroPagine = 432, Prezzo = 11.00m, Disponibile = false },
    new Libro { LibroID = 7, Titolo = "Il nome della rosa", AutoreID = 6, Genere = "Giallo Storico", AnnoPubblicazione = 1980, NumeroPagine = 503, Prezzo = 16.50m, Disponibile = true },
    new Libro { LibroID = 8, Titolo = "Il pendolo di Foucault", AutoreID = 6, Genere = "Romanzo", AnnoPubblicazione = 1988, NumeroPagine = 623, Prezzo = 19.00m, Disponibile = true },
    new Libro { LibroID = 9, Titolo = "Il vecchio e il mare", AutoreID = 7, Genere = "Novella", AnnoPubblicazione = 1952, NumeroPagine = 127, Prezzo = 10.50m, Disponibile = false },
    new Libro { LibroID = 10, Titolo = "Per chi suona la campana", AutoreID = 7, Genere = "Romanzo di Guerra", AnnoPubblicazione = 1940, NumeroPagine = 471, Prezzo = 17.00m, Disponibile = true }
};
    static List<Autore> autori = new List<Autore>()
{
    new Autore { AutoreID = 1, Nome = "Alessandro", Cognome = "Manzoni", Nazionalita = "Italiana", AnnoNascita = 1785 },
    new Autore { AutoreID = 2, Nome = "Dante", Cognome = "Alighieri", Nazionalita = "Italiana", AnnoNascita = 1265 },
    new Autore { AutoreID = 3, Nome = "Gabriel", Cognome = "García Márquez", Nazionalita = "Colombiana", AnnoNascita = 1927 },
    new Autore { AutoreID = 4, Nome = "George", Cognome = "Orwell", Nazionalita = "Britannica", AnnoNascita = 1903 },
    new Autore { AutoreID = 5, Nome = "Jane", Cognome = "Austen", Nazionalita = "Britannica", AnnoNascita = 1775 },
    new Autore { AutoreID = 6, Nome = "Umberto", Cognome = "Eco", Nazionalita = "Italiana", AnnoNascita = 1932 },
    new Autore { AutoreID = 7, Nome = "Ernest", Cognome = "Hemingway", Nazionalita = "Americana", AnnoNascita = 1899 }
};
    static List<Prestito> prestiti = new List<Prestito>()
{
    new Prestito { PrestitoID = 1, LibroID = 2, NomeUtente = "Mario Rossi", DataPrestito = new DateTime(2025, 9, 15), DataRestituzione = null },
    new Prestito { PrestitoID = 2, LibroID = 6, NomeUtente = "Laura Bianchi", DataPrestito = new DateTime(2025, 10, 1), DataRestituzione = null },
    new Prestito { PrestitoID = 3, LibroID = 9, NomeUtente = "Giuseppe Verdi", DataPrestito = new DateTime(2025, 10, 5), DataRestituzione = null },
    new Prestito { PrestitoID = 4, LibroID = 1, NomeUtente = "Anna Neri", DataPrestito = new DateTime(2025, 8, 20), DataRestituzione = new DateTime(2025, 9, 10) },
    new Prestito { PrestitoID = 5, LibroID = 4, NomeUtente = "Mario Rossi", DataPrestito = new DateTime(2025, 9, 1), DataRestituzione = new DateTime(2025, 9, 25) },
    new Prestito { PrestitoID = 6, LibroID = 7, NomeUtente = "Laura Bianchi", DataPrestito = new DateTime(2025, 7, 15), DataRestituzione = new DateTime(2025, 8, 5) },
    new Prestito { PrestitoID = 7, LibroID = 3, NomeUtente = "Giuseppe Verdi", DataPrestito = new DateTime(2025, 6, 10), DataRestituzione = new DateTime(2025, 7, 1) }
};

    static void Q1()
    {
        var libriDispo = libri.Where(libri => libri.AnnoPubblicazione > 1900 && libri.Prezzo < 15).ToList();
        foreach (var item in libriDispo)
        {
            System.Console.WriteLine(item);
        }
    }
    static void Q2()
    {
        var autore = autori.Where(c => c.Nazionalita == "Italiana" && c.AnnoNascita < 1901).ToList();
        foreach (var item in autore)
        {
            System.Console.WriteLine(item);
        }
    }
    static void Q3()
    {
        var prest = prestiti.Where(c => c.NomeUtente == "Mario Rossi" && c.DataRestituzione == null).ToList();
        prest.ForEach(c => System.Console.WriteLine(c));
    }
    static void Q4()
    {
        var ordina = libri.OrderBy(libri => libri.Genere).ThenByDescending(l => l.Prezzo).ToList();
        foreach (var item in ordina)
        {
            System.Console.WriteLine(item.Genere + " " + item.Prezzo);
        }
    }
    static void Q5()
    {
        var ordiCogn = autori.OrderByDescending(c => c.Cognome).ToList();
        ordiCogn.ForEach(c => System.Console.WriteLine(c.Cognome));
    }
    static void Q6()
    {
        var ordingener = libri.GroupBy(libri => libri.Genere).ToList();
        foreach (var group in ordingener)
        {
            Console.WriteLine(group.Key);
            System.Console.WriteLine("numero libri = " + group.Count());
            System.Console.WriteLine("prezzo medio = " + group.Average(s => s.Prezzo));
            System.Console.WriteLine("num pag max = " + group.Max(s => s.NumeroPagine));
            foreach (var item in group)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
    static void Q7()
    {
        var nazAutori = autori.GroupBy(a => a.Nazionalita).ToList();
        foreach (var group in nazAutori)
        {
            System.Console.WriteLine($"numero autori {group.Key} = " + group.Count());
        }
    }
    static void Q8()
    {
        var librAut = libri.GroupBy(libri => libri.AutoreID).ToList();
        foreach (var group in librAut)
        {
            Console.WriteLine($"num tot libri scritti da {group.Key} = {group.Count()}");
            Console.WriteLine($"prezzo tot dei libri di {group.Key} = {group.Sum(s => s.Prezzo)}");
            Console.WriteLine($"anno del libro più recente di {group.Key} = {group.Max(s => s.AnnoPubblicazione)}");


        }
    }
    static void Q9()
    {
        var prestitiUtent = prestiti.GroupBy(a => a.NomeUtente).ToList();
        foreach (var item in prestitiUtent)
        {
            System.Console.WriteLine(item.Count());
            System.Console.WriteLine(item.Count(s => s.DataRestituzione == null));
            System.Console.WriteLine(item.Count(s => s.DataRestituzione != null));
        }
    }
    static void Q10()
    {
        var unioneLibAut = libri.Join(autori,
        a => a.AutoreID,
        b => b.AutoreID,
        (a, b) => new { titolo = a.Titolo, nome = b.Nome + b.Cognome, nazionalità = b.Nazionalita, annoDiPubblicazione = a.AnnoPubblicazione }
        );
        foreach (var item in unioneLibAut)
        {
            Console.WriteLine($"titolo = {item.titolo}  nome = {item.nome}   nazionalità = {item.nazionalità} anno di pubblicazione = {item.annoDiPubblicazione}");
        }
    }
    static void Q11()
    {
        var unioCOMPL = libri.Join(autori,
        a => a.AutoreID,
        b => b.AutoreID,
        (a, b) => new { libroID = a.LibroID, titolo = a.Titolo, cognome = b.Cognome }
        ).Join(prestiti,
        c => c.libroID,
        d => d.LibroID,
        (c, d) => new { libroID = c.libroID, titolo = c.titolo, cognome = c.cognome, nomeU = d.NomeUtente, dataP = d.DataPrestito }
        );
        foreach (var item in unioCOMPL)
        {
            System.Console.WriteLine(item);
        }
    }
    static void Q12()
    {
        var unioneLibriAut = libri.Join(autori,
        a => a.AutoreID,
        b => b.AutoreID,
        (a, b) => new { titolo = a.Titolo, cognome = b.Cognome, nazionalità = b.Nazionalita, annoPubb = a.AnnoPubblicazione, prezzo = a.Prezzo }
        ).Where (n => (n.nazionalità == "Britannica" || n.nazionalità == "Americana") && n.annoPubb > 1940).OrderBy(a => a.annoPubb);
        foreach (var item in unioneLibriAut)
        {
            Console.WriteLine($"{item.titolo}        {item.cognome}          {item.nazionalità}      {item.annoPubb}");
            
        }
        
    }
    static void Main(string[] args)
    {
        Q6();
        Console.ReadKey();
    }

}