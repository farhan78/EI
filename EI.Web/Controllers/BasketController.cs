using AutoMapper;
using EI.Data.Infrastructure;
using EI.Data.Repositories;
using EI.Entities;
using EI.Web.Infrastructure.Core;
using EI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EI.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/sessions/basket")]
    public class BasketController : System.Web.Http.ApiController
    {
        private readonly IEntityBaseRepository<Book> _booksRepository;
        private readonly IEntityBaseRepository<Leaflet> _leafletsRepository;

        public BasketController(IEntityBaseRepository<Book> booksRepository, IEntityBaseRepository<Leaflet> leafletsRepository)
        {
            _booksRepository = booksRepository;
            _leafletsRepository = leafletsRepository;
        }

        [AllowAnonymous]
        [Route("content")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;

            response = request.CreateResponse(HttpStatusCode.OK, SelectedInvoice);

            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, int id, string type, int qty)
        {
            bool foundInvoiceItem = false;

            foreach (InvoiceItem x in SelectedInvoice.InvoiceItems)
            {
                if (x.ProductId == id)
                {
                    x.Quantity += qty;
                    if (x.Quantity <= 0)
                    {
                        RemoveProduct(id, type);
                    }
                    foundInvoiceItem = true;
                    break;
                }
            }

            if (!foundInvoiceItem && qty > 0)
            {
                InvoiceItem invItem = new InvoiceItem();
                Product product = new Product();

                if (type == "Book")
                {
                    var book = _booksRepository.GetSingle(id);
                    invItem.ProductId = book.ID;
                    invItem.ProductName = book.Name;
                    invItem.ImageUrl = book.ImageUrl;
                    invItem.Quantity = qty;
                    if (book.SpecialOfferPrice == 0)
                    {
                        invItem.Price = book.Price * qty;
                        invItem.Promotion = false;
                        invItem.UnitPrice = book.Price;
                    }
                    else
                    {
                        invItem.Price = book.SpecialOfferPrice * qty;
                        invItem.Promotion = false;
                        invItem.UnitPrice = book.SpecialOfferPrice;
                    }
                    
                    invItem.ShippingCost = book.PostagePrice;
                    invItem.HandlingCost = book.PostagePrice;
                    invItem.Type = "Book";

                }
                else if (type == "Leaflet")
                {
                    var leaflet = _leafletsRepository.GetSingle(id);
                    invItem.ProductId = leaflet.ID;
                    invItem.ProductName = leaflet.Name;
                    invItem.ImageUrl = leaflet.ImageUrl;
                    invItem.Quantity = qty;
                    if (leaflet.SpecialOfferPrice == 0)
                    {
                        invItem.Price = leaflet.Price * qty;
                        invItem.Promotion = false;
                        invItem.UnitPrice = leaflet.Price;
                    }
                    else
                    {
                        invItem.Price = leaflet.SpecialOfferPrice * qty;
                        invItem.Promotion = false;
                        invItem.UnitPrice = leaflet.SpecialOfferPrice;
                    }
                 
                    invItem.ShippingCost = leaflet.PostagePrice;
                    invItem.HandlingCost = leaflet.PostagePrice;
                    invItem.Type = "Leaflet";
                }

                SelectedInvoice.InvoiceItems.Add(invItem);
            }

            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Created);

            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("updateQuantity")]
        public HttpResponseMessage UpdateQuantity(HttpRequestMessage request, int productId, int qty, string type)
        {
            if (qty <= 0)
            {
                qty = 0;
                RemoveProduct(productId, type);
            }
            else
            {
                foreach (InvoiceItem x in SelectedInvoice.InvoiceItems)
                {
                    if (x.ProductId == productId && x.Type == type)
                    {
                        x.Quantity = qty;
                        break;
                    }
                }
            }

            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Created);

            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("removeItem")]
        public HttpResponseMessage RemoveItem(HttpRequestMessage request, int productId, string type)
        {
            RemoveProduct(productId, type);

            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Created);

            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("clear")]
        public HttpResponseMessage Clear(HttpRequestMessage request)
        {
            SelectedInvoice.EmptyCart();
            System.Web.HttpContext.Current.Session["Invoice"] = SelectedInvoice;

            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

        public void RemoveProduct(int productId, string type)
        {
            foreach (InvoiceItem x in SelectedInvoice.InvoiceItems)
            {
                if (x.ProductId == productId && x.Type == type)
                {
                    SelectedInvoice.InvoiceItems.Remove(x);
                    break;
                }
            }
        }

        private Invoice _selectedInvoice = new Invoice();
        public Invoice SelectedInvoice
        {
            get
            {
                if (_selectedInvoice.InvoiceId == "")
                {
                    try
                    {
                        _selectedInvoice = (Invoice)System.Web.HttpContext.Current.Session["Invoice"];
                    }
                    catch { }
                }
                return _selectedInvoice;
            }
        }
    }
}