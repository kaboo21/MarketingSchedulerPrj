using MarketingScheduler.Models;

namespace MarketingScheduler.DataAccess.Helpers
{
    public interface ICsvImporter
    {
        ICollection<Customer> ImportCustomersFromFile();
    }
}
