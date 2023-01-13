using AutoMapper;
using StudentAdminPortal.API.DomainModels;

namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class AddStudentRequestafterMap : IMappingAction<AddStudentRequest, Models.Student>
    {
        public void Process(AddStudentRequest source, Models.Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new Models.Address()
            {
                Id = Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
