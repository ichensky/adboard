using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdBoard.ExceptionHandling;
using AdBoard.Helpers.AspNetClaims;
using Application.Ads.ListMyAds;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdBoard.Areas.Identity.Pages.Account.Manage.Ads
{
    public class ListModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMediator mediator;

        [TempData]
        public string StatusMessage { get; set; }

        public IEnumerable<MyAdDto> MyAds { get; private set; }

        public ListModel(UserManager<IdentityUser> userManager, IMediator mediator)
        {
            this.userManager = userManager;
            this.mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var userId = User.GetUserId();
            this.MyAds = await mediator.Send(new ListMyAdsQuery(userId));
        }
    }
}
