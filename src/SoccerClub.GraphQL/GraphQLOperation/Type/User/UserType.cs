using GraphQL.Types;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation.Type.Member
{
    public class MemberType : ObjectGraphType<MemberItem>
    {
        public MemberType()
        {
            Field(t => t.Id).Name("id").Description("Id for member");
            Field(t => t.FirstName).Name("first_name").Description("Member first name");
            Field(t => t.LastName).Name("last_name").Description("Member last name"); ;
            Field<StringGraphType>(
                "full_name",
                "Member full name",
                resolve: context => $"{context.Source.FirstName} {context.Source.LastName}"
            );

            Field(t => t.Biography, nullable: true).Name("about").Description("description of the member");

            Field(t => t.Email, nullable: true).Name("email").Description("Member email");
            
            Field(t => t.Street, nullable: true).Name("street").Description("Member street");
            Field(t => t.ZIP, nullable: true).Name("zip_code").Description("Member ZIP code");
            Field(t => t.City, nullable: true).Name("city").Description("Member city");            
        }
    }
}
