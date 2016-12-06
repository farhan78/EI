using EI.Data.Infrastructure;
using EI.Data.Repositories;
using EI.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using EI.Web.Infrastructure.Extensions;

namespace EI.Web.Infrastructure.Core
{
    public class ApiControllerBaseExtended : ApiController
    {
        protected List<Type> _requiredRepositories;
        protected IEntityBaseRepository<Event> _eventsRepository;
        protected IEntityBaseRepository<Poster> _postersRepository;
        protected IEntityBaseRepository<News> _newsRepository;
        protected IEntityBaseRepository<Report> _reportsRepository;
        protected IEntityBaseRepository<Book> _booksRepository;
        protected readonly IDataRepositoryFactory _dataRepositoryFactory;
        protected IEntityBaseRepository<Error> _errorsRepository;
        protected IUnitOfWork _unitOfWork;

        private HttpRequestMessage RequestMessage;

        public ApiControllerBaseExtended(IDataRepositoryFactory dataRepositoryFactory, IUnitOfWork unitOfWork)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
            _unitOfWork = unitOfWork;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, List<Type> repos, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;

            try
            {
                RequestMessage = request;
                InitRepositories(repos);
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        
        private void InitRepositories(List<Type> entities)
        {
            _errorsRepository = _dataRepositoryFactory.GetDataRepository<Error>(RequestMessage);

            if (entities.Any(e => e.FullName == typeof(Event).FullName))
            {
                _eventsRepository = _dataRepositoryFactory.GetDataRepository<Event>(RequestMessage);
            }

            if (entities.Any(e => e.FullName == typeof(Poster).FullName))
            {
                _postersRepository = _dataRepositoryFactory.GetDataRepository<Poster>(RequestMessage);
            }

            if (entities.Any(e => e.FullName == typeof(News).FullName))
            {
                _newsRepository = _dataRepositoryFactory.GetDataRepository<News>(RequestMessage);
            }

            if (entities.Any(e => e.FullName == typeof(Report).FullName))
            {
                _reportsRepository = _dataRepositoryFactory.GetDataRepository<Report>(RequestMessage);
            }

            if (entities.Any(e => e.FullName == typeof(Book).FullName))
            {
                _booksRepository = _dataRepositoryFactory.GetDataRepository<Book>(RequestMessage);
            }
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error _error = new Error()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateCreated = DateTime.Now
                };

                _errorsRepository.Add(_error);
                _unitOfWork.Commit();
            }
            catch { }
        }
    }
}