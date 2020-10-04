using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public Task<string> CreateAsync(MemberInputItem item)
        {
            return _memberRepository.CreateAsync(item);
        }

        public Task<List<MemberItem>> GetAsync(int? skip, int? take)
        {
            return _memberRepository.GetAsync(skip, take);
        }

        public Task<MemberItem> GetAsync(string id)
        {
            return _memberRepository.GetAsync(id);
        }

        public async Task<ILookup<string, MemberTeamIdItem>> GetAllAsync(IEnumerable<string> ids, CancellationToken cancellationToken)
        {
            return await _memberRepository.GetLookupAsync(ids, RoleEnum.Officials, cancellationToken);            
        }

        public async Task<ILookup<string, MemberTeamIdItem>> GetOfficialsAsync(IEnumerable<string> ids, CancellationToken cancellationToken)
        {
            return await _memberRepository.GetLookupAsync(ids, RoleEnum.Officials, cancellationToken);
        }

        public async Task<ILookup<string, MemberTeamIdItem>> GetParentsAsync(IEnumerable<string> ids, CancellationToken cancellationToken)
        {
            return await _memberRepository.GetLookupAsync(ids, RoleEnum.Parent, cancellationToken);
        }

        public async Task<ILookup<string, MemberTeamIdItem>> GetPlayersAsync(IEnumerable<string> ids, CancellationToken cancellationToken)
        {
            return await _memberRepository.GetLookupAsync(ids, RoleEnum.Player, cancellationToken);
        }

        public async Task<ILookup<string, MemberTeamIdItem>> GetTrainersAsync(IEnumerable<string> ids, CancellationToken cancellationToken)
        {
            return await _memberRepository.GetLookupAsync(ids, RoleEnum.Trainer, cancellationToken);
        }
    }
}
