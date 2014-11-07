namespace AffiliateNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AffiliateNetwork.Common.Enumerations;

    public class Campaign
    {
        private ICollection<Click> clicks;
        private ICollection<Conversion> conversions;
        private ICollection<Banner> banners;
        private ICollection<User> affiliates;

        public Campaign()
        {
            this.clicks = new HashSet<Click>();
            this.conversions = new HashSet<Conversion>();
            this.banners = new HashSet<Banner>();
            this.affiliates = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MinLength(50)]
        public string Description { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public virtual CampaignType Type { get; set; }

        [Required]
        [Display(Name = "Landing Page")]
        public string LandingPage { get; set; }

        [Required]
        public decimal Payout { get; set; }

        [Required]
        public virtual User Owner { get; set; }

        public virtual ICollection<User> Affiliates
        {
            get
            {
                return this.affiliates;
            }

            set
            {
                this.affiliates = value;
            }
        }

        public virtual DateTime DateCreated { get; set; }

        [Required]
        [Display(Name = "Expiration Date")]
        public virtual DateTime ValidTo { get; set; }

        public virtual ICollection<Click> Clicks
        { 
            get
            {
                return this.clicks;
            }

            set
            {
                this.clicks = value;
            }
        }

        public virtual ICollection<Conversion> Conversions
        {
            get
            {
                return this.conversions;
            }

            set
            {
                this.conversions = value;
            }
        }

        public virtual ICollection<Banner> Banners
        {
            get
            {
                return this.banners;
            }

            set
            {
                this.banners = value;
            }
        }

        [Display(Name = "Status")]
        public virtual ApprovalStatus ApprovalStatus { get; set; }

        public string AdminComment { get; set; }
    }
}
