using CQRS.Models;

namespace CQRS.Repository.Data;

public class DataSeeder
{
    public static void Seed(DataContext context)
    {
        if (context.Employees == null || context.Employees.Any()) return;

        context.Employees.AddRange(GetPreconfiguredStudents());
        context.SaveChanges();
    }

    // Sample dataset
    private static IEnumerable<Employee> GetPreconfiguredStudents()
    {
        return
        [
            new Employee("Tonny Blat", "Street 1c", "tony@gmail.com", new DateTime(1991, 10, 7)),
            new Employee("Anitta Goldman", "Street 2c", "Anita@gmail.com", new DateTime(1975, 5, 31)),
            new Employee("Alan Ford", "Street 3c", "alan@gmail.com", new DateTime(2000, 8, 26)),
            new Employee("Jim Beam", "Street 4c", "jim@gmail.com", new DateTime(1984, 1, 12)),
            new Employee("Suzanne White", "Street 5c", "suzanne@gmail.com", new DateTime(1992, 3, 10)),
        ];
    }
}