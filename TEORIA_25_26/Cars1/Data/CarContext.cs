using System;
using EsempioCars1.Model;
using Microsoft.EntityFrameworkCore;

namespace EsempioCars1.Data;

public class CarContext :DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<RecordOfSale> RecordOfSales { get; set; }
    string path;
    public CarContext()
    {
        var folder = AppContext.BaseDirectory;
        path = Path.Combine(folder, "../../../Cars1.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={path}");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().HasKey(c=>new{c.State,c.LicensePlate});
        modelBuilder.Entity<RecordOfSale>()
            .HasOne(s => s.Car)
            .WithMany(c => c.SaleHistory)
            .HasForeignKey(s => new { s.CarState, s.CarLicensePlate });
    }
}