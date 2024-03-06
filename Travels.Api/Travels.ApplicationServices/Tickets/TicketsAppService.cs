using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;
using Travels.DataAccess.Repositories;

namespace Travels.ApplicationServices.Tickets
{
    public class TicketsAppService : ITicketsAppService
    {

        // local context of repository
        private readonly IRepository<int, Ticket> _repository;

        // builder, receive by injection dependency repository
        public TicketsAppService(IRepository<int, Ticket> repository)
        {
            _repository = repository;
        }

        // ADD NEW TICKET
        public async Task<int> AddTicketAsync(Ticket ticket)
        {
            await _repository.AddAsync(ticket);

            return ticket.Id;
        }

        // DELETE TICKET
        public async Task DeleteTicketAsync(int ticketId)
        {
            await _repository.DeleteAsync(ticketId);
        }

        // EDIT TICKET
        public async Task EditTicketAsync(Ticket ticket)
        {
            await _repository.UpdateAsync(ticket);
        }

        // GET TICKET BY ID
        public async Task<Ticket> GetTicketAsync(int ticketId)
        {
            return await _repository.GetAsync(ticketId);
        }

        // GET LIST OF TICKETS
        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
