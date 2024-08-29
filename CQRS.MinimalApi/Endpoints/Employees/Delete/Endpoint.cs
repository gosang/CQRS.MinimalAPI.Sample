using CQRS.Services;

namespace CQRS.MinimalApi.Endpoints.Employees.Delete;

public static class Endpoint
{
    public static WebApplication MapDeleteEmployee(this WebApplication app)
    {
        app.MapDelete("employee/delete", async (int id, IEmployeesService employeeService) =>
        {
            try
            {
                var success = await employeeService.Delete(id).ConfigureAwait(false);
                return success ? Results.Ok() : Results.BadRequest();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
        return app;
    }
}