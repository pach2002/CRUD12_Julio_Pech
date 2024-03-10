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

namespace Travels.ApplicationServices.Tickets
{
    public class TicketsAppService : ITicketsAppService
    {

        // local context of repository
        private readonly IRepository<int, Ticket> _repository;

        // local mapper
        private readonly IMapper _mapper;

        // builder, receive by injection dependency repository and mapper
        public TicketsAppService(IRepository<int, Ticket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // ADD NEW TICKET
        public async Task<int> AddTicketAsync(TicketDto ticket)
        {
            // map ticket with dto
            var ticketMapped = _mapper.Map<Core.Journeys.Ticket>(ticket);

            // recover ticket saved
            Ticket ticketSaved = await _repository.AddAsync(ticketMapped);

            //await _repository.AddAsync(ticketSaved);

            return ticketSaved.Id;
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
