using System.Text.Json.Serialization;

namespace CampusCourses.WebApi.Identity.Models
{
    public class AuthenticationViewModel
    {

        public string Id { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Avatar { get; set; }

        [JsonPropertyName("auth")]
        public Token Authentication { get; set; }
    }
}
