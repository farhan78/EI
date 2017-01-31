using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Collections;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Summary description for Invoice
/// </summary>
public class Invoice
{
    private string _customerComments = "";
    public string CustomerComments
    {
        get
        {
            return _customerComments;
        }
        set
        {
            _customerComments = value.Trim();
        }
    }

    private List<InvoiceItem> _invoiceItems = new List<InvoiceItem>();
    public List<InvoiceItem> InvoiceItems
    {
        get
        {
            return _invoiceItems;
        }
        set
        {
            _invoiceItems = value;
        }
    }

    private string _currency = "GBP"; //currency to display in
    public string Currency
    {
        get
        {
            return _currency;
        }
        set
        {
            if (value == null || value.Trim() == "")
            {
                _currency = "GBP";
            }
            else
            {
                _currency = value.ToUpper();
            }
        }
    }


    private string _invoiceId = "";
    /// <summary>
    /// Same as session Id (unless pulling from database)
    /// </summary>
    public string InvoiceId
    {
        get
        {
            return _invoiceId;
        }
        set
        {
            _invoiceId = value;
        }
    }

    public string ProductNames
    {
        get
        {
            string productNames = "";
            foreach (InvoiceItem x in _invoiceItems)
            {
                productNames += x.ProductName.Trim() + ", ";

            }
            if (productNames.Length > 2)
            {
                productNames = productNames.Substring(0, productNames.Length - 2);
            }
            return productNames;
        }
    }

    /// <summary>
    /// RETURNS the HTML Encoded version of the Invoice data
    ///   May be useful in emails or displays of invoice
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        StringBuilder invoiceHtml = new StringBuilder();
        invoiceHtml.Append("<b>INVOICE : ").Append(this.InvoiceId.ToString()).Append("</b><br />");
        invoiceHtml.Append("<b>DATE : </b>").Append(DateTime.Now.ToShortDateString()).Append("<br />");
        invoiceHtml.Append("<b>Invoice Amt :</b> £").Append(this.Total.ToString("#.00")).Append("<br />");

        invoiceHtml.Append("<br /><b>CUSTOMER CONTACT INFO:</b><br />");
        invoiceHtml.Append("<b>Name : </b>").Append(this.ContactName).Append("<br />");
        invoiceHtml.Append("<b>Phone : </b>").Append(this.ContactPhone).Append("<br />");
        invoiceHtml.Append("<b>Email : </b>").Append(this.ContactEmail).Append("<br />");
        invoiceHtml.Append("<b>Address : </b><br />").Append(this.ContactAddress1).Append("<br />");
        invoiceHtml.Append(this.ContactAddress2).Append("<br />");
        invoiceHtml.Append(this.ContactCity).Append(", ").Append(this.ContactStateProvince).Append(" ").Append(this.ContactZip).Append("<br />");
        invoiceHtml.Append("<br /><b>SHIP TO:</b><br />");
        invoiceHtml.Append("<b>Name : </b>").Append(this.ShipToName).Append("<br />");
        invoiceHtml.Append("<b>Address : </b><br />").Append(this.ShipToAddress1).Append("<br />");
        invoiceHtml.Append(this.ShipToAddress2).Append("<br />");
        invoiceHtml.Append(this.ShipToCity).Append(", ").Append(this.ShipToStateProvince).Append(" ").Append(this.ShipToZip).Append("<br />");
        invoiceHtml.Append("<br /><b>PRODUCTS:</b><br /><table><tr><th>Qty</th><th>Product</th></tr>");
        foreach (InvoiceItem x in _invoiceItems)
        {
            invoiceHtml.Append("<tr><td>").Append(x.Quantity.ToString()).Append("</td><td>").Append(x.ProductName).Append("</td></tr>");
        }
        invoiceHtml.Append("</table>");

        return invoiceHtml.ToString();
    }


    /// <summary>
    /// PURPOSE: to write PayPay item list for invoice
    /// </summary>
    public string PaypalItemList
    {
        get
        {
            StringBuilder payPalItems = new StringBuilder();
            int counter = 0;
            bool handlingDone = false;
            foreach (InvoiceItem x in _invoiceItems)
            {
                counter++;
                string itemNameTemplate = "<input type=\"text\" name=\"item_name_$count$\" value=\"$itemName$\" />\n";
                string amountTemplate = "<input type=\"text\" name=\"amount_$count$\" value=\"$amount$\" />\n";
                string qtyTemplate = "<input type=\"text\" name=\"quantity_$count$\" value=\"$quantity$\" />\n";
                string shippingTemplate = "<input type=\"text\" name=\"shipping_$count$\" value=\"$shipping$\" />\n";
                string handlingTemplate = "<input type=\"text\" name=\"handling_$count$\" value=\"$handling$\" />\n\n";

                itemNameTemplate = itemNameTemplate.Replace("$itemName$", x.ProductName).Replace("$count$", counter.ToString());
                amountTemplate = amountTemplate.Replace("$amount$", x.UnitPrice.ToString("#.00")).Replace("$count$", counter.ToString());
                qtyTemplate = qtyTemplate.Replace("$quantity$", x.Quantity.ToString()).Replace("$count$", counter.ToString());
                shippingTemplate = shippingTemplate.Replace("$shipping$", (x.ShippingCost * x.Quantity).ToString("#.00")).Replace("$count$", counter.ToString());

                if (!handlingDone)
                {
                    handlingDone = true;
                    handlingTemplate = handlingTemplate.Replace("$handling$", HandlingCost.ToString("#.00")).Replace("$count$", counter.ToString());
                }
                else
                {
                    handlingTemplate = handlingTemplate.Replace("$handling$", (0M * x.Quantity).ToString("#.00")).Replace("$count$", counter.ToString());
                }

                payPalItems.Append(itemNameTemplate).Append(amountTemplate).Append(qtyTemplate).Append(shippingTemplate).Append(handlingTemplate);
            }

            return payPalItems.ToString();
        }
    }

    /// <summary>
    /// Cost of Unit Prices * qty
    /// </summary>
    public decimal SubTotal
    {
        get
        {
            decimal subtotal = 0.0M;
            foreach (InvoiceItem x in _invoiceItems)
            {
                subtotal += (x.UnitPrice * x.Quantity);
            }
            return subtotal;
        }
    }

    /// <summary>
    /// Retrieve Shipping cost for Invoice
    /// </summary>
    public decimal ShippingCost
    {
        get
        {
            decimal shipping = 0.0M;
            foreach (InvoiceItem x in _invoiceItems)
            {
                shipping += (x.ShippingCost * x.Quantity);
            }
            return shipping;
        }
    }

    /// <summary>
    /// Any Handling costs
    /// </summary>
    public decimal HandlingCost
    {
        get
        {
            decimal handling = 0.0M;
            int bookCount = 0;
            int leafletCount = 0;
            int specialDealCount = 0;
            int specialDealLeafletCount = 0;
            int journeyIslamicFaithCount = 0;
            
            foreach (InvoiceItem x in _invoiceItems)
            {
                if (x.Type == "Book")
                {
                    if (x.ProductId == 32)
                    {
                        specialDealCount += x.Quantity;
                    }
		            else if (x.ProductId == 42)
                    {
                        journeyIslamicFaithCount += x.Quantity;  
                    }
                    else
                    {
                        bookCount += x.Quantity;
                    }
                }
                else if (x.Type == "Leaflet")
                {
                    if (x.ProductId == 65)
                    {
                        specialDealLeafletCount += x.Quantity;
                    }
                    else
                    {
                        leafletCount += x.Quantity;
                    }
                    //handling += (x.HandlingCost * x.Quantity);
                  
                }
            }

            if (leafletCount == 1)
            {
                handling += 1.60M;
            }
            else if (leafletCount == 2)
            {
                handling += 2.95M;
            }
            else if (leafletCount >= 3 && leafletCount <= 5)
            {
                handling += 5.95M;
            }
            else if (leafletCount >= 6 && leafletCount <= 10)
            {
                handling += 6.95M;
            }
            else if (leafletCount >= 11 && leafletCount <= 24)
            {
                handling += 7.95M;
            }
            else if (leafletCount >= 25 && leafletCount <= 40)
            {
                handling += 13.95M;
            }
            else if (leafletCount >= 41 && leafletCount <= 100)
            {
                handling += 23.95M;
            }
            else if (leafletCount >= 101 && leafletCount <= 200)
            {
                handling += 45M;
            }
            else if (leafletCount > 200)
            {
                handling += 45M;
            }

            if (specialDealLeafletCount > 0)
            {
                handling += (decimal)specialDealLeafletCount;
            }

            if (bookCount == 1)
            {
                handling += 4.95M;
            }
            else if (bookCount >= 2 && bookCount <= 10)
            {
                handling += 8.50M;
            }
            else if (bookCount >= 11 && bookCount <= 20)
            {
                handling += 20M;
            }
            else if (bookCount >= 21 && bookCount <= 30)
            {
                handling += 30M;
            }
            else if (bookCount > 30)
            {
                handling += 30;
            }


            if (journeyIslamicFaithCount > 0)
            {
		        handling += 14M * journeyIslamicFaithCount; 
	         }


            // hardcoded postage cost for special deal books
            if (specialDealCount > 0)
            {
                switch (specialDealCount)
                {
                    case 1:
                        handling += 5.95M;
                        break;

                    case 2:
                        handling += 9.95M;
                        break;

                    case 3:
                        handling += 19.00M;
                        break;

                    case 4:
                        handling += 25.00M;
                        break;

                    case 5:
                        handling += 30.00M;
                        break;

                    case 6:
                        handling += 30.00M;
                        break;

                    default:
                        handling += 30.00M;
                        break;
                }
            }

            return handling;
        }
    }

    //public decimal Taxes
    //{
    //    get
    //    {
    //        decimal taxes = 0.0M;
    //        foreach (InvoiceItem x in _invoiceItems)
    //        {
    //            taxes += (x.Taxes);
    //        }
    //        return taxes;
    //    }
    //}

    public decimal Total
    {
        get
        {
            //return this.SubTotal + this.HandlingCost + this.Taxes + this.ShippingCost;
            return this.SubTotal + this.HandlingCost;
        }
    }



    #region Ship To Properties

    private string _shipToName = "";
    public string ShipToName
    {
        get
        {
            return _shipToName;
        }
        set
        {
            _shipToName = value.Trim();
        }
    }

    private string _shipToAddress1 = "";
    public string ShipToAddress1
    {
        get
        {
            return _shipToAddress1;
        }
        set
        {
            _shipToAddress1 = value.Trim();
        }
    }

    private string _shipToAddress2 = "";
    public string ShipToAddress2
    {
        get
        {
            return _shipToAddress2;
        }
        set
        {
            _shipToAddress2 = value.Trim();
        }
    }

    private string _shipToCity = "";
    public string ShipToCity
    {
        get
        {
            return _shipToCity;
        }
        set
        {
            _shipToCity = value.Trim();
        }
    }

    private string _shipToStateProvince = "";
    public string ShipToStateProvince
    {
        get
        {
            return _shipToStateProvince;
        }
        set
        {
            _shipToStateProvince = value.Trim();
        }
    }

    private string _shipToZip = "";
    public string ShipToZip
    {
        get
        {
            return _shipToZip;
        }
        set
        {
            _shipToZip = value.Trim();
        }
    }

    private string _shipToCountry = "UK";
    public string ShipToCountry
    {
        get
        {
            return _shipToCountry;
        }
        set
        {
            _shipToCountry = value.Trim();
        }
    }
    #endregion

    #region Contact Properties

    private string _contactName = "";
    public string ContactName
    {
        get
        {
            return _contactName;
        }
        set
        {
            _contactName = value.Trim();
        }
    }

    private string _contactPhone = "";
    public string ContactPhone
    {
        get
        {
            return _contactPhone;
        }
        set
        {
            _contactPhone = value.Trim();
        }
    }

    private string _contactEmail = "";
    public string ContactEmail
    {
        get
        {
            return _contactEmail;
        }
        set
        {
            _contactEmail = value.Trim();
        }
    }

    private string _contactAddress1 = "";
    public string ContactAddress1
    {
        get
        {
            return _contactAddress1;
        }
        set
        {
            _contactAddress1 = value.Trim();
        }
    }

    private string _contactAddress2 = "";
    public string ContactAddress2
    {
        get
        {
            return _contactAddress2;
        }
        set
        {
            _contactAddress2 = value.Trim();
        }
    }

    private string _contactCity = "";
    public string ContactCity
    {
        get
        {
            return _contactCity;
        }
        set
        {
            _contactCity = value.Trim();
        }
    }

    private string _contactStateProvince = "";
    public string ContactStateProvince
    {
        get
        {
            return _contactStateProvince;
        }
        set
        {
            _contactStateProvince = value.Trim();
        }
    }

    private string _contactZip = "";
    public string ContactZip
    {
        get
        {
            return _contactZip;
        }
        set
        {
            _contactZip = value.Trim();
        }
    }

    private string _contactCountry = "UK";
    public string ContactCountry
    {
        get
        {
            return _contactCountry;
        }
        set
        {
            _contactCountry = value.Trim();
        }
    }

    #endregion


    public Invoice()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Invoice(string invoiceId)
    {
        this.InvoiceId = invoiceId;
    }

    public void EmptyCart()
    {
        _invoiceItems = new List<InvoiceItem>();
    }

    ///// <summary>
    ///// Adding another item to the cart (may be one there already - dont know)
    ///// </summary>
    ///// <param name="productId"></param>
    ///// <param name="qty"></param>
    //public void AddToInvoice(int productId, int qty, string type)
    //{
    //    bool foundInvoiceItem = false;

    //    foreach (InvoiceItem x in _invoiceItems)
    //    {
    //        if (x.ProductId == productId)
    //        {
    //            x.Quantity += qty;
    //            if (x.Quantity <= 0)
    //            {
    //                RemoveProduct(productId, type);
    //            }
    //            foundInvoiceItem = true;
    //            break;
    //        }
    //    }

    //    if (!foundInvoiceItem && qty > 0)
    //    {
    //        InvoiceItem invItem = new InvoiceItem(this.InvoiceId, productId, qty, type);
    //        _invoiceItems.Add(invItem);
    //    }
    //}



    /// <summary>
    /// Updating Invoice Quantity
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="qty"></param>
    //public void UpdateProductQuantity(int productId, int qty, string type)
    //{
    //    if (qty <= 0)
    //    {
    //        qty = 0;
    //        RemoveProduct(productId, type);
    //    }
    //    else
    //    {
    //        foreach (InvoiceItem x in _invoiceItems)
    //        {
    //            if (x.ProductId == productId && x.Type == type)
    //            {
    //                x.Quantity = qty;
    //                break;
    //            }
    //        }
    //    }
    //}

    //public void RemoveProduct(int productId, string type)
    //{
    //    foreach (InvoiceItem x in _invoiceItems)
    //    {
    //        if (x.ProductId == productId && x.Type == type)
    //        {
    //            InvoiceItems.Remove(x);
    //            break;
    //        }
    //    }
    //}



}
