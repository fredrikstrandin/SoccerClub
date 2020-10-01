using GraphQL.Types;
using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation.Type.Member
{
    public class TeamType : ObjectGraphType<TeamItem>
    {
        public TeamType(ITeamService teamService)
        {
            Field(t => t.Id).Name("id").Description("Id for the team");
            Field(t => t.Name).Name("name").Description("Team name");
            Field<ListGraphType<MemberType>>(
                "trainers",
                "Trainer info",
                resolve: context => teamService.GetMembersAsync(context.Source.Id, Model.MemberType.Trainer)
            );
            Field< ListGraphType<MemberType>>(
                "players",
                "Player info",
                resolve: context => teamService.GetMembersAsync(context.Source.Id, Model.MemberType.Player)
            );
        }
    }
}
