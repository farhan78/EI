using System;
using System.Data;
using System.Configuration;
using System.Web;


/// <summary>
/// Summary description for InvoiceItem
/// </summary>
public class InvoiceItem
{
    private string _invoiceId = "";
    public string InvoiceId { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }
    public bool Promotion { get; set; }
    public string ProductName { get; set; }
    public string Type { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal HandlingCost { get; set; }
    
    public InvoiceItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void UpdateQuantity(int quantity)
    {
        this.Quantity = quantity;
    }

    public void AddToQuantity(int quantity)
    {
        this.Quantity += quantity;
    }
}
