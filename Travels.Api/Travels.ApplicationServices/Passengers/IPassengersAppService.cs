using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;

namespace Travels.ApplicationServices.Passengers
{
    public interface IPassengersAppService
    {
        // Async access methods to Passengers table

        // Get All
        Task<List<Passenger>> GetPassengersAsync();

        // Add
        Task<int> AddPassengerAsync(Passenger passenger);

        // Delete
        Task DeletePassengerAsync(int PassengerId);

        // Get
        Task<Passenger> GetPassengerAsync(int PassengerId);

        // Update
        Task EditPassengerAsync(Passenger passenger);

    }
}

