using CQRS.Models;
using MediatR;

namespace CQRS.Mediator.Commands;

public class CreateEmployeeCommand : IRequest<Employee>
{
    public string Name { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public bool? Active { get; set; } = true;
}