using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;
using Travels.Api;
using Travels.ApplicationServices.Journeys;
using Travels.ApplicationServices.Passengers;
using Travels.ApplicationServices.Tickets;
using Travels.DataAccess;
using Travels.DataAccess.Repositories;
using Travels.Jwt;
using Travels.Jwt.Config;
using static Travels.Api.Auth.JwtOptions;

var builder = WebApplication.CreateBuilder(args);

// get connection string from environmnet variable
var connectionString = builder.Configuration.GetConnectionString("Default");
var connectionStringJwt = builder.Configuration.GetConnectionString("Jwt");

// create connection with database for data
builder.Services.AddDbContext<TravelsDataContext>(options =>
     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
     );

// create connection with database for identity
builder.Services.AddDbContext<JwtDbContext>(options =>
    options.UseMySql(connectionStringJwt, ServerVersion.AutoDetect(connectionStringJwt))
    );

// before start project, create logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // Write all in console/
    .CreateBootstrapLogger();

// add serilog
builder.Host
    .UseSerilog(
    (context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    );

// add service of identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    opts =>
    {
        opts.Password.RequireDigit = true;
        opts.Password.RequireLowercase = true;
        opts.Password.RequireUppercase = true;
        opts.Password.RequireNonAlphanumeric = true;
        opts.Password.RequiredLength = 7;
        opts.Password.RequiredUniqueChars = 4;
    })
    .AddEntityFrameworkStores<JwtDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
// Solve api call ignoring cycles
builder.Services.AddControllers().AddNewtonsoftJson(x =>
 x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// add JWT
builder.Services.Configure<JwtTokenValidationSettings>(builder.Configuration.GetSection("JwtTokenValidationSettings"));
// Dependency for JWT
builder.Services.AddTransient<IJwtIssuerOptions, JwtIssuerFactory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
        option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
        {

            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter your token in the text input below. \r\n",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
            Scheme = JwtBearerDefaults.AuthenticationScheme

        });


        option.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        }
                    },

                    new string[]{ }
                }
        });
});

// get token validation
var tokenValidationSettings = builder.Services.BuildServiceProvider().GetService<IOptions<JwtTokenValidationSettings>>().Value;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = tokenValidationSettings.ValidIssuer,
            ValidAudience = tokenValidationSettings.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenValidationSettings.SecretKey)),
            ClockSkew = TimeSpan.Zero

        };
    });



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

// configuration to set objects in api call as not required
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    // now, send object in json is not required
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// local extension for jwt
app.InitDb();

app.UseHttpsRedirection();

// add auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
