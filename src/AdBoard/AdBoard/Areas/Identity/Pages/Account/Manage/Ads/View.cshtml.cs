using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdBoard.Helpers.AspNetClaims;
using Application.Ads.GetAd;
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

        public GetAdDto Ad { get; private set; }

        public bool CanEdit { get; private set; }

        public ViewModel(UserManager<IdentityUser> userManager, IMediator mediator)
        {
            this.userManager = userManager;
            this.mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var userId = User.GetUserId();
            this.Ad = await mediator.Send(new GetAdQuery(Id));
            this.CanEdit = this.Ad.UserId == userId;
        }
    }
}
