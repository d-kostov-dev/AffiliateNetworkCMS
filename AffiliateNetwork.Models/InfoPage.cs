namespace AffiliateNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    using AffiliateNetwork.Common.Enumerations;
    using AffiliateNetwork.Models.Base;

    public class InfoPage : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Display(Name = "Seo URL")]
        public string SeoUrl { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public int Order { get; set; }
    }
}
