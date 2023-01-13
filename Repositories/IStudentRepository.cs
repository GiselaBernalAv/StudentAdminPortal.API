using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();

        Task<Student> GetStudentbyId(Guid id);

        Task<Student> ModifyStudent(Guid id, Student student);

        Task<Student> DeleteStudent(Guid id);

        Task<Student> AddStudent(Student student);
    }
}
