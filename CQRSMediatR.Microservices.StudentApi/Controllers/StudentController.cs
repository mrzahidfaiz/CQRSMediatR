using CQRSMediatR.Microservices.StudentApi.Commands;
using CQRSMediatR.Microservices.StudentApi.Model;
using CQRSMediatR.Microservices.StudentApi.Queries;
using CQRSMediatR.Microservices.StudentApi.Queries.handler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatR.Microservices.StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {   
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<Student>> GetStudents()
        {

            var _students = await _mediator.Send(new GetStudentsQuery());

            return _students;

        }
        [HttpPost]
        public async Task<Student> AddStudent(Student student)
        {
            var res = await _mediator.Send(new AddStudentCommand(student));

            return res;
        }
        [HttpDelete("{id}")]
        public async Task<Student> DeleteStudent(int id)
        {
            var res = await _mediator.Send(new DeleteStudentCommand(id));
            if (res is null)
                throw new Exception("Student Not Found"); ;
            return res;
        }
        [HttpGet("{id}")]
        public async Task<Student> GetStudent(int id)
        {
            var res = await _mediator.Send(new GetStudentQuery(id));
            if (res is null)
                throw new Exception("Student Not Found"); ;

            return res;
        }
    }
}
