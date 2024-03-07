using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.ApplicationServices.Passengers;
using Travels.Core.Journeys;
using Travels.Journeys.Dto;

namespace Travels.UnitTest
{
    public class TestPassenger
    {

        // local host and repository
        private TestServer server;
        private IPassengersAppService repository;


        // change
        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            this.repository = server.Host.Services.GetService<IPassengersAppService>(); // receive access methods

        }

        [Test]
        // GET ALL
        public async Task TestGetAll() 
        {
            List<Passenger> passengers = await repository.GetPassengersAsync();

            Assert.Pass();
        }

        [Test]
        // CREATE A JOURNEY // modified with automapper
        public async Task TestAdd()
        {
            PassengerDto passenger = new PassengerDto
            {
                FirstName = "Juls",
                LastName = "P",
                Age = 20
            };

            int id = await repository.AddPassengerAsync(passenger);

            Assert.Pass();
        }

        // GET
        [Test]
        public async Task TestGetById() 
        {
            // test get a journey by
            Passenger passenger = await repository.GetPassengerAsync(1);

            Assert.Pass();

        }

        // DELETE
        [Test]
        public async Task TestDelete()
        {
            // test delete
            await repository.DeletePassengerAsync(1);

            Assert.Pass();
        }

        [Test]
        // UPDATE
        public async Task TestUpdate() 
        {
            Passenger passenger = new Passenger
            {
                Id = 1,
                FirstName = "Julio",
                LastName = "Pech",
                Age = 22
            };

            await repository.EditPassengerAsync(passenger);

            Assert.Pass();
        }
    }
}
