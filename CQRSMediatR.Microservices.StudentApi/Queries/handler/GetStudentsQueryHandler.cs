using CQRSMediatR.Microservices.StudentApi.Model;
using CQRSMediatR.Microservices.StudentApi.Services;
using MediatR;

namespace CQRSMediatR.Microservices.StudentApi.Queries.handler
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<Student>>
    {
        private readonly IStudentService _studentService;
        public GetStudentsQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<List<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetStudents();
        }
    }
}
