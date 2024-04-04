using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSMediatR.Microservices.StudentApi.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }        
        [Column]
        public int StudentId { get; set; }
        [Column]
        public string StudentName { get; set; } = null!;
        [Column]
        public string StudentClass { get; set; } = null!;
        [Column]
        public int StudentAge { get; set; }
    }
}
