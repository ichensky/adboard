using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AdBoard.ExceptionHandling;
using AdBoard.Helpers.AspNetClaims;
using Application.Ads.CreateAd;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdBoard.Areas.Identity.Pages.Account.Manage
{
    public class CreateAdModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IRazorPagesRequestExceptionHandler razorPagesRequestExceptionHandler;

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

        public CreateAdModel(UserManager<IdentityUser> userManager, IRazorPagesRequestExceptionHandler razorPagesRequestExceptionHandler)
        {
            this.userManager = userManager;
            this.razorPagesRequestExceptionHandler = razorPagesRequestExceptionHandler;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var model = new CreateAdCommand(User.GetUserId(), Input.Name, Input.Description, Input.ShortDescription, Input.Keywords, Input.YoutubeUrl);

            await razorPagesRequestExceptionHandler.Execute(ModelState, model);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage($"EditAd/{model.Id}");
        }
    }
}
