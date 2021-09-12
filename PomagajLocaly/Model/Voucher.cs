using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PomagajLocaly.Models
{
    public partial class Voucher
    {
        [Key]
        public Guid VoucherId { get; set; }
        public Guid UserId { get; set; } 
        public Guid? OfferId { get; set; }
        public double? StartAmount { get; set; }
        public double? CurrentAmount { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public virtual Offer Offer { get; set; }
    }
}
