using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.Ads.Ad
{
    public class Name : ValueObject
    {
        private string name;

        public Name(string name)
        {
            CheckChangeRule(name);
            this.name = name;
        }

        public void ChangeDescription(string newName)
        {
            CheckChangeRule(name);
            name = newName;
        }
        private void CheckChangeRule(string name)
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
