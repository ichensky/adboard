using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.Ads
{
    public class YoutubeUrl : SingleValueObject<string?>
    {
        private YoutubeUrl()
        {
            // For EF
        }

        public YoutubeUrl(string? name) : base(name) { }

        public static YoutubeUrl Null() => new YoutubeUrl();

        protected override void CheckChangeRule(string? youtubeUrl)
        {
            if (string.IsNullOrEmpty(youtubeUrl))
            {
                return;
            }
            if (youtubeUrl.Length > 1024 || !youtubeUrl.StartsWith("https://yout"))
            {
                throw new BusinessRuleValidationException("YoutubeUrl should be valid.");
            }
        }
    }
}
