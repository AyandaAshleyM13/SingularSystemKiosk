

namespace SingularSystemKiosk.Models
{
    using System.ComponentModel.DataAnnotations;
    public class DeliveryType
    {
        [Key]
        public int DeveryTypeId { get; set; }
        public string DeliveryTypeName  { get; set; }=string.Empty;

    }
}
