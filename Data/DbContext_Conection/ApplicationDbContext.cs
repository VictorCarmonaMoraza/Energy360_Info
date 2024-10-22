using Energy360_Info.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DbContext_Conection;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
