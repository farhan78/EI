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
    [RoutePrefix("api/freeDownloads")]
    public class FreeDownloadsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<FreeDownload> _freeDownloadRepository;

        public FreeDownloadsController(IEntityBaseRepository<FreeDownload> freeDownloadRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _freeDownloadRepository = freeDownloadRepository;
        }

        [AllowAnonymous]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            List<FreeDownload> freeDownloads;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                freeDownloads = _freeDownloadRepository.GetAll().OrderBy(m => m.Order).ToList();
                
                IEnumerable<FreeDownloadViewModel> freeDownloadVM = Mapper.Map<IEnumerable<FreeDownload>, IEnumerable<FreeDownloadViewModel>>(freeDownloads);

                response = request.CreateResponse<IEnumerable<FreeDownloadViewModel>>(HttpStatusCode.OK, freeDownloadVM);

                return response;
            });
        }
    }
}