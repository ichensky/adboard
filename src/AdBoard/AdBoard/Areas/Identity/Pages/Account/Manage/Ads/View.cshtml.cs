using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdBoard.Helpers.AspNetClaims;
using Application.Ads.GetMyAdsViewAd;
using Application.Ads.ListMyAds;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdBoard.Areas.Identity.Pages.Account.Manage.Ads
{
    public class ViewModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMediator mediator;

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public GetMyAdsViewAdDto Ad { get; private set; }

        public ViewModel(UserManager<IdentityUser> userManager, IMediator mediator)
        {
            this.userManager = userManager;
            this.mediator = mediator;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.GetUserId();
            this.Ad = await mediator.Send(new GetMyAdsViewAdQuery(Id, userId));

            if (this.Ad ==null)
            {
                return RedirectToPage("/Errors/NotFound");
            }

            return Page();
        }
    }
}
