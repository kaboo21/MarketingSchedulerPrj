using MarketingScheduler.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MarketingScheduler.DataAccess.Repositories
{
    public class CustomerRepository(ApplicationDbContext dbContext) : ICustomerRepository
    {
        public async Task<ICollection<Customer>> GetAsync()
        {
            return await dbContext.Customers.ToListAsync();
        }

        public  async Task<ICollection<Customer>> GetByCondition(Expression<Func<Customer, bool>> condition, DateTime sendedDate)
        {
            int dayOfYear = sendedDate.DayOfYear;

            return  await dbContext.Customers
                .Where(c => !c.CampainSendedDate.HasValue || c.CampainSendedDate.Value.DayOfYear != dayOfYear)
                .Where(condition)
                .ToListAsync();
        }

        public async Task SetSendedDate(int customerId, DateTime dateTime)
        {
            var customer = await dbContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if (customer == null)
                return;

            customer.CampainSendedDate = dateTime;

            dbContext.SaveChanges();
        }
    }
}
