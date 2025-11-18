using System;

namespace EsempioCars1.Model;

public class RecordOfSale
{
    public int RecordOfSaleId { get; set; }
    public DateTime DateSold { get; set; }
    public decimal Price { get; set; }

    public string CarState { get; set; }   // fk
    public string CarLicensePlate { get; set; }  // fk
    public Car Car { get; set; }
}