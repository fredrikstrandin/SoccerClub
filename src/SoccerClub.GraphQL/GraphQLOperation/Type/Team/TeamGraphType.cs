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
    public class TeamGraphType : ObjectGraphType<TeamItem>
    {
        public TeamGraphType(IMemberService memberService, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id, nullable: false).Name("id").Description("Id for the team");
            Field(t => t.Name, nullable: false).Name("name").Description("Team name");
            Field(t => t.AgeGroup, nullable: false).Name("age_group").Description("The age of the age group");

            Field<ListGraphType<MemberGraphType>>(
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
            Field<ListGraphType<MemberGraphType>>(
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
