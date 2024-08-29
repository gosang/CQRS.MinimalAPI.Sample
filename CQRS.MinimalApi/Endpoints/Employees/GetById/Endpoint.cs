using CQRS.Services;

namespace CQRS.MinimalApi.Endpoints.Employees.GetById;

public static class Endpoint
{
    public static WebApplication MapGetByIdEmployee(this WebApplication app)
    {
        app.MapGet("employee/get-by-id", async (int id, IEmployeesService employeeService) =>
        {
            try
            {
                var existingEmployees = await employeeService.GetById(id).ConfigureAwait(false);
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