using GraphQL.Types;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation.Type.Team
{
    public class TeamInputGraphType : InputObjectGraphType<TeamInputItem>
    {
        public TeamInputGraphType()
        {
            Name = "teamInput";

            Field(x => x.Name, nullable: false).Name("name");
            Field(x => x.AgeGroup, nullable: false).Name("age_group");
            Field(x => x.Members, nullable: false).Name("members");
        }
    }
}
