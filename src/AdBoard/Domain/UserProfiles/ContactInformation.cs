using Domain.Core;
using Domain.Core.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserProfiles
{
    public class ContactInformation : ValueObject
    {
        private string? phoneNumber;
        private string? telegram;
        private string? instagram;

        private ContactInformation() 
        {
            // For EF
        }

        public ContactInformation(string? phoneNumber, string? telegram, string? instagram)
        {
            CheckChangePhone(phoneNumber);
            CheckChangeTelegram(telegram);
            CheckChangeInstagram(instagram);
            this.phoneNumber = phoneNumber;
            this.telegram = telegram;
            this.instagram = instagram;
        }

        public static ContactInformation Null() => new();

        private void CheckChangeInstagram(string? instagram)
        {
            if (string.IsNullOrEmpty(telegram))
            {
                return;
            }

            if (telegram.Length > 30 || !telegram.StartsWith("@"))
            {
                throw new BusinessRuleValidationException("Instagram number should be valid.");
            }
        }

        private void CheckChangePhone(string? phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return;
            }
            if (phoneNumber.Length != "+380631122333".Length || !phoneNumber.StartsWith("+380"))
            {
                throw new BusinessRuleValidationException("Phone number should be valid.");
            }
        }

        private void CheckChangeTelegram(string? telegram)
        {
            if (string.IsNullOrEmpty(telegram))
            {
                return;
            }

            if (telegram.Length > 30 || !telegram.StartsWith("@"))
            {
                throw new BusinessRuleValidationException("Telegram number should be valid.");
            }
        }

        public string? PhoneNumber { get => phoneNumber; }

        public string? Telegram { get => telegram; }

        public string? Instagram { get => instagram; }
    }
}
