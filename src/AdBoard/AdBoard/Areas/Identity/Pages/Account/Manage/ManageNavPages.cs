using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdBoard.Areas.Identity.Pages.Account.Manage
{
    public static class ManageNavPages
    {
        public static string Index => nameof(Index);

        public static string MyAdsList => nameof(MyAdsList);

        public static string MyAdsCreate => nameof(MyAdsCreate);

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string MyAdsListNavClass(ViewContext viewContext) => PageNavClass(viewContext, MyAdsList);

        public static string CreateAdNavClass(ViewContext viewContext) => PageNavClass(viewContext, MyAdsCreate);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
