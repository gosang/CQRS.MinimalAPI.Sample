using CQRS.Models;
using CQRS.Repository.Base;
using CQRS.Repository.Data;

namespace CQRS.Repository;

public class EmployeesRepository : BaseRepository<Employee, DataContext>, IEmployeesRepository
{

    public EmployeesRepository(DataContext? dbContext)
        : base(dbContext)
    {
    }

    public async Task<IList<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await GetAsync<Employee>(orderBy: cmp => cmp.OrderBy(std => std.Name),
            cancellationToken: cancellationToken).ConfigureAwait(false);
        return result;
    }

    public async Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await GetSingleOrDefaultAsync<Employee>(std => std.Id == id, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<Employee?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await GetSingleOrDefaultAsync<Employee>(std => std.Name == name, cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }
}