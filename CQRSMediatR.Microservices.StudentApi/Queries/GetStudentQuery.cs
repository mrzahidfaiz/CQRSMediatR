using CQRSMediatR.Microservices.StudentApi.Model;
using MediatR;

namespace CQRSMediatR.Microservices.StudentApi.Queries
{
    public record GetStudentQuery(int id) : IRequest<Student>;
}
