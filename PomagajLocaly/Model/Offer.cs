using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PomagajLocaly.Models
{
    public  class Offer
    {
        public Offer()
        {
            Vouchers = new HashSet<Voucher>();
        }
        [Key]
        public Guid OfferId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? OfferTypeId { get; set; }
        public double? Price { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual OfferType OfferType { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
