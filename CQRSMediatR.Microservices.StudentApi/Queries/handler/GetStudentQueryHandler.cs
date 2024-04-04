using CQRSMediatR.Microservices.StudentApi.Model;
using CQRSMediatR.Microservices.StudentApi.Services;
using MediatR;

namespace CQRSMediatR.Microservices.StudentApi.Queries.handler
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, Student>
    {
        private readonly IStudentService _studentService;
        public GetStudentQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Student> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetStudent(request.id);
        }
    }
}
