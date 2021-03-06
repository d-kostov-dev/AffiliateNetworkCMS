﻿namespace AffiliateNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AffiliateNetwork.Models.Base;

    public class Click : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AffiliateId { get; set; }

        [ForeignKey("AffiliateId")]
        public virtual User Affiliate { get; set; }

        [Required]
        public int CampaignId { get; set; }

        [ForeignKey("CampaignId")]
        public virtual Campaign Campaign { get; set; }
    }
}
