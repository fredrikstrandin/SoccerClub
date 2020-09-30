using GraphQL.Types;
using SoccerClub.GraphQL.GraphQLOperation.Type.User;
using SoccerClub.GraphQL.Interface;

namespace SoccerClub.GraphQL.GraphQLOperation
{
    public class NordicLightQuery : ObjectGraphType
    {        
        public NordicLightQuery(IUserService userService)
        {
            Field<ListGraphType<UserType>>(
                "members",
                resolve: context => userService.Get()
            );
        }
    }
}