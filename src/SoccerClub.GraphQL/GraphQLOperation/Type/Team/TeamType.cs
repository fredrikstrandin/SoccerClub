using GraphQL.Types;
using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.GraphQLOperation.Type.User
{
    public class TeamType : ObjectGraphType<TeamItem>
    {
        public TeamType(ITeamService teamService)
        {
            Field(t => t.Id).Name("id").Description("Id for the team");
            Field(t => t.Name).Name("name").Description("Team name");
            Field<ListGraphType<UserType>>(
                "trainers",
                "Trainer info",
                resolve: context => teamService.GetUsersAsync(context.Source.Id, Model.UserType.Trainer)
            );
            Field< ListGraphType<UserType>>(
                "players",
                "Player info",
                resolve: context => teamService.GetUsersAsync(context.Source.Id, Model.UserType.Player)
            );
        }
    }
}
