
using System.Reflection;
using BankingPanel.Domain.ApplicationUserAggregate;
using Microsoft.EntityFrameworkCore;

namespace BankingPanel.Infrastructure.Persistence;

public class BankingPanelDbContext : DbContext
{
    public DbSet<ApplicationUser> ApplicationUsers {get; set;}

    public BankingPanelDbContext(DbContextOptions<BankingPanelDbContext> options) : base(options)
    {

    }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      base.OnModelCreating(modelBuilder);
  }
   


}