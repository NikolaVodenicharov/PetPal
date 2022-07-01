using AccessoriesService.Domain.Infrastructures;
using AccessoriesService.Infrastructure.DataAccess;
using AccessoriesService.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AccessoriesMongoDBSettings>(builder.Configuration.GetSection(nameof(AccessoriesMongoDBSettings)));

builder.Services.AddSingleton<IAccessoriesMongoDBSettings>(
    sp => sp.GetRequiredService<IOptions<AccessoriesMongoDBSettings>>().Value);

builder.Services.AddScoped<ICollarRepository, CollarRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
