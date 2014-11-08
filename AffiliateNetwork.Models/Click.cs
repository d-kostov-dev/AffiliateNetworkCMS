namespace AffiliateNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AffiliateNetwork.Models.Base;
    
    public class Click : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual User Affiliate { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
