using GraphQL.Types;
using SoccerClub.GraphQL.GraphQLOperation.Type.User;
using SoccerClub.GraphQL.Interface;

namespace SoccerClub.GraphQL.GraphQLOperation
{
    public class NordicLightQuery : ObjectGraphType
    {        
        public NordicLightQuery(IUserService userService, ITeamService teamService)
        {
            Field<ListGraphType<TeamType>>(
                "members",
                resolve: context => userService.GetAsync()
            );

            Field<ListGraphType<TeamType>>(
                "teams",
                resolve: context => teamService.GetAsync()
            );
        }
    }
}