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
            FieldAsync<IdGraphType>(
             "createTema",
             arguments: new QueryArguments(
                 new QueryArgument<NonNullGraphType<TeamInputGraphType>> { Name = "team" }),
             resolve: async context =>
             {
                 TeamInputItem team = context.GetArgument<TeamInputItem>("team");
                 return await teamService.CreateAsync(team);
             });

            FieldAsync<IdGraphType>(
                "createMember",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MemberInputGraphType>> { Name = "member" }),
                resolve: async context =>
                {
                    var profile = context.GetArgument<MemberInputItem>("member");
                    return await memberService.CreateAsync(profile);
                });
        }
    }
}
