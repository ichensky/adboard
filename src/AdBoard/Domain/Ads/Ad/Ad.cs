using Domain.Ads.Ad.Pictures;
using Domain.Core;
using Domain.Core.BusinessRules;
using Domain.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using Picture = Domain.Ads.Ad.Pictures.Picture;

namespace Domain.Ads.Ad
{
    public class Ad : AggregateRoot
    {
        private readonly UserProfile user;
        private readonly Name name;
        private readonly Description description;
        private readonly YoutubeUrl youtubeUrl;
        private readonly Keywords keywords;
        private IEnumerable<Picture> pictures;
        private PublishInformation publish;
        private Description shortDescription;
        private readonly DateTime creationDate;
        private readonly DateTime? deleteDate;
        private readonly DateTime updateDate;
        private readonly TypedIdValueObject id;

        private Ad()
        {
            // For EF
        }

        private Ad(UserProfile user, Name name, Description shortDescription, Description description, Keywords keywords, YoutubeUrl youtubeUrl)
        {
            this.user = user;
            this.name = name;
            this.description = description;
            this.keywords = keywords;
            this.pictures = new List<Picture>();
            publish = new PublishInformation(PublishStatus.NotPublished);
            this.id = new TypedIdValueObject(Guid.NewGuid());
            this.youtubeUrl = YoutubeUrl.Null();
            this.shortDescription = shortDescription;
            this.youtubeUrl = youtubeUrl;
        }

        public static Ad CreateAd(UserProfile user, Name name, Description shortDescription, Description description, Keywords keywords, YoutubeUrl youtubeUrl) {

            return new Ad(user,name,shortDescription,description,keywords,youtubeUrl);
        }

        public void AddPicture(Picture picture) {
            var pictures = this.pictures as IList<Picture> ?? this.pictures.ToList();
            pictures.Add(picture);
            if (pictures.Count > 5)
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

        public TypedIdValueObject Id => id;

        public UserProfile User => user;
        
        public Name Name => name;

        public Description Description => description;

        public Description ShortDescription => shortDescription;

        public YoutubeUrl YoutubeUrl => youtubeUrl;

        public IEnumerable<Picture> Pictures => pictures;

        public PublishInformation Publish => publish;
        
        public Keywords Keywords => keywords;

        public DateTime CreationDate => creationDate;

        public DateTime UpdateDate => updateDate;

        public DateTime? DeleteDate => deleteDate;
    }
}
