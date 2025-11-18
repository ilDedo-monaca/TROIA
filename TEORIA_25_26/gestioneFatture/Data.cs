using System;
using GestioneFatture.Model;
using Microsoft.EntityFrameworkCore;

namespace GestioneFatture.Data;

public class FattureClientiContext:DbContext
{
    public DbSet<Cliente> Clienti { get; set; }=null!;
    public DbSet<Fattura> Fatture { get; set; }=null!;
    public string DbPath;
    public FattureClientiContext()
    {
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "../../../Fatture.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}