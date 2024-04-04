using CQRSMediatR.Microservices.StudentApi.Database;
using CQRSMediatR.Microservices.StudentApi.Model;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CQRSMediatR.Microservices.StudentApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentApiContext _context;
        private readonly ILogger<StudentService> _logger;
        public StudentService(StudentApiContext context, ILogger<StudentService> logger)
        {
            _context = context;
             _logger = logger;
        }

        public Task<List<Student>> GetStudents()
        {
            return _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            var student =  await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(student is null){
                throw new Exception("Student Not Found");
            }
            return student;
        }

        public async Task<Student> AddStudent(Student _student)
        {
            try
            {
                _context.Students.Add(_student);
                await _context.SaveChangesAsync();

                return _student;
            }
            catch (Exception ex) { 
                _logger.LogError($"ERROR is Service {ex}");
                throw;
            }

        }

        public async Task<Student> DeleteStudent(int id)
        {
            var _studentInDb = await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (_studentInDb == null)
                throw new Exception("Student not found");

            _context.Students.Remove(_studentInDb);
            await _context.SaveChangesAsync();

            return _studentInDb;
        }

        public async Task<Student> UpdateStudent(int id, Student _student)
        {
            var _studentInDb = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (_studentInDb == null)
                throw new Exception("Student not found");

            _studentInDb.StudentId = _student.StudentId;
            _studentInDb.StudentName = _student.StudentName;
            _studentInDb.StudentClass = _studentInDb.StudentClass;
            _studentInDb.StudentAge = _studentInDb.StudentAge;

            await _context.SaveChangesAsync();

            return _studentInDb;
        }
    }
}
