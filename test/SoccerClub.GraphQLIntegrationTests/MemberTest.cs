using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using SoccerClub.GraphQL;
using System;
using System.Net.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Xunit;
using System.Threading.Tasks;
using System.Text;
using GraphQL.Client.Abstractions;
using GraphQL;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SoccerClub.GraphQL.IntegrationTests.Models;
using System.Diagnostics;
using GraphQL.NewtonsoftJson;

namespace SoccerClub.GraphQLs.IntegrationTests
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

            var member = await _graphQLClient.SendQueryAsync<MemeberItem>(memberRequest);

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

            Assert.NotNull(member.Data.createMember);
        }
    }
}