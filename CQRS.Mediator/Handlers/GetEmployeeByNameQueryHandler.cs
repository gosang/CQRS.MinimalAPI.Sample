using CQRS.Models;
using CQRS.Repository;
using CQRS.Mediator.Queries;
using MediatR;

namespace CQRS.Mediator.Handlers;

public class GetEmployeeByNameQueryHandler : IRequestHandler<GetEmployeeByNameQuery, Employee?>
{
    private readonly IEmployeesRepository _employeesRepository;

    public GetEmployeeByNameQueryHandler(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<Employee?> Handle(GetEmployeeByNameQuery request, CancellationToken cancellationToken)
    {
        return await _employeesRepository.GetByNameAsync(request.Name, cancellationToken).ConfigureAwait(false);
    }
}