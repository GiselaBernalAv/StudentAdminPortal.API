using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Data;
using StudentAdminPortal.API.Models;
using System.Reflection.Metadata.Ecma335;

namespace StudentAdminPortal.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext _studentContext;
        public StudentRepository(StudentAdminContext studentContext)
        {
            _studentContext = studentContext;   
        }

        public async Task<Student> AddStudent(Student student)
        {
            var studentadded = await _studentContext.Students.AddAsync(student);
            await _studentContext.SaveChangesAsync();
            return studentadded.Entity;
        }

        public async Task<Student> DeleteStudent(Guid id)
        {
            var existingStudent = await GetStudentbyId(id);
            if (existingStudent != null)
            {
                _studentContext.Students.Remove(existingStudent);
                await _studentContext.SaveChangesAsync();
                return existingStudent;
            }
            return null;  
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

        public async Task<Student> ModifyStudent(Guid id, Student studentRequest)
        {
            var existingStudent = await GetStudentbyId(id);
            if(existingStudent != null)
            {
                existingStudent.FirstName = studentRequest.FirstName;
                existingStudent.LastName = studentRequest.LastName;
                existingStudent.Email = studentRequest.Email;
                existingStudent.Mobile = studentRequest.Mobile;
                existingStudent.DateOfBirth = studentRequest.DateOfBirth;
                existingStudent.GenderId = studentRequest.GenderId;
                existingStudent.Address.PhysicalAddress = studentRequest.Address.PhysicalAddress;
                existingStudent.Address.PostalAddress = studentRequest.Address.PostalAddress;

                await _studentContext.SaveChangesAsync();
                return existingStudent;

            }
            return null;
        }

        public async Task<bool> UpdateProfileImage(Guid id, string profileImageurl)
        {
            var student = await GetStudentbyId(id);

            if (student != null)
            {
                student.ProfileImageUrl = profileImageurl;
                await _studentContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
