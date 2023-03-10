using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Models;
using System.Data.Common;

namespace StudentAdminPortal.API.Data
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions<StudentAdminContext> options) :base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Gender> Gender { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
