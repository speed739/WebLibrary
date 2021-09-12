using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PomagajLocaly.Data;
using PomagajLocaly.Models;

namespace PomagajLocaly.Pages.Client
{
    [Authorize(Roles = "Client")]
    public class GetVouchers : PageModel
    {
        [BindProperty]
        public Offer Offer { get; set; }
        public List<Offer> Offers { get;set; }
        private readonly ApplicationDbContext _context;

        public GetVouchers(ApplicationDbContext context)
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
    }
}