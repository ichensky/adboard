using Application.UserProfiles.CreateUserProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdBoard.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IMediator mediator;
        private readonly ILogger<ExternalLoginModel> _logger;

        public ExternalLoginModel(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            ILogger<ExternalLoginModel> logger,
            IEmailSender emailSender,
            IMediator mediator)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            this.mediator = mediator;
        }

        public string ProviderDisplayName { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public IActionResult OnGetAsync()
        {
            return RedirectToPage("./Login");
        }

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (result.Succeeded)
            {
                _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
                return LocalRedirect(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                if (!info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    ErrorMessage = "Email is required.";
                    return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
                }
                if (!info.Principal.HasClaim(c => c.Type == ClaimTypes.GivenName))
                {
                    ErrorMessage = "GivenName is required.";
                    return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
                }
                if (!info.Principal.HasClaim(c => c.Type == ClaimTypes.Surname))
                {
                    ErrorMessage = "Surname is required.";
                    return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
                }
                if (!info.AuthenticationProperties.Items.ContainsKey("picture"))
                {
                    ErrorMessage = "Picture is required.";
                    return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
                }

                // If the user does not have an account, then ask the user to create an account.
                await RegisterUser(info);
                ProviderDisplayName = info.ProviderDisplayName;

                _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
                return LocalRedirect(returnUrl);
            }
        }

        public async Task RegisterUser(ExternalLoginInfo info)
        {
            var picture = info.AuthenticationProperties.Items["picture"];
            var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName);
            if (firstName.Length > 30)
            {
                firstName = firstName.Remove(30);
            }
            var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname);
            if (lastName.Length > 30)
            {
                lastName = firstName.Remove(30);
            }
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            var user = new IdentityUser { UserName = email, Email = email };

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    await mediator.Send(new CreateUserProfileCommand(Guid.Parse(user.Id), picture, firstName, lastName));

                    _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                    await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);
                }
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
