namespace AffiliateNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AffiliateNetwork.Common.Enumerations;
    using AffiliateNetwork.Models.Base;

    public class Campaign : AuditInfo
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
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        public virtual Category Category { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual CampaignType Type { get; set; }

        [Required]
        [Display(Name = "Landing Page")]
        public string LandingPage { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Payout { get; set; }

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

        [Display(Name = "Admin Comment")]
        [DataType(DataType.MultilineText)]
        public string AdminComment { get; set; }
    }
}
