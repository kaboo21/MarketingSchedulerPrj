using MarketingScheduler.Models;
using System.Linq.Expressions;

namespace MarketingScheduler.DataAccess.Repositories
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> GetAsync();
        Task<ICollection<Customer>> GetByCondition(Expression<Func<Customer, bool>> condition, DateTime sendedDate);
        Task SetSendedDate(int customerId, DateTime dateTime);
    }
}