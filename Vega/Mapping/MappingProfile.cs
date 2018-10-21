using AutoMapper;
using System.Linq;
using Vega.Controllers.Resources;
using Vega.Models;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
               .ForMember(v => v.Contact, opt => opt.MapFrom(v => new ContactResource { ContactName = v.ContactName, ContactEmail = v.ContactEmail, ContactPhone = v.ContactPhone }))
                 .ForMember(v => v.Features, opt => opt.MapFrom(v => v.VehicleFeatures.Select(vf => vf.FeatureId)));
            //API Resource to Domain Resource
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v=>v.Id,opt=>opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(v => v.Contact.ContactName))
                   .ForMember(v => v.ContactEmail, opt => opt.MapFrom(v => v.Contact.ContactEmail))
                      .ForMember(v => v.ContactPhone, opt => opt.MapFrom(v => v.Contact.ContactPhone))
                         .ForMember(v => v.VehicleFeatures, opt => opt.MapFrom(v => v.Features.Select(id => new VehicleFeature { FeatureId = id })));
        }
    }
}