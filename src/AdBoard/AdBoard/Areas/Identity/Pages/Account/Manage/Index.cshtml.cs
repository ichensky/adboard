using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ac.GDrive.Configuration;
using AdBoard.ExceptionHandling;
using AdBoard.Helpers.AspNetClaims;
using Application.UserProfiles;
using Application.UserProfiles.TryGetUserProfile;
using Application.UserProfiles.UpdateUserProfileContactInformation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace AdBoard.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMediator mediator;
        private readonly IRazorPagesRequestExceptionHandler razorPagesRequestExceptionHandler;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IMediator mediator, IRazorPagesRequestExceptionHandler razorPagesRequestExceptionHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.mediator = mediator;
            this.razorPagesRequestExceptionHandler = razorPagesRequestExceptionHandler;
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
            [Display(Name = "Phone number", Prompt = "+380...")]
            [MaxLength(20)]
            public string PhoneNumber { get; set; }

            [MaxLength(30)]
            [Display(Prompt ="@xxx...")]
            public string Telegram { get; set; }
            
            [MaxLength(30)]
            [Display(Prompt ="@yyy...")]
            public string Instagram { get; set; }
        }

        private void Load(UserProfileDto userProfile)
        {
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
            var userId = User.GetUserId();
            var userProfile = await mediator.Send(new TryGetUserProfileQuery(userId));
            if (userProfile == null)
            {
                return NotFound($"Unable to load user profile with ID '{userId}'.");
            }

            Load(userProfile);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var userId = User.GetUserId();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            var userProfile = await mediator.Send(new TryGetUserProfileQuery(userId));
            if (userProfile == null)
            {
                return NotFound($"Unable to load user profile with ID '{userId}'.");
            }

            if (!ModelState.IsValid)
            {
                Load(userProfile);
                return Page();
            }

            var model = new UpdateUserProfileContactInformationCommand(User.GetUserId(), 
                Input.Telegram?.Trim(), Input.Instagram?.Trim(), Input.PhoneNumber?.Trim());

            await razorPagesRequestExceptionHandler.Execute(ModelState, model);

            if (!ModelState.IsValid)
            {
                Load(userProfile);
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
