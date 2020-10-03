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
            new TeamItem() 
            { 
                Id = "1", 
                Name = "Boy 2003",
                Members = new List<TeamMemberItem>()
                {
                    new TeamMemberItem() { MemberId = "1", FirstName = "Maria", LastName = "Forsman", Type = RoleType.Player },
                    new TeamMemberItem() { MemberId = "3", FirstName = "Eva", LastName = "Lindskog", Type = RoleType.Player }
                }
            },
            new TeamItem() { Id = "2", 
                Name = "Girl 2009",
                //Members = new List<TeamMemberItem>()
                //{
                //    new TeamMemberItem() { MemberId = "2", FirstName = "Erik", LastName = "Karlsson", Type = RoleType.Player }
                //}
            },
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
                Born = DateTime.UtcNow.AddDays(365* 9 - 18),
                Email = "maria.forsman@spam.com"
            },
            new MemberItem()
            {
                Id = "2",
                FirstName = "Erik",
                LastName = "Karlsson",
                Street = "Hornsgatan 32",
                ZIP = "145 23",
                City = "Stockholm",
                //He will always has birthday ;)
                Born = DateTime.UtcNow.AddYears(-9),
                Email = "erik.karlsson@spam.com"
            },
            new MemberItem()
            {
                Id = "3",
                FirstName = "Eva",
                LastName = "Lindskog",
                Street = "Oskarsgata 34",
                ZIP = "123 45",
                City = "Stockholm",
                Born = DateTime.UtcNow.AddDays(365* 9 + 42),
                Email = "eva.lindskog@spam.com"
            }
        };
    }
}
