using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travels.Journeys.Dto
{
    public class JourneyDto
    {
        // id
        public int Id { get; set; }

        // Destination id
        //public Destination Destination { get; set; }
        public int DestinationId { get; set; }

        // -------------------------------------------------

        // Origin Id
        //public Origin Origin { get; set; }
        public int OriginId { get; set; }

        // -------------------------------------------------

        // Departure Date
        [Required]
        public DateTime Departure { get; set; }

        // Arrival Date
        [Required]
        public DateTime Arrival { get; set; }

        // List of tickets with this journey
        //public List<Ticket> Tickets { get; set; }

        //public Journey()
        /*{
            Tickets = new List<Ticket>();
        }*/
    }
}
