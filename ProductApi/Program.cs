
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the HomeApplianceContext with in-memory database for simplicity
builder.Services.AddDbContext<HomeApplianceContext>(options =>
    options.UseInMemoryDatabase("HomeApplianceDB"));

// Register the IHomeApplianceRepository with its implementation
builder.Services.AddScoped<IHomeApplianceRepository, MockHomeApplianceRepository>();

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
