using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PomagajLocaly.Data;
using PomagajLocaly.Models;

namespace PomagajLocaly.Pages.Company
{
    [Authorize(Roles = "Company")]
    public class DeleteOffer : PageModel
    {
        [BindProperty]
        public Offer Offer { get; set; }
        public List<Offer> Offers { get;set; }
        private readonly ApplicationDbContext _context;

        public DeleteOffer(ApplicationDbContext context)
        {
            _context = context;
            Offers = FillOffers();
        }

        private  List<Offer> FillOffers()
        {
            List<Offer> oferty = new List<Offer>();

            oferty = _context.Offers.Where(x=>x.DeletedAt == null).ToList();
            return oferty;
        }

        public void OnGet()
        { 
            
        }

        public async Task<IActionResult> OnPostAsync(Guid? OfferId)
        {
            if (OfferId == null)
                return NotFound();

            Offer = await _context.Offers.FirstOrDefaultAsync(x => x.OfferId == OfferId && x.DeletedAt == null);

            if (Offer == null) return RedirectToPage("./Index");

            Offer.DeletedAt = DateTime.Now;
            
            _context.Offers.Update(Offer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}