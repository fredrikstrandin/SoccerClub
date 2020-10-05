using GraphQL;
using GraphQL.Types;
using SoccerClub.GraphQLServer.GraphQLOperation.Type.Member;
using SoccerClub.GraphQLServer.GraphQLOperation.Type.Team;
using SoccerClub.GraphQLServer.Interface;
using SoccerClub.GraphQLServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQLServer.GraphQLOperation
{
    public class SoccerClubMutation : ObjectGraphType
    {
        public SoccerClubMutation(IMemberService memberService, ITeamService teamService)
        {
            FieldAsync<IdGraphType>(
             "createTema",
             arguments: new QueryArguments(
                 new QueryArgument<NonNullGraphType<TeamInputGraphType>> { Name = "team" }),
             resolve: async context =>
             {
                 TeamInputItem team = context.GetArgument<TeamInputItem>("team");
                 return await context.TryAsyncResolve(
                     async c => await teamService.CreateAsync(team));
             });

            FieldAsync<IdGraphType>(
                "createMember",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MemberInputGraphType>> { Name = "member" }),
                resolve: async context =>
                {
                    var profile = context.GetArgument<MemberInputItem>("member");
                    return await context.TryAsyncResolve(
                        async c => await memberService.CreateAsync(profile));
                });
        }
    }
}
