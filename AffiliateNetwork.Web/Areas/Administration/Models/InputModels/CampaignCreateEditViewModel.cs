﻿namespace AffiliateNetwork.Web.Areas.Administration.Models.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AffiliateNetwork.Common.Enumerations;
    using AffiliateNetwork.Infrastructure.Mapping;
    using AffiliateNetwork.Models;
    
    public class CampaignCreateEditViewModel : IMapFrom<Campaign>
    {
        public CampaignCreateEditViewModel()
        {
        }

        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MinLength(50)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryId { get; set; }

        [Required]
        public CampaignType Type { get; set; }

        [Required]
        [Display(Name = "Landing Page")]
        public string LandingPage { get; set; }

        [Required]
        [Display(Name = "Expiration Date")]
        public DateTime ValidTo { get; set; }

        [Required]
        public decimal Payout { get; set; }

        [Display(Name = "Status")]
        public ApprovalStatus ApprovalStatus { get; set; }

        [Display(Name = "Admin Comment")]
        public string AdminComment { get; set; }

        public string OwnerId { get; set; }
    }
}