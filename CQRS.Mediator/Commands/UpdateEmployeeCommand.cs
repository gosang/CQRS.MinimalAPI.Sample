using CQRS.Models;
using MediatR;

namespace CQRS.Mediator.Commands;

public class UpdateEmployeeCommand : IRequest<Employee>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public bool? Active { get; set; } = true;
}