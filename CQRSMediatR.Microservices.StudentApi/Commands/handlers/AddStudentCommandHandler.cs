using CQRSMediatR.Microservices.StudentApi.Model;
using CQRSMediatR.Microservices.StudentApi.Services;
using MediatR;

namespace CQRSMediatR.Microservices.StudentApi.Commands.handlers
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly IStudentService _studentService;
        public AddStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentService.AddStudent(request._student);
        }
    }
}
