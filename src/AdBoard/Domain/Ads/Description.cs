using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.Ads
{
    public class Description : SingleValueObject<string?>
    {
        private Description()
        {
            // For EF
        }

        public Description(string? description) : base(description) { }

        public static Description Null() => new Description();

        protected override void CheckChangeRule(string? description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return;
            }
            if (description.Length > 800)
            {
                throw new BusinessRuleValidationException("Desctription should have maximum 800 charters.");
            }
        }
    }
}
