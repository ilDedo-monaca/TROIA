using System;
using ClasseStudente.Model;
using Microsoft.EntityFrameworkCore;

namespace ClasseStudente.Data;

public class StudClassContext:DbContext
{
    public DbSet<Classe> Classe { get; set; }
    public DbSet<Studente> Studente { get; set; }
    string path;
    public StudClassContext()
    {
        var folder = AppContext.BaseDirectory;
        path = Path.Combine(folder, "../../../StudClasse.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlite($"Data Source = {path}");
    }
}
