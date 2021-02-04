using System;

namespace Application.UserProfiles
{
    public class UserProfileDto
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Picture { get; set; }

        public string? Telegram { get; set; }

        public string? Instagram { get; set; }

        public string? PhoneNumber { get; set; }
    }
}