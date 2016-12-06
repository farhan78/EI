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
    [RoutePrefix("api/books")]
    public class BooksController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Book> _booksRepository;

        public BooksController(IEntityBaseRepository<Book> booksRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _booksRepository = booksRepository;
        }

        [AllowAnonymous]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            List<Book> books;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                books = _booksRepository.GetAll().ToList();

                IEnumerable<BookViewModel> booksVM = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);

                response = request.CreateResponse<IEnumerable<BookViewModel>>(HttpStatusCode.OK, booksVM.OrderBy(e => e.Order));

                return response;
            });
        }
    }
}