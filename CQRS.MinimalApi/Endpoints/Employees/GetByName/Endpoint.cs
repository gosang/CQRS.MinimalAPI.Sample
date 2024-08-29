using CQRS.Services;

namespace CQRS.MinimalApi.Endpoints.Employees.GetByName;

public static class Endpoint
{
    public static WebApplication MapGetByNameEmployee(this WebApplication app)
    {
        app.MapGet("employee/get-by-name", async (string name, IEmployeesService employeeService) =>
        {
            try
            {
                var existingEmployee = await employeeService.GetByName(name).ConfigureAwait(false);
                return existingEmployee != null ? Results.Ok(existingEmployee) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
        return app;
    }
}