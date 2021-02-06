using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.Ads.Ad
{
    public class ShortDescription : SingleValueObject<string>
    {
        private ShortDescription()
        {
            // For EF
        }

        public ShortDescription(string description) : base(description) { }

        protected override void CheckChangeRule(string description)
        {
            if (description.Length < 3)
            {
                throw new BusinessRuleValidationException("ShortDescription should have at least 3 charters.");
            }
            if (description.Length > 160)
            {
                throw new BusinessRuleValidationException("ShortDescription should have maximum 800 charters.");
            }
        }
    }
}
