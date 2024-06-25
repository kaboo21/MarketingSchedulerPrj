using Application.Models;
using MarketingScheduler.DataAccess.Repositories;
using MarketingScheduler.Models;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class Sender : ISender
    {
        private readonly IConfiguration _configuration;
        private readonly ICustomerRepository _repository;
        private readonly string _filePath;

        public Sender(IConfiguration configuration, ICustomerRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
            _filePath = _configuration["FileName"];
        }
        public void Send(Customer customer, DateTime dateTime, string template)
        {
             string content = $"\n{dateTime:dd.MM.yy hh:mm tt}, CustomerId - {customer.Id}, Template {template}";

            File.AppendAllText(_filePath, content + Environment.NewLine);

            _repository.SetSendedDate(customer.Id, dateTime);
        }
    }
}
