
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.ApplicationServices.Journeys;
using Travels.ApplicationServices.Passengers;
using Travels.ApplicationServices.Tickets;
using Travels.Core.Journeys;
using Travels.DataAccess;
using Travels.DataAccess.Repositories;

namespace Travels.UnitTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // USE IN MEMORY DATABASE
            // services.AddDbContext<TravelsDataContext>(options => options.UseInMemoryDatabase("DataTest"));

            // USE A CONNECTION TO DATABASE
            // get connection string from environmnet variable
            var connectionString = "server=localhost;port=3306;database=travels;user=root;password=123456;";

            // create connection with database
            services.AddDbContext<TravelsDataContext>(options =>
                 options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                 );


            // REGISTER DEPENDENCIES
            // Access methods
            services.AddTransient<IJourneysAppService, JourneysAppService>();
            services.AddTransient<ITicketsAppService, TicketsAppService>();
            services.AddTransient<IPassengersAppService, PassengersAppService>();

            // Repository extensions
            services.AddTransient<IRepository<int, Journey>, JourneysRepository>();
            services.AddTransient<IRepository<int, Ticket>, TicketsRepository>();
            services.AddTransient<IRepository<int, Passenger>, PassengersRepository>();
                
            // MODIFIED BY AUTOMAPPER
            //services.AddTransient<IRepository<int, GymManager.Core.Members.Member>, MembersRepository>();

            // ADD AUTOMAPPER
            //services.AddAutoMapper(typeof(GymManager.ApplicationServices.MapperProfile));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
