namespace AffiliateNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Campaign Campaign { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
