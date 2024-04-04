using CQRSMediatR.Microservices.StudentApi.Model;

namespace CQRSMediatR.Microservices.StudentApi.Services
{
    public interface IStudentService
    {
        // Query
        Task<List<Student>> GetStudents();
        Task<Student> GetStudent(int id);

        //Commands
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(int id, Student student);
        Task<Student> DeleteStudent(int id);
    }
}
