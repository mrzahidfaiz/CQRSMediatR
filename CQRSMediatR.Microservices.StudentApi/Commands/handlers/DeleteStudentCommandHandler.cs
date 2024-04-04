using CQRSMediatR.Microservices.StudentApi.Model;
using CQRSMediatR.Microservices.StudentApi.Services;
using MediatR;

namespace CQRSMediatR.Microservices.StudentApi.Commands.handlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Student>
    {
        private readonly IStudentService _studentService;
        public DeleteStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Student> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var res = await _studentService.DeleteStudent(request.id);

            return res;
        }
    }
}
