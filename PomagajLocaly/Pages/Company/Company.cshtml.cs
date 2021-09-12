using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PomagajLocaly.Pages.Company
{
    [Authorize(Roles = "Company")]
    public class Company : PageModel
    {
        public void OnGet()
        {
            
        }
    }
}