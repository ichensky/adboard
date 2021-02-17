using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.Ads.Pictures
{
    public class Description : SingleValueObject<string>
    {
        private Description()
        {
            // For EF
        }

        public Description(string description) : base(description) { }

        protected override void CheckChangeRule(string description)
        {
            if (description.Length < 3)
            {
                throw new BusinessRuleValidationException("Desctription should have at least 3 charters.");
            }
            if (description.Length > 128)
            {
                throw new BusinessRuleValidationException("Desctription should have maximum 100 charters.");
            }
        }
    }
}
