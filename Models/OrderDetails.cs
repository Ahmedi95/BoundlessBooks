namespace BoundlessBooks.Models;

public class OrderDetails
{
    public int Id { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public int BookId { get; set; }
    public int OrderId { get; set; }
    public virtual Order? OrderNavigation { get; set; }
    public virtual Book? BookNavigation { get; set; }
}