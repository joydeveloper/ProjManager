using Microsoft.EntityFrameworkCore;
using DataModels;
public class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Team> Teams => Set<Team>();
    public ApplicationContext()
    {
       // Database.EnsureDeleted(); 
        Database.EnsureCreated(); 
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=maindata.db");
    }
}