using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace Cars.model;

public class Moto
{
    [Key]
    public int Codice { get; set; }
    public string Marca { get; set; }
    public string Modello{ get; set; }
}
