using CQRSMediatR.Microservices.StudentApi.Model;
using MediatR;

namespace CQRSMediatR.Microservices.StudentApi.Queries.handler
{
    public record GetStudentsQuery() : IRequest<List<Student>>;
}