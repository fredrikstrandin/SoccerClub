﻿using System;

namespace SoccerClub.GraphQLServer.Model
{
    public class MemberInputItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Born { get; set; }
        public string Email { get; set; }

        public string Street { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
    }
}
