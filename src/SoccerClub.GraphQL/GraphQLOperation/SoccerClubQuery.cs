using GraphQL.Types;
using SoccerClub.GraphQL.GraphQLOperation.Type.Member;
using SoccerClub.GraphQL.Interface;

namespace SoccerClub.GraphQL.GraphQLOperation
{
    public class SoccerClubQuery : ObjectGraphType
    {        
        public SoccerClubQuery(IMemberService memberService, ITeamService teamService)
        {
            Field<ListGraphType<TeamType>>(
                "members",
                resolve: context => memberService.GetAsync()
            );

            Field<ListGraphType<TeamType>>(
                "teams",
                resolve: context => teamService.GetAsync()
            );
        }
    }
}