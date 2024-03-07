using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using Travels.ApplicationServices.Journeys;
using Travels.Core.Journeys;
using Travels.DataAccess.Repositories;
using Travels.Journeys.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Travels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        // local 
        private IJourneysAppService _journeysAppService;

        // injection dependency
        public JourneyController(IJourneysAppService journeysAppService) 
        {
            _journeysAppService = journeysAppService;
        }

        // GET: api/<JourneyController>
        [HttpGet]
        public async Task<IEnumerable<Journey>> Get() // modified as async method
        {
            // Working on !!
            // Journey List
            List<Journey> journeys = await _journeysAppService.GetJourneysAsync();

            return journeys;
        }

        // GET api/<JourneyController>/5
        [HttpGet("{id}")]
        public async Task<Journey> Get(int id)
        {
            // Working on !!
            // a journey
            Journey journey = await _journeysAppService.GetJourneyAsync(id);

            return journey;
        }

        // POST api/<JourneyController>
        [HttpPost]
        public async Task<int> Post([FromBody] JourneyDto journey)
        {
            // Working on !!

            // save and return new journey id
            int id = await _journeysAppService.AddJourneyAsync(journey);

            // show new id
            return id;
        }

        // PUT api/<JourneyController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Journey journey)
        {
            // TODO: put working on, check for errors

            // save id into Journey object
            journey.Id = id;

            // edit journey by id
            await _journeysAppService.EditJourneyAsync(journey);

            // if was successful, return 200 status
            return Ok();
            
        }

        // DELETE api/<JourneyController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // delete working on !!
            await _journeysAppService.DeleteJourneyAsync(id);

            // if was successful, return 200 status
            return Ok();

        }
    }
}
