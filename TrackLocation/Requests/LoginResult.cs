using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TrackLocation.Requests
{
    public class LoginResult
    {
        [JsonPropertyName("UserId")]
        public long UserId { get; set; }
        [JsonPropertyName("Firstname")]
        public string Username { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("TypeUser")]
        public string TypeUser { get; set; }

        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }

    }
}
