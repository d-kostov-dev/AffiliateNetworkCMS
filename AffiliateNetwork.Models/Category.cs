namespace AffiliateNetwork.Models
{
    using AffiliateNetwork.Models.Base;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category : AuditInfo
    {
        private ICollection<Campaign> campaigns;

        public Category()
        {
            this.campaigns = new HashSet<Campaign>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Campaign> Campaigns
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
    }
}
