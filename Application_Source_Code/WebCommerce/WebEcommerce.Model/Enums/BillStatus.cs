using System.ComponentModel;

namespace WebEcommerce.Model.Enums
{
    public enum BillStatus
    {
        [Description("New bill")]
        New,

        [Description("In Progress")]
        InProgress,

        [Description("Returned")]
        Returned,

        [Description("Cancelled")]
        Cancelled,

        [Description("Completed")]
        Completed
    }
}