namespace AffiliateNetwork.Common.Enumerations
{
    using System.ComponentModel.DataAnnotations;

    public enum ApprovalStatus
    {
        [Display(Name = "Waiting Approval")]
        Waiting,

        [Display(Name = "Approved")]
        Approved,

        [Display(Name = "Disapproved")]
        Disapproved,
    }
}
