using Domain.Core;
using System;

namespace Domain.Ads
{
    public class PublishInformation : ValueObject
    {
        private int rejectionCount;
        private PublishStatus status;
        private DateTime? publishDate;

        private PublishInformation()
        {
            //For EF
        }

        public PublishInformation(PublishStatus publishStatus)
        {
            this.status = publishStatus;
        }

        public void UserPublishAd()
        {
            status = PublishStatus.OnModeration;
            publishDate = DateTime.UtcNow;
        }

        public void ModeratorApproveAd()
        {
            status = PublishStatus.Published;
        }

        public void ModeratorRejectAd(string rejectionMessage, bool forever = false)
        {
            rejectionCount++;
            status = forever ? PublishStatus.RejectedForEverByModerator : PublishStatus.RejectedByModerator;
        }

        public DateTime? PublishDate => publishDate;
        public PublishStatus Status => status;
        public int RejectionCount => rejectionCount;
    }
}
