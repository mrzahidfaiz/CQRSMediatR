using CQRSMediatR.Microservices.StudentApi.Model;
using MediatR;

namespace CQRSMediatR.Microservices.StudentApi.Commands
{
    public record AddStudentCommand(Student _student) : IRequest<Student>;
}
