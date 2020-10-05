using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQLServer.Model
{
    public class TeamMemberItem
    {
        public string MemberId { get; set; }
        public RoleEnum Role { get; set; }
    }
}
