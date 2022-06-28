using FoodService.Application.Queries.FoodDetails;
using FoodService.Application.Queries.FoodSummary;
using FoodService.Domain.Repositories;
using FoodService.Infrastructure;
using FoodService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//added by me
builder.Services.AddDbContextPool<FoodDatabase>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("FoodServiceDatabaseConnection")));

builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<FoodSummaryAllHandler>();
builder.Services.AddScoped<FoodDetailsHandler>();

builder.Services.AddScoped<FoodDatabaseSeed>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

/*    SeedData();*/
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/*void SeedData()
{
    using (var scope = app.Services.CreateScope())
    {
        var foodDataabseSeed = scope.ServiceProvider.GetService<FoodDatabaseSeed>();
        foodDataabseSeed.GenerateFoods();
    }
}*/