using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using SoccerClub.GraphQL.GraphQLOperation.Type.Team;
using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation.Type.Member
{
    public class TeamGraphType : ObjectGraphType<TeamItem>
    {
        public TeamGraphType(IMemberService memberService, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id, nullable: false).Name("id").Description("Id for the team");
            Field(t => t.Name, nullable: false).Name("name").Description("Team name");
            Field(t => t.AgeGroup, nullable: false).Name("age_group").Description("The age of the age group");

            Field<ListGraphType<MemberTeamIdGraphType>>(
                "members",
                "Members info",
                arguments: new QueryArguments(
                 new QueryArgument<RoleEnumGraphType> { Name = "role" }),
                resolve: context =>
                {
                    RoleEnum? team = context.GetArgument<RoleEnum>("role");

                    Func<IEnumerable<string>, CancellationToken, Task<ILookup<string, MemberTeamIdItem>>> func = null;
                    if (team.HasValue)
                    {
                        switch (team)
                        {
                            case RoleEnum.Player:
                                func = memberService.GetPlayersAsync;
                                break;
                            case RoleEnum.Trainer:
                                func = memberService.GetTrainersAsync;
                                break;
                            case RoleEnum.Officials:
                                func = memberService.GetOfficialsAsync;
                                break;
                            case RoleEnum.Parent:
                                func = memberService.GetParentsAsync;
                                break;
                            default:
                                throw new NotImplementedException($"{team} is not implemented for members");
                        }
                    }
                    else
                    {
                        func = memberService.GetAllAsync;
                    }
                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader(
                            "GetAllMembers", func);

                    return loader.LoadAsync(context.Source.Id);
                }
            );
            Field<ListGraphType<MemberTeamIdGraphType>>(
                "trainers",
                "Trainers info",
                resolve: context =>
                {
                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<string, MemberTeamIdItem>(
                            "GetTrainers", memberService.GetTrainersAsync);

                    return loader.LoadAsync(context.Source.Id);
                }
            );
            Field<ListGraphType<MemberGraphType>>(
                "players",
                "Player info",
                resolve: context =>
                 {
                     var loader =
                         dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<string, MemberTeamIdItem>(
                             "GetMemberPlayers", memberService.GetPlayersAsync);

                     return loader.LoadAsync(context.Source.Id);
                 }
            );
            Field<ListGraphType<MemberGraphType>>(
                "officials",
                "Official info",
                resolve: context =>
                {
                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<string, MemberTeamIdItem>(
                            "GetMemberOfficials", memberService.GetOfficialsAsync);

                    return loader.LoadAsync(context.Source.Id);
                }
            );
        }
    }
}
