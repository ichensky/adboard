namespace Domain.Ads.Ad
{
    public enum PublishStatus
    {
        NotPublished = 0,
        OnModeration = 1,
        Published = 2,
        RejectedByModerator = 3,
        RejectedForEverByModerator = 4,
    }
}
