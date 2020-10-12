using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SoccerClub.GraphQLServer.Model
{
    public class TeamInputItem
    {
        public string Name { get; set; }
        [JsonPropertyName("age_group")]
        public int AgeGroup { get; set; }
        public List<TeamMemberInputItem> Members { get; set; }
    }
}
