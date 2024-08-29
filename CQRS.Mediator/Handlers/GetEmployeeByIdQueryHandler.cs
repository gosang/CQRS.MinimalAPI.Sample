using CQRS.Models;
using CQRS.Repository;
using CQRS.Mediator.Queries;
using MediatR;

namespace CQRS.Mediator.Handlers;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee?>
{
    private readonly IEmployeesRepository _employeesRepository;

    public GetEmployeeByIdQueryHandler(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        return await _employeesRepository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
    }
}