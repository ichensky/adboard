using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.Ads.Ad
{
    public class YoutubeUrl : ValueObject
    {
        private string youtubeUrl;

        public YoutubeUrl(string youtubeUrl)
        {
            CheckChangeRule(youtubeUrl);
            this.youtubeUrl = youtubeUrl;
        }

        public void ChangeyoutubeUrl(string newYoutubeUrl)
        {
            CheckChangeRule(youtubeUrl);
            youtubeUrl = newYoutubeUrl;
        }
        private void CheckChangeRule(string youtubeUrl)
        {
            if (youtubeUrl.Length > 1024 || !youtubeUrl.StartsWith("https://yout"))
            {
                throw new BusinessRuleValidationException("YoutubeUrl should be valid.");
            }
        }
    }
}
