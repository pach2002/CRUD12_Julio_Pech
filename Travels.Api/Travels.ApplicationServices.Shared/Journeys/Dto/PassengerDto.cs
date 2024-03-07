using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travels.Journeys.Dto
{
    public class PassengerDto
    {

        // id
        // not requires id???
        //public int Id { get; set; }

        // FirstName
        [Required]
        [StringLength(32)]
        public string FirstName { get; set; }

        // LastName
        [Required]
        [StringLength(32)]
        public string LastName { get; set; }

        // Age
        [Required]
        public int Age { get; set; }

        // List of tickets with this passenger
        /*public List<Ticket> Tickets { get; set; }

        public Passenger()
        {
            Tickets = new List<Ticket>();
        }*/
    }
}
