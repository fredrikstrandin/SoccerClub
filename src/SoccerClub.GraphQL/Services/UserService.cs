using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<List<UserItem>> Get()
        {
            return _userRepository.Get();
        }

        public Task<UserItem> Get(string id)
        {
            return _userRepository.Get(id);
        }
    }
}
