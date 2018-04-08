using AutoMapper;
using ContosoO365DocSync.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Service
{
    public class ServiceMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainModelMappings";
            }
        }

        public ServiceMappingProfile()
        {
            CreateMap<SourcePoint, PublishedHistory>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.PublishedUser, opt => opt.MapFrom(source => source.Creator))
                .ForMember(dest => dest.PublishedDate, opt => opt.MapFrom(source => source.Created));
            CreateMap<PublishStatusEntity, PublishStatusItem>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(source => source.Status.ToString()));
        }
    }
}
