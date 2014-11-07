namespace AffiliateNetwork.Models
{
    using AffiliateNetwork.Models.Base;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Click : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User Affiliate { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
