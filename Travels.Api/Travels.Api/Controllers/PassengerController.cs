using Microsoft.AspNetCore.Mvc;
using Travels.ApplicationServices.Passengers;
using Travels.Core.Journeys;
using Travels.Journeys.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Travels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        // local context
        private readonly IPassengersAppService _passengersAppService;

        // injection dependency
        public PassengerController(IPassengersAppService passengersAppService) 
        {
            _passengersAppService = passengersAppService;
        }

        // GET: api/<PassengerController>
        [HttpGet]
        public async Task<IEnumerable<Passenger>> Get()
        {
            // list of passengers
            List<Passenger> passengers = await _passengersAppService.GetPassengersAsync();
        
            // return passengers
            return passengers;
        }

        // GET api/<PassengerController>/5
        [HttpGet("{id}")]
        public async Task<Passenger> Get(int id)
        {
            // search a passenger
            Passenger passenger = await _passengersAppService.GetPassengerAsync(id);

            // return passenger
            return passenger;

        }

        // POST api/<PassengerController>
        [HttpPost]
        public async Task<int> Post([FromBody] PassengerDto passenger)
        {
            // send body value (PassengerDto) and save id from new row
            int id = await _passengersAppService.AddPassengerAsync(passenger);

            // return id
            return id;
        }

        // PUT api/<PassengerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Passenger passenger)
        {
            // save id into passenger
            passenger.Id = id;

            // insert modify values from body (Passenger)
            await _passengersAppService.EditPassengerAsync(passenger);

            // if was succesful, return 200 status
            return Ok();
        }

        // DELETE api/<PassengerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // delete by id
            await _passengersAppService.DeletePassengerAsync(id);

            // if was successful, return 200 status
            return Ok();

        }
    }
}
