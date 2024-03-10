using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.ApplicationServices.Passengers;
using Travels.ApplicationServices.Tickets;
using Travels.Core.Journeys;
using Travels.Journeys.Dto;

namespace Travels.UnitTest
{
    public class TestTicket
    {

        // local host and repository
        private TestServer server;
        private ITicketsAppService repository;


        // change
        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            this.repository = server.Host.Services.GetService<ITicketsAppService>(); // receive access methods

        }

        [Test]
        // GET ALL
        public async Task TestGetAll()
        {
            List<Ticket> tickets = await repository.GetTicketsAsync();

            Assert.Pass();
        }

        // GET
        [Test]
        public async Task TestGetById() 
        {
            // test get a ticket
            Ticket ticket = await repository.GetTicketAsync(3);

            Assert.Pass();
        }

        // ADD
        [Test]
        public async Task TestAdd() 
        {
            TicketDto ticket = new TicketDto
            {
                JourneyId = 1,
                PassengerId = 3,
                Seat = 5
            };

            // test add a ticket
            await repository.AddTicketAsync(ticket);

            Assert.Pass();
        }

        // DELETE
        [Test]
        public async Task TestDelete() 
        {
            // test delete
            await repository.DeleteTicketAsync(2);

            Assert.Pass();
        }

        [Test]
        // UPDATE
        public async Task TestUpdate() 
        {
            Ticket ticket = new Ticket
            {
                Id = 3,
                JourneyId = 6,
                PassengerId = 4,
                Seat = 25
            };

            // EDIT BY ID
            await repository.EditTicketAsync(ticket);

            // 
            Assert.Pass();
        }


    }
}
