namespace SingularSystemKiosk.Models
{
    public class Orders
    {
        public int Id { get; set; }

     
        public int UserId { get; set; }
        public AppUser? User { get; set; }

        public int TransactionId { get; set; }
        public PaymentTransaction Transaction { get; set; } = null!;

        
        public int DeliveryTypeId { get; set; }
         public DeliveryType? DeliveryType { get; set; }
    

        public ICollection<OrderedItems> Items { get; set; } = new List<OrderedItems>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double OrderTotal { get; set; }  

    }
}
