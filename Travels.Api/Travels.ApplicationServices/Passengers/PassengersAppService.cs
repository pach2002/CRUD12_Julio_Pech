using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;
using Travels.DataAccess.Repositories;

namespace Travels.ApplicationServices.Passengers
{
    public class PassengersAppService : IPassengersAppService
    {

        // local context of repository
        private readonly IRepository<int, Passenger> _repository;

        // builder, receive by injection dependency repository
        public PassengersAppService(IRepository<int, Passenger> repository)
        {
            _repository = repository;
        }

        // ADD NEW PASSENGER
        public async Task<int> AddPassengerAsync(Passenger passenger)
        {
            await _repository.AddAsync(passenger);

            return passenger.Id;
        }

        // DELETE PASSENGER
        public async Task DeletePassengerAsync(int PassengerId)
        {
            await _repository.DeleteAsync(PassengerId);
        }

        // EDIT PASSENGER
        public async Task EditPassengerAsync(Passenger passenger)
        {
            await _repository.UpdateAsync(passenger);
        }

        // GET PASSENGER BY ID
        public async Task<Passenger> GetPassengerAsync(int passengerId)
        {
            return await _repository.GetAsync(passengerId);
        }

        // GET LIST OF PASSENGERS
        public async Task<List<Passenger>> GetPassengersAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
