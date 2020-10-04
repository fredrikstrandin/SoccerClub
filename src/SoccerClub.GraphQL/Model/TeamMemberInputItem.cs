using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Model
{
    public class TeamMemberInputItem
    {
        public string MemberId { get; set; }
        public RoleEnum Role { get; set; }
    }
}
