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
            var journey = await Context.Journeys
                .Include(x => x.Origin)
                .Include(x => x.Destination)
                .FirstOrDefaultAsync(x => x.Id == id);

            // return register with all values
            return journey;

        }

        // override get all method to find Origin and Destination Values for every row
        public override IQueryable<Journey> GetAll()
        {
            // cross data with Origin and Destination Tables
            return Context.Set<Journey>()
                .Include(x => x.Origin)
                .Include(x => x.Destination);
        }
    }
}
