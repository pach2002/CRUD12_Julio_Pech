using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;

namespace Travels.Core.Places
{
    public class Destination
    {
        // id
        [Key]
        public int Id { get; set; }

        // Dest Name
        [StringLength(50)]
        public string Name { get; set; }

        // List of journeys with this destination
        public List<Journey> Journeys { get; set; }
        public Destination()
        {
            Journeys = new List<Journey>();
        }
    }
}
