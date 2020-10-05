using SoccerClub.GraphQLServer.GraphQLOperation.Type.Member;
using SoccerClub.GraphQLServer.Model;

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
