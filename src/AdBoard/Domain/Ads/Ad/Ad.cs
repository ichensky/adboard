using Domain.Ads.Ad.Pictures;
using Domain.Core;
using Domain.Core.BusinessRules;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Ads.Ad
{
    public class Ad : AggregateRoot
    {
        private readonly User user;
        private readonly Name name;
        private readonly Description? description;
        private readonly YoutubeUrl? youtubeUrl;
        private readonly Keywords? keywords;
        private IEnumerable<Picture> pictures;
        private PublishInformation publish;
        private readonly DateTime creationDate;
        private readonly DateTime? deleteDate;
        private readonly DateTime updateDate;

        private Ad()
        {
            // For EF
        }

        private Ad(User user, Name name, Description? description, Keywords? keywords)
        {
            this.user = user;
            this.name = name;
            this.description = description;
            this.keywords = keywords;
            this.pictures = new List<Picture>();
            publish = new PublishInformation(PublishStatus.NotPublished);
        }

        public void AddPicture(Picture picture) {
            var pictures = this.pictures as IList<Picture> ?? this.pictures.ToList();
            pictures.Add(picture);
            if (pictures.Count > 10)
            {
                throw new BusinessRuleValidationException("Ad can contains maximum 10 pictures");
            }
            this.pictures = pictures;
        }

        public void RemovePicture(Picture picture)
        {
            var pictures = this.pictures as IList<Picture> ?? this.pictures.ToList();
            pictures.Remove(picture);
            this.pictures = pictures;
        }

        public void PublishAd() {
            if (!pictures.Any())
            {
                throw new BusinessRuleValidationException("Ad should have at least on picture");
            }
            if (description is null)
            {
                throw new BusinessRuleValidationException("Description should not be empty");
            }
            this.publish.UserPublishAd();
        }

        public User User => user;
        
        public Name Name => name;

        public Description? Description => description;

        public YoutubeUrl? YoutubeUrl => youtubeUrl;

        public IEnumerable<Picture> Pictures => pictures;

        public PublishInformation Publish => publish;
        
        public Keywords? Keywords => keywords;

        public DateTime CreationDate => creationDate;

        public DateTime UpdateDate => updateDate;

        public DateTime? DeleteDate => deleteDate;
    }
}
