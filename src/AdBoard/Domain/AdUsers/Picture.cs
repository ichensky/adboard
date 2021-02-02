using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.AdUsers
{
    public class Picture : SingleValueObject<string>
    {
        private Picture()
        {
            // For EF
        }

        public Picture(string picture) : base(picture) { }

        protected override void CheckChangeRule(string picture)
        {
            if (picture.Length > 1024)
            {
                throw new BusinessRuleValidationException("Picture should have maximum 100 charters.");
            }
        }
    }
}
