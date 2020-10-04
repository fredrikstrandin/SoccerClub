using GraphQL;
using GraphQL.Types;
using SoccerClub.GraphQL.GraphQLOperation.Type.Member;
using SoccerClub.GraphQL.GraphQLOperation.Type.Team;
using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation
{
    public class SoccerClubMutation : ObjectGraphType
    {
        public SoccerClubMutation(IMemberService memberService, ITeamService teamService)
        {
            FieldAsync<StringGraphType>(
             "createTema",
             arguments: new QueryArguments(
                 new QueryArgument<NonNullGraphType<TeamInputGraphType>> { Name = "team" }),
             resolve: async context =>
             {
                 var team = context.GetArgument<TeamInputItem>("team");
                 return await context.TryAsyncResolve(
                     async c => await teamService.CreateAsync(team));
             });

            FieldAsync<StringGraphType>(
                "createMember",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TeamInputGraphType>> { Name = "member" }),
                resolve: async context =>
                {
                    var profile = context.GetArgument<MemberInputItem>("member");
                    return await context.TryAsyncResolve(
                        async c => await memberService.CreateAsync(profile));
                });
        }
    }
}
