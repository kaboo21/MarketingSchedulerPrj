using Application.Models;
using Application.Services;
using Hangfire;
using Hangfire.MemoryStorage;
using MarketingScheduler.DataAccess;
using MarketingScheduler.DataAccess.Helpers;
using MarketingScheduler.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);

// Initialize SQLitePCLdfdf
Batteries.Init();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite("Data Source=campaigns.db"));

builder.Services.AddHangfire((sp, config) =>
{
    //Add the line below
    config.UseSerializerSettings(new JsonSerializerSettings()
    {
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    });
    config.UseMemoryStorage();
});

builder.Services.AddHangfireServer();
builder.Services.AddScoped<ICsvImporter, CsvImporter>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICampaignScheduler, CampaignScheduler>();
builder.Services.AddScoped<ISender, Sender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
