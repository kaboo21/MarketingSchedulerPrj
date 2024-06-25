using MarketingScheduler.DataAccess.Helpers;
using MarketingScheduler.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketingScheduler.DataAccess.EntityCounfiguration
{
    public class CustomerConfiguration(ICsvImporter csvImporter) : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            var customers = csvImporter.ImportCustomersFromFile();

            builder.HasData(customers);
        }
    }
}
