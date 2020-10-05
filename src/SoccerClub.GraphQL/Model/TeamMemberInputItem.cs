namespace SoccerClub.GraphQLServer.Model
{
    public class TeamMemberInputItem
    {
        public string MemberId { get; set; }
        public RoleEnum Role { get; set; }
    }
}
