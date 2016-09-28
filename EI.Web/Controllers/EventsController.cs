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
        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request, int after)
        {
            List<Event> events;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (after != 0)
                {
                    events = _eventsRepository.FindBy(e => e.HasAlbum && e.ID < after).OrderByDescending(m => m.ID).Take(9).ToList();
                }
                else
                {
                    events = _eventsRepository.FindBy(e => e.HasAlbum).OrderByDescending(m => m.ID).Take(9).ToList();
                }

                IEnumerable<EventViewModel> eventsVM = Mapper.Map<IEnumerable<Event>, IEnumerable<EventViewModel>>(events);

                response = request.CreateResponse<IEnumerable<EventViewModel>>(HttpStatusCode.OK, eventsVM);

                return response;
            });
        }
    }
}