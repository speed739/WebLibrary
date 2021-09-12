using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PomagajLocaly.Data;
using PomagajLocaly.Models;

namespace PomagajLocaly.Pages.Client
{
    [Authorize(Roles = "Client")]
    public class AddBalance : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;


        [BindProperty] public User UserModel { get; set; }

        public AddBalance(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var currentUser = _userManager.Users.FirstOrDefault(p => p.Email == User.FindFirstValue(ClaimTypes.Email));
            currentUser.Balance = UserModel.Balance;
            _context.Update(currentUser);

            var result = await _context.SaveChangesAsync();


            if (result > 0)
            {
                return RedirectToPage("Index");
            }

            return RedirectToPage("Client");
        }
    }
}