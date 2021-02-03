using Domain.Core.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserProfiles
{
    public class ContactInformation
    {
        private string? phoneNumber;
        private string? telegram;

        public ContactInformation(string? phoneNumber, string? telegram)
        {
            CheckChangePhone(phoneNumber);
            CheckChangeTelegram(telegram);
            this.phoneNumber = phoneNumber;
            this.telegram = telegram;
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

            if (telegram.Length > 50 || !telegram.StartsWith("@"))
            {
                throw new BusinessRuleValidationException("Phone number should be valid.");
            }
        }

        public string? PhoneNumber { get => phoneNumber; }

        public string? Telegram { get => telegram; }
    }
}
