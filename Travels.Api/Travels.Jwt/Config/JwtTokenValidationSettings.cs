using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travels.Jwt.Config
{
    public class JwtTokenValidationSettings
    {
        // who send
        public string ValidIssuer { get; set; }

        // who's valid
        public string ValidAudience { get; set; }

        // key
        public string SecretKey { get; set; }

        // in minutes
        public int Duration { get; set; }
    }
    
}
