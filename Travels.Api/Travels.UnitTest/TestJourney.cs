using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Travels.ApplicationServices.Journeys;
using Travels.Core.Journeys;
using Travels.Journeys.Dto;

namespace Travels.UnitTest
{
    public class TestJourney
    {

        // local host and repository
        private TestServer server;
        private IJourneysAppService repository;


        // change
        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            this.repository = server.Host.Services.GetService<IJourneysAppService>(); // receive access methods

        }

        [Test]
        // GET ALL
        public async Task TestGetAll()
        {
            // test Get All 
            List<Journey> journeys = await repository.GetJourneysAsync();

            Assert.Pass();
        }


        [Test]
        // GET BY ID
        public async Task TestGetById()
        {
            // test Get a journey
            Journey journey = await repository.GetJourneyAsync(3);

            Assert.Pass();
        }


        [Test]
        // CREATE A JOURNEY
        public async Task TestAdd()
        {
            JourneyDto journey = new JourneyDto
            {
                // Id = 1, requires id?? no, is not necessary

                // requires a object
                /*Destination = new Core.Places.Destination 
                {
                    Id = 1,
                },
                Origin = new Core.Places.Origin 
                {
                    Id = 1,
                },*/

                OriginId = 1,
                DestinationId = 1,

                Departure = DateTime.Now,
                Arrival = DateTime.Now
            };

            // test add a journey
            await repository.AddJourneyAsync(journey);

            Assert.Pass();
        }

        [Test]
        // DELETE A JOURNEY
        public async Task TestDelete()
        {
            // test delete
            await repository.DeleteJourneyAsync(3);

            Assert.Pass();
        }

        [Test]
        // UPDATE A JOURNEY
        public async Task TestUpdate()
        {
            // requires id
            // build a new journey
            Journey journey = new Journey
            {
                Id = 6,

                // requires a object
                /*Destination = new Core.Places.Destination
                {
                    Id = 2,
                },
                Origin = new Core.Places.Origin
                {
                    Id = 2,
                },*/

                OriginId = 2,
                DestinationId = 2,

                Departure = DateTime.Now,
                Arrival = DateTime.Now
            };

            // test update a journey
            await repository.EditJourneyAsync(journey);

            Assert.Pass();
        }
    }
}