using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PomagajLocaly.Data;
using PomagajLocaly.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PomagajLocaly.Pages.Company
{
    [Authorize(Roles = "Company")]
    public class CreateOffer : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        [BindProperty] public Offer OfferModel { get; set; }

        public CreateOffer(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void OnGet()
        {
            ViewData["TypeId"] = new SelectList(_context.Set<OfferType>(), "OfferTypeId", "Name");
        }


        public async Task<IActionResult> OnPostAsync()
        {
            var currentUser =
                await _userManager.Users.FirstOrDefaultAsync(p => p.Email == User.FindFirstValue(ClaimTypes.Email));
            var type = await _context.OfferTypes.FirstOrDefaultAsync(x =>
                x.OfferTypeId == OfferModel.OfferTypeId);

            var newOffer = new Offer()
            {
                Name = OfferModel.Name,
                Description = OfferModel.Description,
                OfferTypeId = type.OfferTypeId,
                Price = OfferModel.Price
            };

            _context.Offers.Add(newOffer);
            await _context.SaveChangesAsync();

            return RedirectToPage("Client");
        }
    }
}