using Microsoft.EntityFrameworkCore;

public class HomeApplianceContext : DbContext
{
    public HomeApplianceContext(DbContextOptions<HomeApplianceContext> options)
        : base(options)
    {
    }

    public DbSet<HomeAppliance> HomeAppliances { get; set; }
}
