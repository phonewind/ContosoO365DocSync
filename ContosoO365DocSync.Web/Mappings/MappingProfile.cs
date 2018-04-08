using AutoMapper;
using ContosoO365DocSync.Entity;
using ContosoO365DocSync.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoO365DocSync.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainViewModelMappings";
            }
        }

        public MappingProfile()
        {
            CreateMap<SourcePointForm, SourcePoint>();
            CreateMap<DestinationPointForm, DestinationPoint>()
                .ForMember(dest => dest.ReferencedSourcePoint, opt => opt.MapFrom(source => new SourcePoint() { Id = Guid.Parse(source.SourcePointId) }))
                .ForMember(dest => dest.CustomFormats, opt => opt.MapFrom(source => source.CustomFormatIds.Select(o => new CustomFormat() { Id = o })));
        }
    }
}