using GraphQL.Types;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation.Type.User
{
    public class UserType : ObjectGraphType<UserItem>
    {
        public UserType()
        {
            Field(t => t.Id).Name("id").Description("Id for user");
            Field(t => t.FirstName).Name("first_name").Description("User first name");
            Field(t => t.LastName).Name("last_name").Description("User last name"); ;
            Field<StringGraphType>(
                "full_name",
                "User full name",
                resolve: context => $"{context.Source.FirstName} {context.Source.LastName}"
            );

            Field(t => t.Biography, nullable: true).Name("about").Description("description of the user");

            Field(t => t.Email, nullable: true).Name("email").Description("User email");
            
            Field(t => t.Street, nullable: true).Name("street").Description("User street");
            Field(t => t.ZIP, nullable: true).Name("zip_code").Description("User ZIP code");
            Field(t => t.City, nullable: true).Name("city").Description("User city");            
        }
    }
}
