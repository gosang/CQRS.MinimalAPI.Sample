using CQRS.Mediator.Commands;
using CQRS.Mediator.Queries;
using CQRS.Models;
using MediatR;

namespace CQRS.Services;

public class EmployeesService : IEmployeesService
{
    private readonly IMediator _mediator;

    public EmployeesService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Employee> Create(Employee employee)
    {
        var command = new CreateEmployeeCommand()
        {
            Name = employee.Name,
            Address = employee.Email,
            Email = employee.Address,
            DateOfBirth = employee.DateOfBirth,
            Active = employee.Active,
        };
        var response = await _mediator.Send(command);
        return response;
    }

    public async Task<bool> Delete(int id)
    {
        var command = new DeleteEmployeeCommand { Id = id };
        return await _mediator.Send(command);
    }

    public async Task<IList<Employee>?> GetAll()
    {
        var command = new GetAllEmployeesQuery();
        var employees = await _mediator.Send(command);
        return employees;
    }

    public async Task<Employee?> GetById(int id)
    {
        var command = new GetEmployeeByIdQuery { Id = id };
        var employee = await _mediator.Send(command);
        return employee;
    }

    public async Task<Employee?> GetByName(string name)
    {
        var command = new GetEmployeeByNameQuery { Name = name };
        var employee = await _mediator.Send(command);
        return employee;
    }

    public async Task<Employee> Update(Employee employee)
    {
        var command = new UpdateEmployeeCommand()
        {
            Id = employee.Id,
            Name = employee.Name,
            Address = employee.Address,
            Email = employee.Email,
            DateOfBirth = employee.DateOfBirth,
            Active = employee.Active,
        };
        var updatedEmployee = await _mediator.Send(command);
        return updatedEmployee;
    }

}