

namespace Application.Models
{
    public interface ICampaignScheduler
    {
        Task ExecuteCampaign(int campaignId);
        void ScheduleCampainsOnDate(DateTime date);
    }
}