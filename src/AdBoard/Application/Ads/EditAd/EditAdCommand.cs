using Application.Configuration.Commands;
using Application.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ads.EditAd
{
    public class EditAdCommand : CommandBase<EditAdDto>
    {
        public EditAdCommand(Guid adId, Guid userId, string name, string? description, string shortDescription, string? keywords, string? youtubeUrl)
        {
            AdId = adId;
            UserId = userId;
            Name = name;
            Description = description;
            ShortDescription = shortDescription;
            Keywords = keywords;
            YoutubeUrl = youtubeUrl;
        }

        public Guid AdId { get; }

        public Guid UserId { get; }

        public string Name { get; }

        public string ShortDescription { get; }

        public string? Description { get; }

        public string? Keywords { get; }

        public string? YoutubeUrl { get; }
    }
}
