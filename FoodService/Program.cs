using FoodService.Infrastructure;
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