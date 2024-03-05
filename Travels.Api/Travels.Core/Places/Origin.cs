using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travels.Core.Journeys;

namespace Travels.Core.Places
{
    public class Origin
    {
        // id
        [Key]
        public int Id { get; set; }

        // Dest Name
        [StringLength(50)]
        public string Name { get; set; }
        
        // List of journeys with this origin
        public List<Journey> Journeys { get; set; }
        public Origin()
        {
            Journeys = new List<Journey>();
        }
    }
}
