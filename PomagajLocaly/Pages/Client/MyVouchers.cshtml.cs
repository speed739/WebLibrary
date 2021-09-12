using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PomagajLocaly.Data;
using PomagajLocaly.Models;

namespace PomagajLocaly.Pages.Client
{
    [Authorize(Roles = "Client")]
    public class MyVouchers : PageModel
    {
        [BindProperty] public Voucher Voucher { get; set; }
        public List<Voucher> Vouchers { get; set; }
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public MyVouchers(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private List<Voucher> FillVouchers()
        {
            List<Voucher> vouchery = new List<Voucher>();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            vouchery = _context.Vouchers.Where(x => x.UserId == Guid.Parse(userId)).ToList();
            return vouchery;
        }

        public void OnGet()
        {
            Vouchers = FillVouchers();
        }
    }
}