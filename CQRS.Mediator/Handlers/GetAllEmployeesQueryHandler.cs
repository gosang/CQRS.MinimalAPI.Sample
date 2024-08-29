using CQRS.Models;
using CQRS.Repository;
using CQRS.Mediator.Queries;
using MediatR;

namespace CQRS.Mediator.Handlers;

public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IList<Employee>?>
{
    private readonly IEmployeesRepository _employeesRepository;

    public GetAllEmployeesQueryHandler(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<IList<Employee>?> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await _employeesRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);
    }
}