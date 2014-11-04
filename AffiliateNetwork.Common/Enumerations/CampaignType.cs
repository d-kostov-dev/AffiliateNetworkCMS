namespace AffiliateNetwork.Common.Enumerations
{
    using System.ComponentModel.DataAnnotations;

    public enum CampaignType
    {
        [Display(Name = "Cost Per Click")]
        CPC,

        [Display(Name = "Cost Per Action")]
        CPA,
    }
}
