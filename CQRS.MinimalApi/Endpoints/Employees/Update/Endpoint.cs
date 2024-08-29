using CQRS.Models;
using CQRS.Services;

namespace CQRS.MinimalApi.Endpoints.Employees.Update;

public static class Endpoint
{
    public static WebApplication MapPutUpdateEmployee(this WebApplication app)
    {
        app.MapPut("employee/update", async (Employee employee, IEmployeesService employeeService) =>
        {
            try
            {
                var updatedEmployee = await employeeService.Update(employee).ConfigureAwait(false);
                return Results.Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
        return app;
    }
}