using CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Repository.Data;

public class DataContext : DbContext
{
    public DbSet<Employee>? Employees { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
}