using CQRS.Models;

namespace CQRS.Services;

public interface IEmployeesService
{
    Task<bool> Delete(int id);

    Task<IList<Employee>?> GetAll();

    Task<Employee?> GetById(int id);

    Task<Employee?> GetByName(string name);

    Task<Employee> Create(Employee employee);

    Task<Employee> Update(Employee student);
}