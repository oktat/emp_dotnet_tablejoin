using Microsoft.EntityFrameworkCore;

namespace app01.Data;

public class DataService : DbContext {
    public DataService(DbContextOptions<DataService> options)
        :base(options) {}

    public DbSet<Employee> Employees {get; set;} = null!;
    public DbSet<Position> Positions {get; set;} = null!;
}
