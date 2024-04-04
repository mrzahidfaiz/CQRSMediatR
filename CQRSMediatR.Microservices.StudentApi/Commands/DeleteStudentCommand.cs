using CQRSMediatR.Microservices.StudentApi.Model;
using MediatR;

namespace CQRSMediatR.Microservices.StudentApi.Commands
{
    public record DeleteStudentCommand(int id) : IRequest<Student>;
}
