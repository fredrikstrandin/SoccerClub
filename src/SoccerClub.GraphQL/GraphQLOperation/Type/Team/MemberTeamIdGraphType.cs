using GraphQL.Types;
using SoccerClub.GraphQL.GraphQLOperation.Type.Member;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation.Type.Team
{
    public class MemberTeamIdGraphType : BaseMemberGraphType<MemberTeamIdItem>
    {
        public MemberTeamIdGraphType() : base()
        {
            Field<RoleEnumGraphType>("role");
        }
    }
}
