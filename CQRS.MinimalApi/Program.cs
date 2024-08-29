using CQRS.MinimalApi.Endpoints.Employees.Create;
using CQRS.MinimalApi.Endpoints.Employees.Delete;
using CQRS.MinimalApi.Endpoints.Employees.GetAll;
using CQRS.MinimalApi.Endpoints.Employees.GetById;
using CQRS.MinimalApi.Endpoints.Employees.GetByName;
using CQRS.MinimalApi.Endpoints.Employees.Update;
using CQRS.Repository;
using CQRS.Repository.Data;
using CQRS.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registers the given context as a service.
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(connectionString, opt =>
    {
        opt.CommandTimeout((int)TimeSpan.FromSeconds(60).TotalSeconds);
    });
});

// Registers handlers and mediator types from the specified assemblies.
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

builder.Services.AddTransient<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();

var app = builder.Build();


// Migrate database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>();
    context.Database.Migrate();
    DataSeeder.Seed(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Map endpoints
app.MapGetAllEmployees()
    .MapGetByIdEmployee()
    .MapGetByNameEmployee()
    .MapPostCreateEmployee()
    .MapPutUpdateEmployee()
    .MapDeleteEmployee();

// Redirection to Swagger UI
app.MapGet("", context =>
{
    context.Response.Redirect("./swagger/index.html", permanent: false);
    return Task.FromResult(0);
});

app.Run();
