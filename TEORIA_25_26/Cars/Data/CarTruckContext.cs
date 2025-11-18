using System;
using Cars.model;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data;

public class CarTruckContext:DbContext
{
    public string DbPath;
    public DbSet<Car> Auto { get; set; }
    public DbSet<Truck> Camion { get; set; }
    public DbSet<Moto> Moto { get; set; }
    public DbSet<Moto2Chiavi> Moto2Chiavi { get; set; }
    public CarTruckContext()
    {
        var folder = AppContext.BaseDirectory;
        var path = Path.Combine(folder, "../../../CarTruck.db");
        DbPath = path;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Moto2Chiavi>().HasKey(c => new{c.Codice, c.Codice1});
    }
}
