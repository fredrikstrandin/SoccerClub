using GraphQL.Types;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation
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
