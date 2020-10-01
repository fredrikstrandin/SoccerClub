using GraphQL;
using GraphQL.Types;
using SoccerClub.GraphQL.GraphQLOperation.Type.Member;
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
        public SoccerClubMutation(IMemberService memberService)
        {
            FieldAsync<MemberType>(
                "createMember",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MemberInputType>> { Name = "member" }),
                resolve: async context =>
                {
                    var profile = context.GetArgument<MemberInputItem>("member");
                    return await context.TryAsyncResolve(
                        async c => await memberService.CreateAsync(profile));
                });
        }
    }
}
