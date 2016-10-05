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
    [RoutePrefix("api/reports")]
    public class ReportsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Report> _reportsRepository;

        public ReportsController(IEntityBaseRepository<Report> reportsRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _reportsRepository = reportsRepository;
        }

        [AllowAnonymous]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            List<Report> reports;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                reports = _reportsRepository.GetAll().OrderByDescending(m => m.ID).ToList();

                IEnumerable<ReportViewModel> reportsVM = Mapper.Map<IEnumerable<Report>, IEnumerable<ReportViewModel>>(reports);

                response = request.CreateResponse<IEnumerable<ReportViewModel>>(HttpStatusCode.OK, reportsVM);

                return response;
            });
        }
    }
}