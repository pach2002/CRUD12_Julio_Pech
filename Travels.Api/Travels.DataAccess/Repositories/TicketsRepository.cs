using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;

namespace Travels.DataAccess.Repositories
{
    public class TicketsRepository : Repository<int, Ticket>
    {
        // builder
        public TicketsRepository(TravelsDataContext context) : base(context)
        {

        }

        // add override
        public override async Task<Ticket> AddAsync(Ticket entity)
        {
            // recover values by id
            var journey = await Context.Journeys.FindAsync(entity.JourneyId);
            var passenger = await Context.Passengers.FindAsync(entity.PassengerId);

            // establish values as null
            entity.Journey = null;
            entity.Passenger = null;

            // add to database
            await Context.Tickets.AddAsync(entity);
            journey.Tickets.Add(entity);
            passenger.Tickets.Add(entity);

            // save changes
            await Context.SaveChangesAsync();

            return entity;
        }
    }
}
