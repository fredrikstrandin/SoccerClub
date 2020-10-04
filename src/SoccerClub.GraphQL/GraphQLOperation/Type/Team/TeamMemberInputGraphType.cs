using GraphQL.Types;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation.Type.Team
{
    public class TeamMemberInputGraphType : InputObjectGraphType<TeamMemberInputItem>
    {
        public TeamMemberInputGraphType()
        {
            Name = "team_memberInput";

            Field(x => x.MemberId, nullable: false).Name("member_id");
            Field(x => x.Type, nullable: false).Name("type");
        }
    }
}
