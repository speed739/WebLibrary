using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PomagajLocaly.Data;
using PomagajLocaly.Models;

namespace PomagajLocaly.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class CreateOffer : PageModel
    {

        private readonly ApplicationDbContext _context;
        
        [BindProperty] public OfferType OfferTypeModel { get; set; }
        
        public CreateOffer(ApplicationDbContext context)
        {
            _context = context;
        }
        
        
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var newOfferType = new OfferType()
            {
                Name = OfferTypeModel.Name,
                Description = OfferTypeModel.Description
            };

            _context.OfferTypes.Add(newOfferType);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                RedirectToPage("CreateOffer");
            }

            return RedirectToPage("Admin");
        }
    }
}