using CQRS.Models;
using MediatR;

namespace CQRS.Mediator.Queries;

public class GetEmployeeByNameQuery : IRequest<Employee>
{
    public string Name { get; set; }
}