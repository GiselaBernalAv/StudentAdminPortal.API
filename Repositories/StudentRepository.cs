using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Data;
using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext _studentContext;
        public StudentRepository(StudentAdminContext studentContext)
        {
            _studentContext = studentContext;   
        }

        public async Task<Student> GetStudentbyId(Guid id)
        {
            return await _studentContext.Students
                .Include(x => x.Gender)
                .Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _studentContext.Students
            .Include(x=>x.Gender)
            .Include(x=>x.Address).ToListAsync();

        }
    }
}
