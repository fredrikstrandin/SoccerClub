using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Repository
{
    public class UserInMemoryRepository : IUserRepository
    {
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

        public Task<List<UserItem>> Get()
        {
            return Task.FromResult(_userList);
        }

        public Task<UserItem> Get(string id)
        {
            return Task.FromResult(_userList.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
