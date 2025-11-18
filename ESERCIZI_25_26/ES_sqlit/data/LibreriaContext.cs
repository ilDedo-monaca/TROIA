using System;
using ES_sqlit.model;
using Microsoft.EntityFrameworkCore;

namespace ES_sqlit.data;

public class LibreriaContext:DbContext
{
    public DbSet<Autore> Autori { get; set; }
    public DbSet<Libro> Libri { get; set; }
    string path;
    public LibreriaContext()
    {
        var folder = AppContext.BaseDirectory;
        path = Path.Combine(folder, "../../../Libreria.db");
    }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={path}");
    }
}
