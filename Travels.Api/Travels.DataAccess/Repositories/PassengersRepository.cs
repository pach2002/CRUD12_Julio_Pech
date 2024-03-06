using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;

namespace Travels.DataAccess.Repositories
{
    public class PassengersRepository : Repository<int, Passenger>
    {
        // builder
        public PassengersRepository(TravelsDataContext context) : base(context)
        {
        }
    }
}
