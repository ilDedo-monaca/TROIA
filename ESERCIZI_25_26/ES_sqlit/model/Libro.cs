using System;
using SQLitePCL;

namespace ES_sqlit.model;

public class Libro
{
    public int LibroId { get; set; }
    public string Titolo { get; set; }
    public int Anno { get; set; }
    public int Pagine { get; set; }
    public int AutoreId { get; set; }
    public Autore autore { get; set; }
}
