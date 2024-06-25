using MarketingScheduler.DataAccess.EntityCounfiguration;
using MarketingScheduler.DataAccess.Helpers;
using MarketingScheduler.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketingScheduler.DataAccess
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICsvImporter csvImporter) : DbContext(options)
    {
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CustomerConfiguration(csvImporter));
        }
    }
}
