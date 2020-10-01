using Microsoft.Extensions.DependencyInjection;
using SoccerClub.GraphQL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerClub.GraphQL.Repository.InMemory
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
