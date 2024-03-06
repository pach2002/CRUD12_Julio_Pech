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
    }
}
