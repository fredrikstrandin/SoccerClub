using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoccerClub.GraphQLServer.GraphQLOperation;
using SoccerClub.GraphQLServer.Interface;
using SoccerClub.GraphQLServer.Repository.InMemory;
using SoccerClub.GraphQLServer.Services;

namespace SoccerClub.GraphQLServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddControllers();

            services.AddSingleton<IMemberService, MemberService>();
            services.AddSingleton<ITeamService, TeamService>();

            services.AddInMemoryRepository();

            services.AddSingleton<SoccerClubSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
                options.ExposeExceptions = false;
            })
                .AddDataLoader()
                .AddSystemTextJson()
                .AddGraphTypes(ServiceLifetime.Singleton);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseGraphQL<SoccerClubSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/healthcheck");
            });
        }
    }
}
