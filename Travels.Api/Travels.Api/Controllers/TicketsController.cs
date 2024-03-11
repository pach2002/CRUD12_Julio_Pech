using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travels.ApplicationServices.Tickets;
using Travels.Core.Journeys;
using Travels.Journeys.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Travels.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        // local 
        private readonly ITicketsAppService _ticketsAppService;

        // injection dependency
        public TicketsController(ITicketsAppService ticketsAppService) 
        {
            _ticketsAppService = ticketsAppService;
        }

        // GET: api/<TicketsController>
        [HttpGet]
        public async Task<IEnumerable<Ticket>> Get()
        {
            // get all
            List<Ticket> tickets = await _ticketsAppService.GetTicketsAsync();
            return tickets;
        }

        // GET api/<TicketsController>/5
        [HttpGet("{id}")]
        public async Task<Ticket> Get(int id)
        {
            // get by id
            Ticket ticket = await _ticketsAppService.GetTicketAsync(id);

            return ticket;
        }

        // POST api/<TicketsController>
        [HttpPost]
        public async Task<int> Post([FromBody] TicketDto ticket)
        {

            // send body 
            int id = await _ticketsAppService.AddTicketAsync(ticket);

            // return id
            return id;

        }


        // PUT api/<TicketsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ticket ticket)
        {

            // save id in object
            ticket.Id = id;

            // insert modified row
            await _ticketsAppService.EditTicketAsync(ticket);

            // if was successful return ok status
            return Ok();
        }

        // DELETE api/<TicketsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // delete by id
            await _ticketsAppService.DeleteTicketAsync(id);

            // if was successful return 200 status
            return Ok();
        }
    }
}
