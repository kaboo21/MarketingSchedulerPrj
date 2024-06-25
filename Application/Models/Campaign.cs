using MarketingScheduler.Models;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Application.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Template { get; set; }
        public Expression<Func<Customer, bool>> Condition { get; set; }
        public TimeOnly TimeToSend { get; set; }
        public int Priority { get; set; }
    }

    public static class CampaignData
    {
        public static ICollection<Campaign> Campaigns { get; set; } = new List<Campaign>
        {
            new Campaign
            {
                Id = 1,
                Template = "Template A",
                Condition = c => c.Gender == Gender.Male,
                TimeToSend = new TimeOnly(10, 15),
                Priority = 1
            },
            new Campaign
            {
                Id = 2,
                Template = "Template B",
                Condition = c => c.Age > 45,
                TimeToSend = new TimeOnly(10, 5),
                Priority = 2
            },
            new Campaign
            {
                Id = 3,
                Template = "Template C",
                Condition = c => c.City == "New York",
                TimeToSend = new TimeOnly(10, 10),
                Priority = 5
            },
            new Campaign
            {
                Id = 4,
                Template = "Template A",
                Condition = c => c.Deposit > 100,
                TimeToSend = new TimeOnly(10, 15),
                Priority = 3
            },
            new Campaign
            {
                Id = 5,
                Template = "Template C",
                Condition = c => c.IsNew,
                TimeToSend = new TimeOnly(10, 5),
                Priority = 4
            }
        };
    }
}

    
