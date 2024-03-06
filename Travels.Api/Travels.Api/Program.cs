using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Travels.ApplicationServices.Journeys;
using Travels.ApplicationServices.Passengers;
using Travels.ApplicationServices.Tickets;
using Travels.DataAccess;
using Travels.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Solve api call ignoring cycles
builder.Services.AddControllers().AddNewtonsoftJson(x =>
 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// --- register dependecies for project

// Access methods
builder.Services.AddTransient<IJourneysAppService, JourneysAppService>();
builder.Services.AddTransient<ITicketsAppService, TicketsAppService>();
builder.Services.AddTransient<IPassengersAppService, PassengersAppService>();

// Repository extensions
builder.Services.AddTransient<IRepository<int, Travels.Core.Journeys.Journey>, JourneysRepository>();
builder.Services.AddTransient<IRepository<int, Travels.Core.Journeys.Ticket>, TicketsRepository>();
builder.Services.AddTransient<IRepository<int, Travels.Core.Journeys.Passenger>, PassengersRepository>();

// ADD AUTOMAPPER
builder.Services.AddAutoMapper(typeof(Travels.ApplicationServices.MapperProfile));

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
