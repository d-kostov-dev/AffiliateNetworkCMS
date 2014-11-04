namespace AffiliateNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    using AffiliateNetwork.Common.Enumerations;

    public class InfoPage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        public string Content { get; set; }

        public virtual YesNo IsVisible { get; set; }
    }
}
