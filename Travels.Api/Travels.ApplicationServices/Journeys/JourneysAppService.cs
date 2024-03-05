using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;
using Travels.DataAccess.Repositories;

namespace Travels.ApplicationServices.Journeys
{
    public class JourneysAppService : IJourneysAppService
    {

        // local context of repository
        private readonly IRepository<int, Journey> _repository;

        // builder, receive by injection dependency repository
        public JourneysAppService(IRepository<int, Journey> repository)
        {
            _repository = repository;
        }

        // ADD NEW JOURNEY
        public async Task<int> AddJourneyAsync(Journey journey)
        {
            await _repository.AddAsync(journey);

            return journey.Id;
        }

        // DELETE A JOURNEY
        public async Task DeleteJourneyAsync(int journeyId)
        {
            await _repository.DeleteAsync(journeyId);
        }

        // EDIT JOURNEY
        public async Task EditJourneyAsync(Journey journey)
        {
            await _repository.UpdateAsync(journey);
        }

        // GET JOURNEY BY ID
        public async Task<Journey> GetJourneyAsync(int journeyId)
        {
            return await _repository.GetAsync(journeyId);
        }

        // GET LIST OF JOURNEYS
        public async Task<List<Journey>> GetJourneysAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
