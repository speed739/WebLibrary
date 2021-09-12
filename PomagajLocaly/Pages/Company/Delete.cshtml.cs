using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PomagajLocaly.Data;
using PomagajLocaly.Models;

namespace PomagajLocaly.Pages.Company
{
    [Authorize(Roles = "Company")]
    public class Delete : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty] public Guid? Id { get; set; }

        public Delete(ApplicationDbContext context)
        {
            _context = context;
        }

        public Offer Offer { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
                return NotFound();

            Offer = await _context.Offers.FirstOrDefaultAsync(m => m.OfferId == id && m.DeletedAt == null );

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

            return RedirectToPage("./Company");
        }
    }
}