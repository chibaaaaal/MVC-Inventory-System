namespace MVC_Inventory_System.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int QuantitySold { get; set; }
        public DateTime TransactionDate { get; set; }

        public Product Product { get; set; }
    }
}
