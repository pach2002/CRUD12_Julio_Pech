using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;
using Travels.DataAccess.Repositories;
using Travels.Journeys.Dto;

namespace Travels.ApplicationServices.Passengers
{
    public class PassengersAppService : IPassengersAppService
    {

        // local context of repository
        private readonly IRepository<int, Passenger> _repository;

        // local mapper
        private readonly IMapper _mapper;

        // builder, receive by injection dependency repository
        public PassengersAppService(IRepository<int, Passenger> repository, IMapper mapper)
        {
            // injection dependency of mapper
            _repository = repository;
            _mapper = mapper;
        }

        // ADD NEW PASSENGER
        public async Task<int> AddPassengerAsync(PassengerDto passenger)
        {
            // map passenger
            var passengerMapped = _mapper.Map<Core.Journeys.Passenger>(passenger);

            // recover passenger saved
            Passenger passengerSaved = await _repository.AddAsync(passengerMapped);

            // return id
            return passengerSaved.Id;
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
