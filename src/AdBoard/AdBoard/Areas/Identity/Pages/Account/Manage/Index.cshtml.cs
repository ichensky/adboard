using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AdBoard.Helpers.AspNetClaims;
using Application.UserProfiles.GetUserProfile;
using Application.UserProfiles.UpdateUserProfileContactInformation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdBoard.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMediator mediator;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.mediator = mediator;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Picture { get; private set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number", Prompt ="+380...")]
            [MaxLength(20)]
            public string PhoneNumber { get; set; }

            [MaxLength(30)]
            public string Telegram { get; set; }
            
            [MaxLength(30)]
            public string Instagram { get; set; }
        }

        private async Task LoadAsync()
        {
            var userProfile = await mediator.Send(new GetUserProfileQuery(User.GetUserId()));

            FirstName = userProfile.FirstName;
            LastName = userProfile.LastName;
            Picture = userProfile.Picture;

            Input = new InputModel
            {
                Telegram = userProfile.Telegram,
                Instagram=userProfile.Instagram,
                PhoneNumber=userProfile.PhoneNumber                
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync();
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await mediator.Send(new UpdateUserProfileContactInformationCommand(User.GetUserId(), Input.Telegram, Input.Instagram, Input.PhoneNumber));

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
