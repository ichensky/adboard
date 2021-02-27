using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdBoard.ExceptionHandling;
using AdBoard.Helpers.AspNetClaims;
using Application.Ads.Pictures.GetAdPictures;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdBoard.Areas.Identity.Pages.Account.Manage.Ads
{
    public class ManagePicturesModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMediator mediator;
        private readonly IRazorPagesRequestExceptionHandler razorPagesRequestExceptionHandler;

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public ManagePicturesModel(UserManager<IdentityUser> userManager, IMediator mediator, IRazorPagesRequestExceptionHandler razorPagesRequestExceptionHandler)
        {
            this.userManager = userManager;
            this.mediator = mediator;
            this.razorPagesRequestExceptionHandler = razorPagesRequestExceptionHandler;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.GetUserId();
            var pictures = await mediator.Send(new GetAdPicturesQuery(Id, userId));

            if (ad == null)
            {
                return RedirectToPage("/Errors/NotFound");
            }
            LoadAd(ad);

            return Page();
        }

        private void LoadAd(EditAdDto ad)
        {
            this.Input = new InputModel
            {
                Name = ad.Name,
                Description = ad.Description,
                ShortDescription = ad.ShortDescription,
                Keywords = ad.Keywords,
                YoutubeUrl = ad.YoutubeUrl
            };
        }
    }
}
