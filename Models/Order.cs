namespace BoundlessBooks.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; } = null!;
    public int UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public string Address { get; set; } = null!;
    public virtual User? UserNavigation { get; set; }

    // Navigation property for the order details associated with this order
    public virtual ICollection<OrderDetails>? OrderDetails { get; set; }
}