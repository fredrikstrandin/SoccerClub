using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace SoccerClub.GraphQLServer.GraphQLOperation
{
    public class SoccerClubSchema : Schema
    {
        public SoccerClubSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<SoccerClubQuery>();
            Mutation = serviceProvider.GetRequiredService<SoccerClubMutation>();

            Description = "The schema for the Soccer Club";

        }
    }
}
