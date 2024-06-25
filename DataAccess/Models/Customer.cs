using System.ComponentModel.DataAnnotations;

namespace MarketingScheduler.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
        public int Deposit { get; set; }
        public bool IsNew { get; set; }
        public DateTime? CampainSendedDate { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
