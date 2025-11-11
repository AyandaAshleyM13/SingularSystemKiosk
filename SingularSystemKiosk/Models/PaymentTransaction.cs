namespace SingularSystemKiosk.Models
{
    public class PaymentTransaction
    {
        public int Id { get; set; }
       public int UserId { get; set; }

        public AppUser User { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } 
        public string TransactionType { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
