using CQRS.Models;
using CQRS.Repository;
using CQRS.Mediator.Commands;
using MediatR;

namespace CQRS.Mediator.Handlers;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
{
    private readonly IEmployeesRepository _employeesRepository;

    public CreateEmployeeCommandHandler(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var newEmployee = new Employee(request.Name, request.Address, request.Email, request.DateOfBirth);
        return await _employeesRepository.AddAsync(newEmployee, cancellationToken).ConfigureAwait(false);
    }
}