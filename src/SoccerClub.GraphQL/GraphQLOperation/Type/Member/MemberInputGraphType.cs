using GraphQL.Types;
using SoccerClub.GraphQLServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQLServer.GraphQLOperation.Type.Member
{
    public class MemberInputGraphType : InputObjectGraphType<MemberInputItem>
    {
        public MemberInputGraphType() 
        {
            Name = "memberInput";

            Field(x => x.FirstName, nullable: false).Name("first_name");
            Field(x => x.LastName, nullable: false).Name("last_name");

            Field(x => x.Born, nullable: true).Name("born");
            Field(x => x.Email, nullable: true).Name("email");
            
            Field(x => x.Street, nullable: true).Name("street");
            Field(x => x.ZIP, nullable: true).Name("zip");
            Field(x => x.City, nullable: true).Name("city");
        }
    }
}
