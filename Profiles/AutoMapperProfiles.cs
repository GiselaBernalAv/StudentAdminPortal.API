using AutoMapper;

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
        }
    }
}
