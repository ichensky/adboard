using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.UserProfiles
{
    public class Name : ValueObject
    {
        private readonly string firstName;
        private readonly string lastName;

        public Name(string firstName, string lastName)
        {
            CheckName(firstName, nameof(firstName));
            CheckName(lastName, nameof(lastName));

            this.firstName = firstName;
            this.lastName = lastName;
        }

        private void CheckName(string name, string propName)
        {
            if (name.Length < 2)
            {
                throw new BusinessRuleValidationException($"{propName} should have at least 2 charters");
            }
            if (name.Length > 30)
            {
                throw new BusinessRuleValidationException($"{lastName} should have maximum 30 charters");
            }
        }

        public string FirstName => firstName;

        public string LastName => lastName;

        public override string ToString() => $"{firstName} {lastName}";
    }
}
