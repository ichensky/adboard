﻿using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.Ads.Ad
{
    public class Description : ValueObject
    {
        private string description;

        public Description(string description)
        {
            CheckChangeRule(description);
            this.description = description;
        }

        public void ChangeDescription(string newDescription)
        {
            CheckChangeRule(description);
            description = newDescription;
        }
        private void CheckChangeRule(string description)
        {
            if (description.Length < 3)
            {
                throw new BusinessRuleValidationException("Desctription should have at least 3 charters.");
            }
            if (description.Length > 800)
            {
                throw new BusinessRuleValidationException("Desctription should have maximum 800 charters.");
            }
        }
    }
}
