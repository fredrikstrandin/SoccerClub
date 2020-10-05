using GraphQL.Types;
using SoccerClub.GraphQLServer.GraphQLOperation.Type.Member;
using SoccerClub.GraphQLServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQLServer.GraphQLOperation.Type.Team
{
    public class MemberTeamIdGraphType : BaseMemberGraphType<MemberTeamIdItem>
    {
        public MemberTeamIdGraphType() : base()
        {
            Field<RoleEnumGraphType>("role");
        }
    }
}
