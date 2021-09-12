using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PomagajLocaly.Data;
using PomagajLocaly.Models;

namespace PomagajLocaly.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class UpdateOffer : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        [BindProperty] public Offer OfferModel { get; set; }
        
        public UpdateOffer(ApplicationDbContext context)
        {
            _context = context;
        }
        
        
        public void OnGet()
        {
            ViewData["TypeId"] = new SelectList(_context.Set<OfferType>(), "OfferTypeId", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var currentOfferType  = await _context.OfferTypes.FirstOrDefaultAsync(x =>
                x.OfferTypeId == OfferModel.OfferTypeId);

            currentOfferType.Name = OfferModel.Name;
            currentOfferType.Description = OfferModel.Description;
            
            _context.OfferTypes.Update(currentOfferType);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                RedirectToPage("Admin");
            }

            return RedirectToPage("Admin");
        }
    }
}