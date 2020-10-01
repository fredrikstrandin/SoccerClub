using GraphQL.Types;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation.Type.Member
{
    public class MemberInputType : InputObjectGraphType<MemberInputItem>
    {
        public MemberInputType() 
        {
            Name = "memberInput";

            Field(x => x.FirstName, nullable: false).Name("first_name");
            Field(x => x.LastName, nullable: false).Name("last_name");

            Field(x => x.Email, nullable: true).Name("email");
            
            Field(x => x.Street, nullable: true).Name("street");
            Field(x => x.ZIP, nullable: true).Name("zip");
            Field(x => x.City, nullable: true).Name("city");
        }
    }
}
