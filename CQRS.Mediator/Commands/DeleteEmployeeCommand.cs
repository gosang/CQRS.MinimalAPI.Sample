using MediatR;

namespace CQRS.Mediator.Commands;

public class DeleteEmployeeCommand : IRequest<bool>
{
    public int Id { get; set; }
}