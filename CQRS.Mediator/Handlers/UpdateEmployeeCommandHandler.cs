using CQRS.Models;
using CQRS.Repository;
using CQRS.Mediator.Commands;
using MediatR;

namespace CQRS.Mediator.Handlers;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee?>
{
    private readonly IEmployeesRepository _employeesRepository;

    public UpdateEmployeeCommandHandler(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<Employee?> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Employee employee = new Employee(request.Name, request.Address, request.Email, request.DateOfBirth, request.Active)
        {
            Id = request.Id
        };
        return await _employeesRepository.UpdateAsync(employee, cancellationToken).ConfigureAwait(false);
    }
}