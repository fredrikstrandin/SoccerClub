using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Repository
{
    public class MemberInMemoryRepository : IMemberRepository
    {
        private List<MemberItem> _memberList = new List<MemberItem>() {
                    new MemberItem()
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
                    new MemberItem()
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

        public MemberInMemoryRepository()
        {
        }

        public Task<List<MemberItem>> GetAsync()
        {
            return Task.FromResult(_memberList);
        }

        public Task<MemberItem> GetAsync(string id)
        {
            return Task.FromResult(_memberList.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
