using Microsoft.EntityFrameworkCore;

namespace Factory.Models
{
    public class FactoryContext : DbContext
    {
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<EngineerMachine> EngineerMachines { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentMachine> IncidentMachines { get; set; }
        public FactoryContext(DbContextOptions options) : base(options) { }
    }
}