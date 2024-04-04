using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSMediatR.ApiGateway.Api.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public string StudentClass { get; set; } = null!;
        public int StudentAge { get; set; }
    }
}
