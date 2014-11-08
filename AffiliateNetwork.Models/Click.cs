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
        public string AffiliateId { get; set; }

        public virtual User Affiliate { get; set; }

        [Required]
        public int CampaignId { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
