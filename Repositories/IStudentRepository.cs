using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();

        Task<Student> GetStudentbyId(Guid id);
    }
}
