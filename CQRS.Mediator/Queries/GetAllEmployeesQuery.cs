using CQRS.Models;
using MediatR;

namespace CQRS.Mediator.Queries;

public class GetAllEmployeesQuery : IRequest<IList<Employee>>
{
}