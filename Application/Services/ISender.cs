using MarketingScheduler.Models;

namespace Application.Models
{
    public interface ISender
    {
        void Send(Customer customer, DateTime dateTime, string template);
    }
}
