using System;

namespace ES_sqlit.model;

public class Autore
{
    public int AutoreId { get; set; }
    public string Nome { get; set; }
    public string Cognome { get; set; }
    public DateOnly DataNascita { get; set; }
    public List<Libro> ListaLibri { get; set; } = [];

}
