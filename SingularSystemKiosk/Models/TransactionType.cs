
namespace SingularSystemKiosk.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TransactionType
    {

        public int TransactionTypeId { get; set; }
        [Required]
        public string TransactionTypeName { get; set; }=string.Empty;
    }
}
