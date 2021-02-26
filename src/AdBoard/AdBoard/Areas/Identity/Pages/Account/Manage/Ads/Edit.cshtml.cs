using AdBoard.ExceptionHandling;
using AdBoard.Helpers.AspNetClaims;
using Application.Ads.EditAd;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdBoard.Areas.Identity.Pages.Account.Manage.Ads
{
    public class EditModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMediator mediator;
        private readonly IRazorPagesRequestExceptionHandler razorPagesRequestExceptionHandler;

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Prompt = "auto BMW X5")]
            [Required]
            [MaxLength(100)]
            [MinLength(3)]
            public string Name { get; set; }

            [MaxLength(160)]
            [Required]
            [MinLength(3)]
            public string ShortDescription { get; set; }

            [MaxLength(1024)]
            public string Description { get; set; }

            [MaxLength(500)]
            [Display(Prompt = "car, bmw, x5")]
            public string Keywords { get; set; }

            [MaxLength(500)]
            [Display(Prompt = "https://you....")]
            public string YoutubeUrl { get; set; }
        }

        public EditModel(UserManager<IdentityUser> userManager, IMediator mediator, IRazorPagesRequestExceptionHandler razorPagesRequestExceptionHandler)
        {
            this.userManager = userManager;
            this.mediator = mediator;
            this.razorPagesRequestExceptionHandler = razorPagesRequestExceptionHandler;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.GetUserId();
            EditAdDto ad = await mediator.Send(new GetEditAdQuery(Id, userId));

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = User.GetUserId();

            var model = new EditAdCommand(Id, userId, Input.Name, Input.Description, Input.ShortDescription, Input.Keywords, Input.YoutubeUrl);

            await razorPagesRequestExceptionHandler.Execute(ModelState, model);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage($"EditAd/{model.Id}");
        }
    }
}
