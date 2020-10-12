﻿using GraphQL;
using GraphQL.Execution;
using GraphQL.Types;
using GraphQL.Validation.Rules;
using SoccerClub.GraphQL.GraphQLOperation.Type.Member;
using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQLServer.GraphQLOperation.Type.Member;
using SoccerClub.GraphQLServer.Interface;
using SoccerClub.GraphQLServer.Model;
using System;

namespace SoccerClub.GraphQLServer.GraphQLOperation
{
    public class SoccerClubQuery : ObjectGraphType
    {
        public SoccerClubQuery(IMemberService memberService, ITeamService teamService)
        {
            FieldAsync<ListGraphType<MemberGraphType>>(
                "members",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "skip", Description = "How many member will be skip from start." },
                    new QueryArgument<IntGraphType> { Name = "take", Description = "How many members will be returned." }),

                resolve: async context =>
                {
                    var skip = context.GetArgument<int?>("skip");
                    var take = context.GetArgument<int?>("take");

                    return await memberService.GetAsync(skip, take);
                }
            );

            FieldAsync<MemberGraphType>(
                "member",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id", }),
                resolve: async context =>
                {
                    var id = context.GetArgument<string>("member_id");
                    return await memberService.GetAsync(id);
                }
            );

            FieldAsync<ListGraphType<TeamGraphType>>(
                "teams",
                resolve: async context =>
                {
                    return await teamService.GetAsync();
                }
            );
        }
    }
}