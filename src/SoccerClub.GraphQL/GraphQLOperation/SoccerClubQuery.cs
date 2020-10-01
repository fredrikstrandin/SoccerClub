using GraphQL;
using GraphQL.Types;
using SoccerClub.GraphQL.GraphQLOperation.Type.Member;
using SoccerClub.GraphQL.Interface;

namespace SoccerClub.GraphQL.GraphQLOperation
{
    public class SoccerClubQuery : ObjectGraphType
    {        
        public SoccerClubQuery(IMemberService memberService, ITeamService teamService)
        {
            FieldAsync<ListGraphType<MemberType>>(
                "members",
                resolve: async context =>
                {
                    return await context.TryAsyncResolve(
                        async c => await memberService.GetAsync());
                }
            );

            FieldAsync<MemberType>(
                "member",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "member_id", }),
                resolve: async context =>
                {
                    var id = context.GetArgument<string>("member_id");
                    return await context.TryAsyncResolve(
                        async c => await memberService.GetAsync(id));
                }
            );

            Field<ListGraphType<TeamType>>(
                "teams",
                resolve: context => teamService.GetAsync()
            );
        }
    }
}