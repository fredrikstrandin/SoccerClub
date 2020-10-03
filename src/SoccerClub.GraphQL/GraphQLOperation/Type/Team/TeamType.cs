using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation.Type.Member
{
    public class TeamType : ObjectGraphType<TeamItem>
    {
        public TeamType(IMemberService memberService, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id).Name("id").Description("Id for the team");
            Field(t => t.Name).Name("name").Description("Team name");
            Field<ListGraphType<MemberType>>(
                "trainers",
                "Trainer info",
                resolve: context =>
                {
                    if (context.Source.Members == null)
                    {
                        return new List<MemberItem>();
                    }

                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<string, MemberTeamIdItem>(
                            "GetMemberId", memberService.GetLookupAsync);

                    return loader.LoadAsync(context.Source.Id);
                }
            );
            Field<ListGraphType<MemberType>>(
                "players",
                "Player info",
                resolve: context =>
                 {
                     if (context.Source.Members == null)
                     {
                         return new List<MemberItem>();
                     }

                     var loader =
                         dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<string, MemberTeamIdItem>(
                             "GetMembersId", memberService.GetLookupAsync);

                     return loader.LoadAsync(context.Source.Id);
                 }
            );
        }
    }
}
