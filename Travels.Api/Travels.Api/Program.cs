using Microsoft.EntityFrameworkCore;
using Travels.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// get connection string from environmnet variable
var connectionString = builder.Configuration.GetConnectionString("Default");

// create connection with database
builder.Services.AddDbContext<TravelsDataContext>(options =>
     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
     );


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
