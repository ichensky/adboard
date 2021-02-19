using Application.Configuration.Commands;
using Application.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ads.CreateAd
{
    public class CreateAdCommand : CommandBase<AdDto>
    {
        public CreateAdCommand(Guid userProfileId, string name, string? description, string shortDescription, string? keywords, string? youtubeUrl)
        {
            UsersProfileId = userProfileId;
            Name = name;
            Description = description;
            ShortDescription = shortDescription;
            Keywords = keywords;
            YoutubeUrl = youtubeUrl;
        }

        public Guid UsersProfileId { get; }

        public string Name { get; }

        public string ShortDescription { get; }

        public string? Description { get; }

        public string? Keywords { get; }

        public string? YoutubeUrl { get; }
    }
}
