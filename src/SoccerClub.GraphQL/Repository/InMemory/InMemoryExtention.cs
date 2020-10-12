using Microsoft.Extensions.DependencyInjection;
using SoccerClub.GraphQLServer.Interface;

namespace SoccerClub.GraphQLServer.Repository.InMemory
{
    public static class InMemoryExtention
    {
        public static IServiceCollection AddInMemoryRepository(this IServiceCollection services)
        {
            return services.AddSingleton<InMemoryData>()
                .AddSingleton<IMemberRepository, MemberInMemoryRepository>()
                .AddSingleton<ITeamRepository, TeamInMemoryRepository>();
        }
    }
}
