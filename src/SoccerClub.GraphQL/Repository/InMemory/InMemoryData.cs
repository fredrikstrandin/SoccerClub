using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Repository.InMemory
{
    public class InMemoryData
    {
        private int _nextNo = 2;

        public string NextId { get { return (++_nextNo).ToString(); }  }

        public List<TeamItem> Teams { get; set; } = new List<TeamItem>()
        {
            new TeamItem() { Id = "1", Name = "Boy 2003" },
            new TeamItem() { Id = "2", Name = "Girl 2009" },
        };

        public List<TeamPlayerItem> TeamPlayers { get; set; } = new List<TeamPlayerItem>()
        {
            new TeamPlayerItem() { TeamId = "1", MemberId = "1", type = RoleType.Player },
            new TeamPlayerItem() { TeamId = "1", MemberId = "2", type = RoleType.Player }
        };

        public List<MemberItem> MemberList { get; set; } = new List<MemberItem>()
        {
            new MemberItem()
            {
                Id = "1",
                FirstName = "Maria",
                LastName = "Forsman",
                Street = "Hornsgatan 32",
                ZIP = "131 87",
                City = "Stockholm",
                Email = "maria.forsman@spam.com"
            },
            new MemberItem()
            {
                Id = "2",
                FirstName = "Erik",
                LastName = "Karlsson",
                Street = "Hornsgatan 32",
                ZIP = "419 65",
                City = "Sandviken",
                Email = "erik.karlsson@spam.com"
            }
        };
    }
}
