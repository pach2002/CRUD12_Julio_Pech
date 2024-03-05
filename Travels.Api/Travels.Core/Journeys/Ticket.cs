using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travels.Core.Journeys
{
    public class Ticket
    {

        // id
        [Key]
        public int Id { get; set; }

        // Journey Id
        public Journey Journey { get; set; }
        //public int JourneyId { get; set; }

        // Passenger Id
        public Passenger Passenger { get; set; }
        //public int PassengerId { get; set; }

        // Seat (on trip)
        [Required]
        public int Seat {  get; set; }

    }
}
