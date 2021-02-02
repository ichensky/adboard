using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdBoard.Areas.Ad.Pages.Manage.Add
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Range(3,100)]
            public string Name { get; set; }

            [Range(3,800)]
            public string Description { get; set; }

            [MaxLength(1024)]
            [Display(Name="Youtube url", Prompt = "https://youtu.be/ABC...")]
            public string YoutubeUrl { get; set; }

            [MaxLength(120)]
            [DataType(DataType.MultilineText)]
            [Display(Name="Keywords (max 5)", Prompt = "car, bmw, x5")]
            public string Keywords { get; set; }
        }

        public void OnGet()
        {
        }
    }
}
