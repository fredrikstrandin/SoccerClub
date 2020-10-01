using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public Task<MemberItem> CreateAsync(MemberInputItem item)
        {
            return _memberRepository.CreateAsync(item);
        }

        public Task<List<MemberItem>> GetAsync()
        {
            return _memberRepository.GetAsync();
        }

        public Task<MemberItem> GetAsync(string id)
        {
            return _memberRepository.GetAsync(id);
        }
    }
}
