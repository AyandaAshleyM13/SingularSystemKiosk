namespace SingularSystemKiosk.Models
{
    public class PaymentTransaction
    {
        public int Id { get; set; }
       public int UserId { get; set; }

        public AppUser? User { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; } = null!;
        public int OrderId { get; set; }
        public Orders Orders { get; set; } = null!;

        public decimal Amount { get; set; }
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType =null!;
        public DateTime CreatedAt { get; set; }
     
    }
}
