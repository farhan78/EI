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
    [RoutePrefix("api/events")]
    public class EventsController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Event> _eventsRepository;

        public EventsController(IEntityBaseRepository<Event> eventsRepository,
            IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _eventsRepository = eventsRepository;
        }

        [AllowAnonymous]
        [Route("gallery")]
        public HttpResponseMessage GetGallery(HttpRequestMessage request)
        {
            List<Event> events;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                events = _eventsRepository.FindBy(e => e.HasAlbum).OrderByDescending(m => m.ID).ToList();

                IEnumerable<EventViewModel> eventsVM = Mapper.Map<IEnumerable<Event>, IEnumerable<EventViewModel>>(events);

                response = request.CreateResponse<IEnumerable<EventViewModel>>(HttpStatusCode.OK, eventsVM);

                return response;
            });
        }

        [AllowAnonymous]
        [Route("list")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            List<Event> events;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                events = _eventsRepository.GetAll().OrderByDescending(m => m.ID).ToList();

                IEnumerable<EventViewModel> eventsVM = Mapper.Map<IEnumerable<Event>, IEnumerable<EventViewModel>>(events);

                response = request.CreateResponse<IEnumerable<EventViewModel>>(HttpStatusCode.OK, eventsVM.OrderByDescending(e => e.EventPeriod));

                return response;
            });
        }
    }
}