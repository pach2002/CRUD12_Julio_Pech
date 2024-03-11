using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;
using Travels.Core.Places;

namespace Travels.DataAccess
{
    // database context
    public class TravelsDataContext : DbContext
    {

        // tables
        public virtual DbSet<Journey> Journeys { get; set; }

        public virtual DbSet<Passenger> Passengers { get; set; }

        public virtual DbSet<Ticket> Tickets { get; set; }

        public virtual DbSet<Destination> Destinations { get; set; }

        public virtual DbSet<Origin> Origins { get; set; }
 
        // builder
        public TravelsDataContext(DbContextOptions<TravelsDataContext> options) : base(options) 
        {

        }

    }
}
