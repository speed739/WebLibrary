using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PomagajLocaly.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class Admin : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}