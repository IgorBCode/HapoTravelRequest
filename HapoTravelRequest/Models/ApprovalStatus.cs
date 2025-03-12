using System.ComponentModel;

namespace HapoTravelRequest.Models
{
    public enum ApprovalStatus
    {
        [Display(Name = "Pending")]
        Pending = 0,

        [Display(Name = "VP Approved")]
        ApprovedByVP = 1,

        [Display(Name = "CEO Approved")]
        ApprovedByCEO = 2,

        [Display(Name = "Booked")]
        Booked = 3,

        [Display(Name = "Denied")]
        Denied = 4
    }
}
