using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Model
{
    public class TeamInputItem
    {
        public string Name { get; set; }
        public int AgeGroup { get; set; }
        public List<TeamMemberInputItem> Members { get; set; }
    }
}
