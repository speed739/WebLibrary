using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PomagajLocaly.Data;
using PomagajLocaly.Models;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace PomagajLocaly.Pages.Company
{
    [Authorize(Roles = "Company")]
    public class Account : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        
        [BindProperty]
        public PomagajLocaly.Models.Company CompanyModel { get; set; }

        public Account(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }

        private void FillModel()
        {
            var currentUserCompanyId = _userManager.Users.FirstOrDefault(p => p.Email == User.FindFirstValue(ClaimTypes.Email)).CompanyId;
            var companyDetails = _context.Companies.FirstOrDefault(x => x.Id == currentUserCompanyId);
            CompanyModel = companyDetails;
        }

        public void OnGet()
        {
            FillModel();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var currentUser = _userManager.Users.FirstOrDefault(p => p.Email == User.FindFirstValue(ClaimTypes.Email));
            var currentCompany = _context.Companies.FirstOrDefault(x => x.Id == currentUser.CompanyId);

            currentCompany.Name = CompanyModel.Name;
            currentCompany.Nip = CompanyModel.Nip;
            currentCompany.BankAccount = CompanyModel.BankAccount;

            _context.Companies.Update(currentCompany);
            var result = await _context.SaveChangesAsync();
          
            if (result > 0)
            {
                return RedirectToPage("Index");
            }

            return RedirectToPage("Company");
        }
    }
}