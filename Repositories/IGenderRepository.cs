using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Repositories
{
    public interface IGenderRepository
    {

        Task<List<Gender>> GetAllGenders();

        Task<Gender> GetGenderbyId(Guid id);
    }
}
