using Domain.Core;
using Domain.Core.BusinessRules;
using System.Linq;

namespace Domain.Ads.Ad
{
    public class Keywords : SingleValueObject<string>
    {
        private Keywords()
        {
            // For EF
        }

        public Keywords(string keywords) : base(keywords) { }

        protected override void CheckChangeRule(string keywords)
        {
            if (keywords.Length > 120 || keywords.Count(x => x == ',') > 4)
            {
                throw new BusinessRuleValidationException("You can add maximum 5 keywords");
            }
        }
    }
}
