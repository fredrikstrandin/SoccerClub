using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQLServer.Model
{
    public class TeamItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int AgeGroup { get; set; }
        public List<TeamMemberItem> Members { get; set; }
        public List<ActivityItem> Activitys { get; set; }
        
    }
}
