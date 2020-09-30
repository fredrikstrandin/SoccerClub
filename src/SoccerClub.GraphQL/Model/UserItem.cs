using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Model
{
    public class UserItem
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
        
        public string Street { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


    }
}
