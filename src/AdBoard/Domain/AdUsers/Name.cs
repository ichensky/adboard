using Domain.Core;
using Domain.Core.BusinessRules;

namespace Domain.AdUsers
{
    public class Name : ValueObject
    {
        private readonly string firstName;
        private readonly string secondName;

        public Name(string firstName, string secondName)
        {
            CheckName(firstName, nameof(firstName));
            CheckName(secondName, nameof(secondName));

            this.firstName = firstName;
            this.secondName = secondName;
        }

        private void CheckName(string name, string propName)
        {
            if (name.Length < 2)
            {
                throw new BusinessRuleValidationException($"{propName} should have at least 2 charters");
            }
            if (name.Length > 30)
            {
                throw new BusinessRuleValidationException($"{secondName} should have maximum 30 charters");
            }
        }

        public string FirstName => firstName;

        public string SecondName => secondName;

        public override string ToString() => $"{firstName} {secondName}";
    }
}
