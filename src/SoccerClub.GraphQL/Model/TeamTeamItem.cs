using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Model
{
    public class TeamPlayerItem
    {
        public string TeamId { get; set; }
        public string UserId { get; set; }
        public UserType type { get; set; }
    }
}
