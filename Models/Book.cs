namespace BoundlessBooks.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string ISBN { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public int StockQty { get; set; }
    public int AuthorId { get; set; }
    public virtual Author? AuthorNavigation { get; set; }

    // Navigation property for the order details associated with this book
    public virtual ICollection<OrderDetails>? OrderDetails { get; set; }
}