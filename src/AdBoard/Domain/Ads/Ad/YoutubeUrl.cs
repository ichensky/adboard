using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.Ads.Ad
{
    public class YoutubeUrl : SingleValueObject<string>
    {
        private YoutubeUrl()
        {
            // For EF
        }

        public YoutubeUrl(string name) : base(name) { }

        protected override void CheckChangeRule(string youtubeUrl)
        {
            if (youtubeUrl.Length > 1024 || !youtubeUrl.StartsWith("https://yout"))
            {
                throw new BusinessRuleValidationException("YoutubeUrl should be valid.");
            }
        }
    }
}
