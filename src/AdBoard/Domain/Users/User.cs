using Domain.Core;

namespace Domain.Users
{
    public class User : AggregateRoot
    {
        private readonly Name name;
        private readonly ContactInformation contactInformation;

        private User()
        {
            // For EF
        }

        public User(Name name, ContactInformation contactInformation)
        {
            this.name = name;
            this.contactInformation = contactInformation;
        }

        public Name Name => name;

        public ContactInformation ContactInformation => contactInformation;
    }
}
