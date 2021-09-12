using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable


namespace PomagajLocaly.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        public int Nip { get; set; }
        public string Name { get; set; }
        public string BankAccount { get; set; }
        public DateTime? DeletedAt { get; set; }
        
        
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
