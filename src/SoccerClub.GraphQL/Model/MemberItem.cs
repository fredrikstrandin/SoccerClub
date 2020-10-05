using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQLServer.Model
{
    public class MemberItem
    {
        //public MemberItem() { }

        //public MemberItem() { }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Born { get; set; }
        public string Email { get; set; }
        
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
    }

    public class MemberTeamIdItem : MemberItem
    {
        public string TeamId { get; set; }
        public RoleEnum Role { get; set; }
    }
}
