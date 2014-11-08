namespace AffiliateNetwork.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AffiliateNetwork.Models.Base;
    
    public class SiteSetting : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        [MinLength(3)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
