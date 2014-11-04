namespace AffiliateNetwork.Common.Enumerations
{
    using System.ComponentModel.DataAnnotations;

    public enum YesNo
    {
        [Display(Name = "No")]
        False = 0,

        [Display(Name = "Yes")]
        True = 1,
    }
}
