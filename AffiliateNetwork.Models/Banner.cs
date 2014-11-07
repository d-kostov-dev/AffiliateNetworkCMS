namespace AffiliateNetwork.Models
{
    using AffiliateNetwork.Models.Base;
    using System.ComponentModel.DataAnnotations;

    public class Banner : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Campaign Campaign { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
