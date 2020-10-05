using GraphQL;
using GraphQLParser.AST;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
