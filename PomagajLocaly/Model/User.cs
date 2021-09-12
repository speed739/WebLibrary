using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace PomagajLocaly.Models
{
    public partial class User: IdentityUser
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public double Balance { get; set; }
        
        
    }
}
