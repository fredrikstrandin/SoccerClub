using SoccerClub.GraphQL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Interface
{
    public interface IUserService
    {
        Task<List<UserItem>> GetAsync();
        Task<UserItem> GetAsync(string id);
    }
}