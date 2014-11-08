using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AffiliateNetwork.Common.Enumerations;

namespace AffiliateNetwork.Web.Areas.Administration.Models.InputModels
{
    public class CampaignCreateEditViewModel
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

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public CampaignType Type { get; set; }

        [Required]
        public string LandingPage { get; set; }

        [Required]
        public DateTime ValidTo { get; set; }

        [Required]
        public decimal Payout { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; }

        public string AdminComment { get; set; }
    }
}