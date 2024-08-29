using CQRS.Models;
using CQRS.Services;
using MiniValidation;

namespace CQRS.MinimalApi.Endpoints.Employees.Create;

public static class Endpoint
{
    public static WebApplication MapPostCreateEmployee(this WebApplication app)
    {
        app.MapPost("employee/create", async (Employee employee, IEmployeesService employeeService) =>
            !MiniValidator.TryValidate(employee, out var errors)
                ? Results.ValidationProblem(errors)
                : Results.Ok(await employeeService.Create(employee).ConfigureAwait(false)));
        return app;
    }
}