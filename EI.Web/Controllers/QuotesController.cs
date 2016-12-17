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
    [RoutePrefix("api/quotes")]
    public class QuotesController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Quote> _quotesRepository;

        public QuotesController(IEntityBaseRepository<Quote> quotesRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _quotesRepository = quotesRepository;
        }

        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            List<Quote> quotes;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                quotes = _quotesRepository.GetAll().OrderByDescending(m => m.ID).ToList();

                IEnumerable<QuoteViewModel> quotesVM = Mapper.Map<IEnumerable<Quote>, IEnumerable<QuoteViewModel>>(quotes);

                response = request.CreateResponse<IEnumerable<QuoteViewModel>>(HttpStatusCode.OK, quotesVM);

                return response;
            });
        }

        [AllowAnonymous]
        public HttpResponseMessage GetRandom(HttpRequestMessage request)
        {
            List<Quote> quotes;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                quotes = _quotesRepository.GetAll().OrderByDescending(m => m.ID).ToList();

                Random rnd = new Random();
                int r = rnd.Next(quotes.Count);

                QuoteViewModel quoteVM = Mapper.Map<Quote, QuoteViewModel>(quotes[r]);

                response = request.CreateResponse<QuoteViewModel>(HttpStatusCode.OK, quoteVM);

                return response;
            });
        }
    }
}