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
    [RoutePrefix("api/leaflets")]
    public class LeafletsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Leaflet> _leafletsRepository;

        public LeafletsController(IEntityBaseRepository<Leaflet> leafletsRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _leafletsRepository = leafletsRepository;
        }

        [AllowAnonymous]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            List<Leaflet> leaflets;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                leaflets = _leafletsRepository.AllIncluding(l => l.LeafletCategory).ToList();

                IEnumerable<LeafletViewModel> leafletsVM = Mapper.Map<IEnumerable<Leaflet>, IEnumerable<LeafletViewModel>>(leaflets);

                response = request.CreateResponse<IEnumerable<LeafletViewModel>>(HttpStatusCode.OK, leafletsVM.OrderBy(e => e.CategoryName));

                return response;
            });
        }
    }
}