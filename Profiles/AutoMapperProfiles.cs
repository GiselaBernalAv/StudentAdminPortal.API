using AutoMapper;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using StudentAdminPortal.API.Profiles.AfterMaps;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DomainModels.Student, Models.Student>()
                    .ReverseMap();

            CreateMap<DomainModels.Address, Models.Address>()
                    .ReverseMap();

            CreateMap<DomainModels.Gender, Models.Gender>()
                    .ReverseMap();

            CreateMap<DomainModels.UpdateStudentRequest, Models.Student>()
              //  .ForMember(dest => dest.Address.PhysicalAddress, opt => opt.MapFrom(src => src.PhysicalAddress))
              //  .ForMember(dest => dest.Address.PostalAddress, opt => opt.MapFrom(src => src.PostalAddress));
              .AfterMap<UpdateStudentRequestAfterMap>();

            CreateMap<DomainModels.AddStudentRequest, Models.Student>()
                .AfterMap<AddStudentRequestafterMap>();
        }
    }
}
