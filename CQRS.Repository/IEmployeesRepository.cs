using CQRS.Models;
using CQRS.Repository.Base;

namespace CQRS.Repository;

public interface IEmployeesRepository : IBaseRepository<Employee>
{
    Task<IList<Employee>> GetAllAsync(CancellationToken cancellationToken);

    Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken);

    Task<Employee?> GetByNameAsync(string name, CancellationToken cancellationToken);
}