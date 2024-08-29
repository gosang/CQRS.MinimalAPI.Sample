using CQRS.Repository;
using CQRS.Mediator.Commands;
using MediatR;

namespace CQRS.Mediator.Handlers;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IEmployeesRepository _employeesRepository;

    public DeleteEmployeeCommandHandler(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await _employeesRepository.RemoveAsync(request.Id, cancellationToken).ConfigureAwait(false);
    }
}