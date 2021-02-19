using Domain.Core;
using System;

namespace Domain.Ads
{
    public class PublishInformation : ValueObject
    {
        private int rejectionCount;
        private PublishStatus publishStatus;
        private DateTime? publishDate;

        private PublishInformation()
        {
            //For EF
        }

        public PublishInformation(PublishStatus publishStatus)
        {
            this.publishStatus = publishStatus;
        }

        public void UserPublishAd()
        {
            publishStatus = PublishStatus.OnModeration;
            publishDate = DateTime.UtcNow;
        }

        public void ModeratorApproveAd()
        {
            publishStatus = PublishStatus.Published;
        }

        public void ModeratorRejectAd(string rejectionMessage, bool forever = false)
        {
            rejectionCount++;
            publishStatus = forever ? PublishStatus.RejectedForEverByModerator : PublishStatus.RejectedByModerator;
        }

        public DateTime? PublishDate => publishDate;

        public PublishStatus PublishStatus => publishStatus;

        public int RejectionCount => rejectionCount;
    }
}
