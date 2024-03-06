using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;

namespace Travels.ApplicationServices.Tickets
{
    public interface ITicketsAppService
    {
        // Async access methods to Tickets table

        // Get All
        Task<List<Ticket>> GetTicketsAsync();

        // Add
        Task<int> AddTicketAsync(Ticket ticket);

        // Delete
        Task DeleteTicketAsync(int ticketId);

        // Get
        Task<Ticket> GetTicketAsync(int ticketId);

        // Update
        Task EditTicketAsync(Ticket ticket);

    }
}

