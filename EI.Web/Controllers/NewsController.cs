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
    [RoutePrefix("api/news")]
    public class NewsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<News> _newsRepository;

        public NewsController(IEntityBaseRepository<News> newsRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _newsRepository = newsRepository;
        }

        [AllowAnonymous]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            List<News> news;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                news = _newsRepository.GetAll().OrderByDescending(m => m.ID).ToList();
                
                IEnumerable<NewsViewModel> newsVM = Mapper.Map<IEnumerable<News>, IEnumerable<NewsViewModel>>(news);

                response = request.CreateResponse<IEnumerable<NewsViewModel>>(HttpStatusCode.OK, newsVM);

                return response;
            });
        }
    }
}