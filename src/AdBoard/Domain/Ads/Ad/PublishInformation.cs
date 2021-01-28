using Domain.Core;
using System;

namespace Domain.Ads.Ad
{
    public class PublishInformation : ValueObject
    {
        private int rejectionCount;
        private PublishStatus status;
        private DateTime? publishDate;
        public string rejectionMessage = string.Empty;

        public PublishInformation() { }

        public void UserPublishAd()
        {
            status = PublishStatus.OnModeration;
        }

        public void ModeratorApproveAd()
        {
            status = PublishStatus.Published;
        }

        public void ModeratorRejectAd(string rejectionMessage, bool forever = false)
        {
            rejectionCount++;
            status = forever ? PublishStatus.RejectedForEverByModerator : PublishStatus.RejectedByModerator;
            this.rejectionMessage = rejectionMessage;
        }

        public DateTime? PublishDate => publishDate;
        public PublishStatus Status => status;
        public int RejectionCount => rejectionCount;
    }
}
