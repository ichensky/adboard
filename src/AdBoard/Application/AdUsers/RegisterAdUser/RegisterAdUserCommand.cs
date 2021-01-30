using Application.Configuration.Commands;
using Application.Users.AddUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AdUsers.RegisterAdUser
{
    public class RegisterAdUserCommand : CommandBase<AdUserDto>
    {
        public RegisterAdUserCommand(string firstName, string secondName, string phoneNumber, string telegram)
        {
            FirstName = firstName;
            SecondName = secondName;
            PhoneNumber = phoneNumber;
            Telegram = telegram;
        }

        public string FirstName { get; }

        public string SecondName { get; }

        public string PhoneNumber { get; }

        public string Telegram { get; }
    }
}
