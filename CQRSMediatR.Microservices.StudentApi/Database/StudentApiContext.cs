using CQRSMediatR.Microservices.StudentApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatR.Microservices.StudentApi.Database
{
    public class StudentApiContext : DbContext
    {
        public StudentApiContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
