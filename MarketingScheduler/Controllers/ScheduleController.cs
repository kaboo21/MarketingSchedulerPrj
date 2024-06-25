using Application.Models;
using MarketingScheduler.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarketingScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController(ICustomerRepository cusomerRepository, ICampaignScheduler campaignScheduler) : ControllerBase
    {
        //Only for Tests
        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var customers =  await cusomerRepository.GetAsync();

            return Ok(customers);
        }

        [HttpGet("campaigns")]
        public async Task<IActionResult> GetCustomersAsync(DateTime dateTime)
        {
            campaignScheduler.ScheduleCampainsOnDate(dateTime);

            return Ok();
        }
    }
}
