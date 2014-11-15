namespace AffiliateNetwork.Models
{
    using System.ComponentModel.DataAnnotations;

    using AffiliateNetwork.Models.Base;

    public class ProfilePhoto : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
