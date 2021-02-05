using Domain.Core;
using Domain.Core.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (string.IsNullOrEmpty(instagram))
            {
                return;
            }

            if (instagram.Length > 30 || !Regex.IsMatch(instagram, "@[a-zA-Z0-9_.-]+"))
            {
                throw new BusinessRuleValidationException("Instagram should be valid.");
            }
        }

        private void CheckChangePhone(string? phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return;
            }
            if (phoneNumber.Length != "+380631122333".Length 
                || !Regex.IsMatch(phoneNumber, "\\+380[0-9]")
                )
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

            if (telegram.Length > 30 || !Regex.IsMatch(telegram, "@[a-zA-Z0-9_.-]+"))
            {
                throw new BusinessRuleValidationException("Telegram should be valid.");
            }
        }

        public string? PhoneNumber { get => phoneNumber; }

        public string? Telegram { get => telegram; }

        public string? Instagram { get => instagram; }
    }
}
