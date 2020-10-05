using GraphQL.Types;
using SoccerClub.GraphQLServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQLServer.GraphQLOperation.Type.Team
{
    public class TeamMemberInputGraphType : InputObjectGraphType<TeamMemberInputItem>
    {
        public TeamMemberInputGraphType()
        {
            Name = "team_memberInput";

            Field(x => x.MemberId, nullable: false).Name("member_id");
            Field<RoleEnumGraphType>("role", "Members role in the team");
        }
    }
}
