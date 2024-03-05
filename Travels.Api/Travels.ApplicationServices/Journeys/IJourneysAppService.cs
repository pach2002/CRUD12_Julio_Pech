using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;

namespace Travels.ApplicationServices.Journeys
{
    public interface IJourneysAppService
    {
        // Async access methods to Journeys table

        // Get All
        Task<List<Journey>> GetJourneysAsync();

        // Add
        Task<int> AddJourneyAsync(Journey journey);

        // Delete
        Task DeleteJourneyAsync(int journeyId);

        // Get
        Task<Journey> GetJourneyAsync(int journeyId);

        // Update
        Task EditJourneyAsync(Journey journey);

    }
}

