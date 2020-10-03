using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using SoccerClub.GraphQL.Repository.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Repository
{
    public class MemberInMemoryRepository : IMemberRepository
    {
        private readonly InMemoryData _data;

        public MemberInMemoryRepository(InMemoryData data)
        {
            _data = data;
        }

        public Task<MemberItem> CreateAsync(MemberInputItem item)
        {
            string id = _data.NextId;
            _data.MemberList.Add(new MemberItem()
            {
                Id = id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,

                Street = item.Street,
                ZIP = item.ZIP,
                City = item.City,
            });
            

            return Task.FromResult(new MemberItem() { Id = id, FirstName = item.FirstName, LastName = item.LastName });
        }

        public Task<List<MemberItem>> GetAsync()
        {
            return Task.FromResult(_data.MemberList);
        }

        public Task<MemberItem> GetAsync(string id)
        {
            return Task.FromResult(_data.MemberList.Where(x => x.Id == id).FirstOrDefault());
        }

        public Task<List<MemberItem>> GetAsync(IEnumerable<string> ids)
        {
            List<MemberItem> members = new List<MemberItem>();
            foreach (string id in ids)
            {
                var member = _data.MemberList.Where(x => x.Id == id).FirstOrDefault();

                if(member != null)
                {
                    members.Add(member);
                }
            }

            return Task.FromResult(members);
        }
    }
}
