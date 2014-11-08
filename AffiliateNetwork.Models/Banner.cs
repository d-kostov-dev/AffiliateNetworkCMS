namespace AffiliateNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    using AffiliateNetwork.Models.Base;
    
    public class Banner : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CampaignId { get; set; }

        public virtual Campaign Campaign { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
