using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SoccerClub.GraphQL.GraphQLOperation;
using SoccerClub.GraphQL.Interface;
using SoccerClub.GraphQL.Repository;
using SoccerClub.GraphQL.Repository.InMemory;
using SoccerClub.GraphQL.Services;

namespace SoccerClub.GraphQL
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

            services.AddSingleton<InMemoryData>();
            services.AddSingleton<IMemberRepository, MemberInMemoryRepository>();
            services.AddSingleton<ITeamRepository, TeamInMemoryRepository>();

            services.AddScoped<SoccerClubSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
                options.ExposeExceptions = true;
            })
                .AddSystemTextJson()
                .AddGraphTypes(ServiceLifetime.Scoped);
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

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapHealthChecks("/healthcheck");
            //    endpoints.MapControllers();
            //});
        }
    }
}
