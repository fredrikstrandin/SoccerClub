using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Mvc.Testing;
using SoccerClub.GraphQLServer.IntegrationTests.Models;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SoccerClub.GraphQLServer.IntegrationTests
{
    public class MemberTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly GraphQLHttpClient _graphQLClient;
        private readonly HttpClient _httpClient;

        public MemberTest(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();

            GraphQLHttpClientOptions options = new GraphQLHttpClientOptions()
            { EndPoint = new Uri($"{_httpClient.BaseAddress}graphql") };

            _graphQLClient = new GraphQLHttpClient(options, new SystemTextJsonSerializer(), _httpClient);

        }

        [Fact]
        public async Task if_members_1_name_is_maria()
        {
            var memberRequest = new GraphQLRequest
            {
                Query =
                @"{ 
                    member(member_id: ""1"") {
                        first_name,
                     }
                 }"
            };

            GraphQLResponse<MemberDTO> member = await _graphQLClient.SendQueryAsync<MemberDTO>(memberRequest);
            
            Assert.Equal("Maria", member.Data.member.first_name);
        }

        [Fact]
        public async Task create_member()
        {
            MemberVariable mem = new MemberVariable()
            {
                first_name = "Lisa",
                last_name = "Ericsson",
                email = "lisa.ericsson@spam.se"
            };

            var memberRequest = new GraphQLRequest
            {
                Query = @"mutation($member: memberInput!) {
                    createMember(member: $member) 
                 }",
                Variables = new { member = mem }
            };

            var member = await _graphQLClient.SendMutationAsync<MemberCreateReturn>(memberRequest);

            Assert.NotNull(member);
        }
    }
}