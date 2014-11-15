namespace AffiliateNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AffiliateNetwork.Models.Base;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    public class User : IdentityUser, IAuditInfo
    {
        private ICollection<Campaign> campaigns;
        private ICollection<Click> clicks;

        public User()
        {
            // This will prevent UserManager.CreateAsync from causing exception
            this.CreatedOn = DateTime.Now;
            this.campaigns = new HashSet<Campaign>();
            this.clicks = new HashSet<Click>();
        }

        public virtual ICollection<Campaign> Campaings
        {
            get
            {
                return this.campaigns;
            }

            set
            {
                this.campaigns = value;
            }
        }

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

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Index]
        public DateTime? DeletedOn { get; set; }

        [DefaultValue(0.00)]
        public decimal Credits { get; set; }

        public int? PhotoId { get; set; }

        public virtual ProfilePhoto Photo { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}
