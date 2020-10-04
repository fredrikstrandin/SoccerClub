using GraphQL;
using GraphQL.Types;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation.Type.Member
{
    public class MemberGraphType : ObjectGraphType<MemberItem>
    {
        public MemberGraphType()
        {
            Field(t => t.Id).Name("id").Description("Id for member");
            Field(t => t.FirstName).Name("first_name").Description("Member first name");
            Field(t => t.LastName).Name("last_name").Description("Member last name"); ;
            Field<StringGraphType>(
                "full_name",
                "Member full name",
                resolve: context =>
                {
                    return $"{context.Source.FirstName} {context.Source.LastName}";
                }
            );

            Field(t => t.Born, nullable: true).Name("born").Description("Member email");
            Field<BooleanGraphType>(
                "is_birthday",
                "If it is members birthday or not",
                resolve: context =>
                {
                    // In order for this to be correct, you must retrieve the user's time zone and compare.
                    // But I make it easy for myself and assume the member is in Western Europe
                    DateTime date = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(1)).Date;

                    return context.Source.Born.Month == date.Month && context.Source.Born.Day == date.Day;
                }
            );
            
            Field(t => t.Email, nullable: true).Name("email").Description("Member email");

            Field(t => t.Street, nullable: true).Name("street").Description("Member street");
            Field(t => t.ZIP, nullable: true).Name("zip_code").Description("Member ZIP code");
            Field(t => t.City, nullable: true).Name("city").Description("Member city");
        }
    }
}
