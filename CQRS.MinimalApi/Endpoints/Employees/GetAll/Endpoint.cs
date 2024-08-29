using CQRS.Services;

namespace CQRS.MinimalApi.Endpoints.Employees.GetAll;

public static class Endpoint
{
    public static WebApplication MapGetAllEmployees(this WebApplication app)
    {
        app.MapGet("employee/get-all", async (IEmployeesService employeeService) =>
        {
            try
            {
                var existingEmployees = await employeeService.GetAll().ConfigureAwait(false);
                return existingEmployees != null ? Results.Ok(existingEmployees) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
        return app;
    }
}