using Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.UpdateUserProfileContactInformation
{
    public class UpdateUserProfileContactInformationCommand : CommandBase<UserProfileDto>
    {
        public UpdateUserProfileContactInformationCommand(Guid userProfileId, string telegram, string instagram, string phoneNumber)
        {
            Telegram = telegram;
            Instagram = instagram;
            PhoneNumber = phoneNumber;
            UserProfileId = userProfileId;
        }

        public Guid UserProfileId { get; set; }

        public string Telegram { get; set; }

        public string Instagram { get; set; }

        public string PhoneNumber { get; set; }
    }
}
