using Microsoft.EntityFrameworkCore;
using Modelos.Entities;

namespace Data.DbContext_Conection;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<RenewableEnergyPlant> RenewableEnergyPlant { get; set; }
    public DbSet<RenewableEnergyDataHistory> RenewableEnergyDataHistorys { get; set; }
    public DbSet<EnergyType> EnergyTypes { get; set; }
    public DbSet<RenewableEnergyConsumption> RenewableEnergyConsumptions { get; set; }
}

