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
    [RoutePrefix("api/models")]
    public class ModelsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Model> _modelsRepository;

        public ModelsController(IEntityBaseRepository<Model> modelsRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _modelsRepository = modelsRepository;
        }

        [AllowAnonymous]
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            List<Model> models;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                models = _modelsRepository.GetAll().OrderByDescending(m => m.ID).ToList();

                IEnumerable<ModelViewModel> modelsVM = Mapper.Map<IEnumerable<Model>, IEnumerable<ModelViewModel>>(models);

                response = request.CreateResponse<IEnumerable<ModelViewModel>>(HttpStatusCode.OK, modelsVM);

                return response;
            });
        }
    }
}