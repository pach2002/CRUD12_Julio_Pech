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
            var origin = await Context.Origins.FindAsync(entity.Origin.Id);
            var destionation = await Context.Destinations.FindAsync(entity.Destination.Id);

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
    }
}
