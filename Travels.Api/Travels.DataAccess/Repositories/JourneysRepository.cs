using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;

namespace Travels.DataAccess.Repositories
{
    public class JourneysRepository : Repository<int, Journey>
    {
        // builder
        public JourneysRepository(TravelsDataContext context) : base(context)
        {
        }

        // override method to establish Destionation and Object in add method
        public override async Task<Journey> AddAsync(Journey entity)
        {
            // recover values by id
            var origin = await Context.Origins.FindAsync(entity.OriginId);
            var destionation = await Context.Destinations.FindAsync(entity.DestinationId);

            // establish values as null
            entity.Destination = null;
            entity.Origin = null;

            // add to database
            await Context.Journeys.AddAsync(entity);
            origin.Journeys.Add(entity);
            destionation.Journeys.Add(entity);

            // save changes
            await Context.SaveChangesAsync();

            return entity;
        }

        // override method to save changes on Destionation and Origin
        public override async Task<Journey> UpdateAsync(Journey entity)
        {
            // recover values by id
            var origin = await Context.Origins.FindAsync(entity.Origin.Id);
            var destionation = await Context.Destinations.FindAsync(entity.Destination.Id);

            // establish values as null
            entity.Destination = null;
            entity.Origin = null;

            // add changes to database
            Context.Journeys.Update(entity);
            origin.Journeys.Add(entity);
            destionation.Journeys.Add(entity);

            // save changes
            await Context.SaveChangesAsync();

            return entity;
        }


        // override get method to find Origin and Destination Values
        public override async Task<Journey> GetAsync(int id)
        {
            // select all values, no include Origin and Destination
            var journey = await Context.Journeys
                 .Select(j => new Journey
                 {
                     Id = j.Id,
                     OriginId = j.OriginId,
                     DestinationId = j.DestinationId,
                     Arrival = j.Arrival,
                     Departure = j.Departure
                 })
                .FirstOrDefaultAsync(x => x.Id == id);

            // return register with all values
            return journey;

        }

        // override get all method to find Origin and Destination Values for every row
        public override IQueryable<Journey> GetAll()
        {
            // Select all values, no Origin and Destination Object
            return Context.Set<Journey>()
                    .Select(j => new Journey
                    {
                        Id = j.Id,
                        OriginId = j.OriginId,
                        DestinationId = j.DestinationId,
                        Arrival = j.Arrival,
                        Departure = j.Departure
                    });
        }
    }
}
