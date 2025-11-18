using System.IO.Compression;

public class Artista
{
    public int ArtistaId { get; set; }
    public string NomeArte { get; set; }
    public string GenereMusicale { get; set; }
    public string PaeseOrigine { get; set; }
}
public class Album
{
    public int AlbumId { get; set; }
    public string Titolo { get; set; }
    public int AnnoUscita { get; set; }
    public int ArtistaId { get; set; } // Chiave esterna
}
public class Canzone
{
    public int CanzoneId { get; set; }
    public string Titolo { get; set; }
    public double DurataMinuti { get; set; } // Durata in minuti (es. 3.5)
    public int AlbumId { get; set; }      // Chiave esterna
}

class Program
{
       static List<Artista> Artisti = new List<Artista>
        {
            new Artista { ArtistaId = 1, NomeArte = "Daft Punk", GenereMusicale = "Electronic", PaeseOrigine = "Francia" },
            new Artista { ArtistaId = 2, NomeArte = "Fabrizio De André", GenereMusicale = "Cantautore", PaeseOrigine = "Italia" },
            new Artista { ArtistaId = 3, NomeArte = "Pink Floyd", GenereMusicale = "Rock Progressivo", PaeseOrigine = "Regno Unito" },
            new Artista { ArtistaId = 4, NomeArte = "Bob Marley", GenereMusicale = "Reggae", PaeseOrigine = "Giamaica" },
            new Artista { ArtistaId = 5, NomeArte = "Lucio Battisti", GenereMusicale = "Cantautore", PaeseOrigine = "Italia" }
        };

        static List<Album> Albums = new List<Album>
        {
            new Album { AlbumId = 1, Titolo = "Discovery", AnnoUscita = 2001, ArtistaId = 1 },
            new Album { AlbumId = 2, Titolo = "Random Access Memories", AnnoUscita = 2013, ArtistaId = 1 },
            new Album { AlbumId = 3, Titolo = "Creuza de ma", AnnoUscita = 1984, ArtistaId = 2 },
            new Album { AlbumId = 4, Titolo = "The Dark Side of the Moon", AnnoUscita = 1973, ArtistaId = 3 },
            new Album { AlbumId = 5, Titolo = "Exodus", AnnoUscita = 1977, ArtistaId = 4 },
            new Album { AlbumId = 6, Titolo = "Una donna per amico", AnnoUscita = 1978, ArtistaId = 5 },
            new Album { AlbumId = 7, Titolo = "The Wall", AnnoUscita = 1979, ArtistaId = 3 }
        };
    static List<Canzone> Canzoni = new List<Canzone>
        {
            new Canzone { CanzoneId = 1, Titolo = "One More Time", DurataMinuti = 5.33, AlbumId = 1 },
            new Canzone { CanzoneId = 2, Titolo = "Harder, Better, Faster, Stronger", DurataMinuti = 3.73, AlbumId = 1 },
            new Canzone { CanzoneId = 3, Titolo = "Get Lucky", DurataMinuti = 6.15, AlbumId = 2 },
            new Canzone { CanzoneId = 4, Titolo = "Jamming", DurataMinuti = 3.50, AlbumId = 5 },
            new Canzone { CanzoneId = 5, Titolo = "Time", DurataMinuti = 7.08, AlbumId = 4 },
            new Canzone { CanzoneId = 6, Titolo = "Money", DurataMinuti = 6.36, AlbumId = 4 },
            new Canzone { CanzoneId = 7, Titolo = "Another Brick in the Wall, Part 2", DurataMinuti = 3.98, AlbumId = 7 },
            new Canzone { CanzoneId = 8, Titolo = "Sinan Capudan Pascià", DurataMinuti = 5.53, AlbumId = 3 },
            new Canzone { CanzoneId = 9, Titolo = "Una donna per amico", DurataMinuti = 5.20, AlbumId = 6 },
            new Canzone { CanzoneId = 10, Titolo = "Nessun dolore", DurataMinuti = 6.10, AlbumId = 6 }
        };
    static void Q1(string genere)
    {
        var autXgen = Artisti.Where(a => a.GenereMusicale == genere).ToList();
        foreach (var item in autXgen)
        {
            System.Console.WriteLine(item.PaeseOrigine + item.NomeArte);
        }
    }
    static void Q2(int anno)
    {
        var autXgen = Albums.Where(a => a.AnnoUscita > anno).ToList();
        foreach (var item in autXgen)
        {
            System.Console.WriteLine(item.Titolo + " " + item.AnnoUscita);
        }
    }
    static void Q3(string nomearte)
    {
        var baby = Artisti.Join(Albums,
        a => a.ArtistaId,
        al => al.ArtistaId,
        (a, al) => new { titolo = al.Titolo, nome = a.NomeArte }).Where(a => a.nome == nomearte).ToList();
        foreach (var item in baby)
        {
            System.Console.WriteLine(item.titolo);
        }
    }
    static void Q4()
    {
        var ciao = Artisti.Join(Albums,
        a => a.ArtistaId,
        al => al.ArtistaId,
        (a, al) => new { paese = a.PaeseOrigine, artistaid = a.ArtistaId }).GroupBy(a => a.paese).ToList();
        foreach (var item in ciao)
        {
            System.Console.WriteLine(item.Key);
            System.Console.WriteLine(item.Count());
        }
    }
    static void Q5()
    {
        var gigi = Albums.Where(a => a.AnnoUscita < 1990).ToList();
        foreach (var item in gigi)
        {
            System.Console.WriteLine(item.Titolo);
        }
    }
    static void Q6(string genere)
    {
        var hey = Artisti.Join(Albums,
        a => a.ArtistaId,
        al => al.ArtistaId,
        (a, al) => new { id = al.AlbumId,gene = a.GenereMusicale, tit = al.Titolo }).Join(Canzoni,
        al => al.id,
        c => c.AlbumId,
        (al,c) => new {tit = c.Titolo, gene = al.gene, }).Where(a => a.gene == genere).ToList();
        foreach (var item in hey)
        {
            System.Console.WriteLine(item.tit);
        }
    }
    static void Q7()
    {
        var tit = Canzoni.GroupBy(a => a.DurataMinuti).Max();
        System.Console.WriteLine(tit);
    }
    static void Main(string[] args)
    {
        Q7();
        Console.ReadKey();
    }
}