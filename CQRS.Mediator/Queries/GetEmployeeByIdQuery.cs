using CQRS.Models;
using MediatR;

namespace CQRS.Mediator.Queries;

public class GetEmployeeByIdQuery : IRequest<Employee>
{
    public int Id { get; set; }
}