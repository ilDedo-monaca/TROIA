using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClasseStudente.Model;

public class Studente
{
    [Key]
    public int Matricola { get; set; }
    public string Nome { get; set; } = null!;
    public string Cognome { get; set; } = null!;
    public int FKClasse { get; set; }
    [ForeignKey("FKClasse")]
    public Classe Classe { get; set; }
}
