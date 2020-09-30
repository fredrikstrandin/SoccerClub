using GraphQL.Types;
using SoccerClub.GraphQL.GraphQLOperation.Type.User;
using SoccerClub.GraphQL.Model;
using System.Collections.Generic;

namespace SoccerClub.GraphQL.GraphQLOperation
{
    public class NordicLightQuery : ObjectGraphType
    {
        public NordicLightQuery()
        {
            Field<ListGraphType<UserType>>(
                "members",
                resolve: context => new List<UserItem>() {
                    new UserItem()
                    {
                        Id = "1",
                        FirstName = "Maria",
                        LastName = "Forsman",
                        Biography = "Like the game.",
                        Street = "Hornsgatan 32",
                        ZIP = "131 87",
                        City = "Stockholm",
                        Email = "maria.forsman@spam.com"
                    },
                    new UserItem()
                    {
                        Id = "2",
                        FirstName = "Erik",
                        LastName = "Karlsson",
                        Biography = "For me I like to see player to be better.",
                        Street = "Hornsgatan 32",
                        ZIP = "419 65",
                        City = "Sandviken",
                        Email = "erik.karlsson@spam.com"
                    }
                }
            );
        }
    }
}