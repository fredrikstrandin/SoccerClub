using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.IntegrationTests.Models
{
    public class MemeberItem
    {
        public Member member { get; set; }
    }

    public class Member
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
    }
}
