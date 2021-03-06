﻿using AutoMapper;
using EI.Entities;
using EI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EI.Web.Infrastructure.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Event, EventViewModel>();
            Mapper.CreateMap<Poster, PosterViewModel>();
            Mapper.CreateMap<News, NewsViewModel>();
            Mapper.CreateMap<Report, ReportViewModel>();
            Mapper.CreateMap<Book, BookViewModel>();
            Mapper.CreateMap<Quote, QuoteViewModel>();
            Mapper.CreateMap<Leaflet, LeafletViewModel>()
                    .ForMember(l => l.CategoryName, opt => opt.MapFrom(s => s.LeafletCategory.Category));
            Mapper.CreateMap<FreeDownload, FreeDownloadViewModel>();
            Mapper.CreateMap<Model, ModelViewModel>();
        }
    }
}