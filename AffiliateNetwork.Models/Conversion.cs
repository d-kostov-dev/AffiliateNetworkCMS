namespace AffiliateNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Conversion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User Affiliate { get; set; }

        public virtual Campaign Campaign { get; set; }

        [Display(Name = "Date")]
        public virtual DateTime DateCreated { get; set; }
    }
}
