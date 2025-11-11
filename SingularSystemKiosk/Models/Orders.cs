namespace SingularSystemKiosk.Models
{
    public class Orders
    {
        public int Id { get; set; }

     
        public int? UserId { get; set; }
        public AppUser? User { get; set; }

        public int TransactionId { get; set; }
        public PaymentTransaction Transaction { get; set; } = null!;

        public string Status { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;

        public ICollection<OrderedItems> Items { get; set; } = new List<OrderedItems>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
