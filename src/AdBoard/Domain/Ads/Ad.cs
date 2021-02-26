using Domain.Core;
using Domain.Core.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using Picture = Domain.Ads.Pictures.Picture;

namespace Domain.Ads
{
    public class Ad : AggregateRoot
    {
        private readonly TypedIdValueObject userProfilesId;
        private Name name;
        private Description description;
        private YoutubeUrl youtubeUrl;
        private Keywords keywords;
        private IEnumerable<Picture> pictures;
        private PublishInformation publish;
        private ShortDescription shortDescription;
        private DateTime creationDate;
        private DateTime? deleteDate;
        private DateTime updateDate;
        private readonly TypedIdValueObject id;

        private Ad()
        {
            // For EF
        }

        private Ad(TypedIdValueObject userProfilesId, Name name, ShortDescription shortDescription, Description description, Keywords keywords, YoutubeUrl youtubeUrl)
        {
            this.userProfilesId = userProfilesId;
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

        public static Ad CreateAd(TypedIdValueObject userProfilesId, Name name, ShortDescription shortDescription, Description description, Keywords keywords, YoutubeUrl youtubeUrl)
        {
            return new Ad(userProfilesId, name, shortDescription, description, keywords, youtubeUrl);
        }

        public void UpdateAdByUser(TypedIdValueObject userProfilesId, Name name, ShortDescription shortDescription, Description description, Keywords keywords, YoutubeUrl youtubeUrl)
        {
            if ((this.userProfilesId != userProfilesId)|| (this.deleteDate == null))
            {
                throw new BusinessRuleValidationException("User can not edit this ad.");
            }
            this.updateDate = DateTime.UtcNow;
            this.name = name;
            this.shortDescription = shortDescription;
            this.description = description;
            this.keywords = keywords;
            this.youtubeUrl = youtubeUrl;
        }

        public void AddPicture(Picture picture)
        {
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

        public void PublishAd()
        {
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

        public TypedIdValueObject UserProfilesId => userProfilesId;

        public Name Name => name;

        public Description Description => description;

        public ShortDescription ShortDescription => shortDescription;

        public YoutubeUrl YoutubeUrl => youtubeUrl;

        public IEnumerable<Picture> Pictures => pictures;

        public PublishInformation Publish => publish;

        public Keywords Keywords => keywords;

        public DateTime CreationDate => creationDate;

        public DateTime UpdateDate => updateDate;

        public DateTime? DeleteDate => deleteDate;
    }
}
