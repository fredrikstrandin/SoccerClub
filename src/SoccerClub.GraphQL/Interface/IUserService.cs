using SoccerClub.GraphQL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Interface
{
    public interface IUserService
    {
        Task<List<UserItem>> Get();
        Task<UserItem> Get(string id);
    }
}