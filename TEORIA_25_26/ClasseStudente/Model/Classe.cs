using System;

namespace ClasseStudente.Model;

public class Classe
{
    public int ClasseId { get; set; }
    public string Nome { get; set; }=null!;
    public int? Superficie { get; set; }
    public List<Studente> Studenti {get; set;}= []; 
}
