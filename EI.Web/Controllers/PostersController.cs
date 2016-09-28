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
    [RoutePrefix("api/posters")]
    public class PostersController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Poster> _postersRepository;

        public PostersController(IEntityBaseRepository<Poster> postersRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _postersRepository = postersRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request, int after)
        {
            List<Poster> posters;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (after != 0)
                {
                    posters = _postersRepository.FindBy(e => e.ID < after).OrderByDescending(m => m.ID).Take(9).ToList();
                }
                else
                {
                    posters = _postersRepository.GetAll().OrderByDescending(m => m.ID).Take(9).ToList();
                }

                IEnumerable<PosterViewModel> postersVM = Mapper.Map<IEnumerable<Poster>, IEnumerable<PosterViewModel>>(posters);

                response = request.CreateResponse<IEnumerable<PosterViewModel>>(HttpStatusCode.OK, postersVM);

                return response;
            });
        }
    }
}