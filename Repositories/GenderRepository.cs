using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Data;
using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly StudentAdminContext _studentContext;
        public GenderRepository(StudentAdminContext studentContext)
        {
            _studentContext = studentContext;
        }
        public async Task<List<Gender>> GetAllGenders()
        {
            return await _studentContext.Gender.ToListAsync();
        }

        public async Task<Gender> GetGenderbyId(Guid id)
        {
            return await _studentContext.Gender
              .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
