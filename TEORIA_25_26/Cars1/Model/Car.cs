using System;

namespace EsempioCars1.Model;

public class Car
{
    public string State { get; set; } //pk
    public string LicensePlate { get; set; }   //Pk
    public string Make { get; set; }
    public string Model { get; set; }

    public List<RecordOfSale> SaleHistory { get; set; }
}