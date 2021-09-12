using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PomagajLocaly.Models
{
    public partial class OfferType
    {
        public OfferType()
        {
            Offers = new HashSet<Offer>();
        }
        [Key]
        public Guid OfferTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
    }
}
