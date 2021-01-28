using Domain.Core;
using Domain.Core.BusinessRules;
using System.Linq;

namespace Domain.Ads.Ad
{
    public class Keywords : ValueObject
    {
        private string keywords;

        public Keywords(string keywords)
        {
            CheckChangeRule(keywords);
            this.keywords = keywords;
        }

        public void ChangeDescription(string newKeywords)
        {
            CheckChangeRule(keywords);
            keywords = newKeywords;
        }
        private void CheckChangeRule(string keywords)
        {
            if (keywords.Length > 120 || keywords.Count(x => x == ',') > 4)
            {
                throw new BusinessRuleValidationException("You can add maximum 5 keywords");
            }
        }
    }
}
