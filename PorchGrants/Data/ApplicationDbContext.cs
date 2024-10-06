using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PorchGrants.Data.Models;

namespace PorchGrants.Data;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Organisation> Organisation { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Grant> Grants { get; set; }
    public DbSet<Payment> Payments { get; set; }
}
