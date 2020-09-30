using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Repository
{
    public class TeamInMemoryRepository : ITeamRepository
    {
        private readonly List<TeamItem> _teams = new List<TeamItem>()
        {
            new TeamItem() { Id = "1", Name = "Boy 2003" },
            new TeamItem() { Id = "2", Name = "Girl 2009" },
        };

        private readonly List<TeamPlayerItem> _teamPlayers = new List<TeamPlayerItem>()
        {
            new TeamPlayerItem() { TeamId = "1", UserId = "1", type = UserType.Player },
            new TeamPlayerItem() { TeamId = "1", UserId = "2", type = UserType.Player }
        };

        private List<UserItem> _userList = new List<UserItem>() {
                    new UserItem()
                    {
                        Id = "1",
                        FirstName = "Maria",
                        LastName = "Forsman",
                        Biography = "Like the game.",
                        Street = "Hornsgatan 32",
                        ZIP = "131 87",
                        City = "Stockholm",
                        Email = "maria.forsman@spam.com"
                    },
                    new UserItem()
                    {
                        Id = "2",
                        FirstName = "Erik",
                        LastName = "Karlsson",
                        Biography = "For me I like to see player to be better.",
                        Street = "Hornsgatan 32",
                        ZIP = "419 65",
                        City = "Sandviken",
                        Email = "erik.karlsson@spam.com"
                    }
                };

        public Task<List<TeamItem>> GetAsync()
        {
            return Task.FromResult(_teams);
        }

        public Task<TeamItem> GetAsync(string id)
        {
            return Task.FromResult(_teams.Where(x => x.Id == id).FirstOrDefault());
        }

        public Task<List<UserItem>> GetUsersAsync(string teamId, UserType type)
        {
            List<string> playerIds = _teamPlayers.Where(x => x.TeamId == teamId && x.type == type).Select(x => x.UserId).ToList();

            return Task.FromResult(_userList.Where(x => playerIds.Contains(x.Id)).ToList());
        }
    }
}
