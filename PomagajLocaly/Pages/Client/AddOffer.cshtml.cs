using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PomagajLocaly.Data;
using PomagajLocaly.Models;

namespace PomagajLocaly.Pages.Client
{
    [Authorize(Roles = "Client")]
    public class AddOffer : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        [BindProperty] public Guid? Id { get; set; }

        public AddOffer(ApplicationDbContext context,UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Offer Offer { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            Offer = await _context.Offers.FirstOrDefaultAsync(m => m.OfferId == id && m.DeletedAt == null );
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Offer == null)
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            Offer = await _context.Offers.FirstOrDefaultAsync(m => m.OfferId == id && m.DeletedAt == null);

            if (Offer == null) return RedirectToPage("./Index");

            Offer.DeletedAt = DateTime.Now;
            
            _context.Offers.Update(Offer);
            await _context.SaveChangesAsync();
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            
            var voucher = new Voucher()
            {
                OfferId = Offer.OfferId,
                UserId = Guid.Parse(userId),
                
                StartAmount = Offer.Price,
                CurrentAmount = 0
                
            };
            _context.Vouchers.Add(voucher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Company");
        }
    }
    
}