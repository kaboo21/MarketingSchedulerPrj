using CsvHelper;
using CsvHelper.Configuration;
using DataAccess.Models.DTOs;
using MarketingScheduler.Models;
using System.Globalization;

namespace MarketingScheduler.DataAccess.Helpers
{
    public class CsvImporter : ICsvImporter
    {
        public ICollection<Customer> ImportCustomersFromFile()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "customers.csv");

            List<Customer> customers = [];

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var customersFromFile = csv.GetRecords<CustomerDto>();

                var customerDtos = customersFromFile.Select(c => new Customer
                {
                    Id = c.CUSTOMER_ID,
                    Age = c.Age,
                    Gender = c.Gender == "Male" ? Gender.Male : Gender.Female,
                    City = c.City,
                    Deposit = c.Deposit,
                    IsNew = c.NewCustomer
                }).ToList();

                customers.AddRange(customerDtos);
            }

            return customers;
        }
    }
}
