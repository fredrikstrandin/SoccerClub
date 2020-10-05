using GraphQL.Types;
using SoccerClub.GraphQLServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQLServer.GraphQLOperation.Type.Team
{
    public class TeamInputGraphType : InputObjectGraphType<TeamInputItem>
    {
        public TeamInputGraphType()
        {
            Name = "teamInput";

            Field< NonNullGraphType<StringGraphType>>("name");
            Field(x => x.AgeGroup, nullable: false).Name("age_group");
            Field<ListGraphType<TeamMemberInputGraphType>>("members");
        }
    }
}
