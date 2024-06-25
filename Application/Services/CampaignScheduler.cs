using Hangfire;
using MarketingScheduler.DataAccess.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Models
{
    public class CampaignScheduler(
        ISender sender,
        ICustomerRepository repository,
        ILogger<CampaignScheduler> logger) 
        : ICampaignScheduler
    {

        private readonly ISender sender = sender;
        private readonly ICustomerRepository repository = repository;
        private readonly ILogger<CampaignScheduler> logger = logger;

        public void ScheduleCampainsOnDate(DateTime date)
        {
            var delay = new TimeOnly(0, 30);

            foreach (var campaign in CampaignData.Campaigns)
            {
                var time = campaign.TimeToSend.ToTimeSpan() + delay.ToTimeSpan();
                
                //For Test purpose. Trigger after 3 sec
                //var dateTime = DateTime.Now + new TimeOnly(0, 0, 3).ToTimeSpan();

                var dateTime = date.Date + time;
                BackgroundJob.Schedule(() => ExecuteCampaign(campaign.Id), dateTime);
            }
        }

        public async Task ExecuteCampaign(int campaignId)
        {
            var campain = CampaignData.Campaigns.FirstOrDefault(c => c.Id == campaignId);

            if (campain == null)
            {
                logger.LogWarning($"Campaign with id {campaignId} doesn't exist");
                return;
            }

            var customers = await repository.GetByCondition(campain.Condition, DateTime.Now);

            foreach (var customer in customers)
            {
                sender.Send(customer, DateTime.Now, campain.Template);
            }
        }
    }
}
