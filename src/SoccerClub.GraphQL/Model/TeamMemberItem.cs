using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Model
{
    public class TeamMemberItem
    {
        public string MemberId { get; set; }
        public RoleType Type { get; set; }
    }
}
