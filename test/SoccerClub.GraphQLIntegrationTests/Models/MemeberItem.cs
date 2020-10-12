namespace SoccerClub.GraphQLServer.IntegrationTests.Models
{
    public class MemberDTO
    {
        public Member member { get; set; }
    }

    public class Member
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
    }
}
