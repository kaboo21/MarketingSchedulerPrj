﻿namespace DataAccess.Models.DTOs
{
    public class CustomerDto
    {
        public int CUSTOMER_ID { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int Deposit { get; set; }
        public bool NewCustomer { get; set; }
    }
}
