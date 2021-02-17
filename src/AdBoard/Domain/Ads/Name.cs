using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.Ads
{
    public class Name : SingleValueObject<string>
    {
        private Name()
        {
            // For EF
        }

        public Name(string name) : base(name) { }

        protected override void CheckChangeRule(string name)
        {
            if (name.Length < 3)
            {
                throw new BusinessRuleValidationException("Name should have at least 3 charters.");
            }
            if (name.Length > 100)
            {
                throw new BusinessRuleValidationException("Name should have maximum 100 charters.");
            }
        }
    }
}
