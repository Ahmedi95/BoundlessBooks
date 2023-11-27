using BoundlessBooks.Models;
using BoundlessBooks.Data;
using BoundlessBooks.Helpers;

namespace BoundlessBooks.Services;

public class CheckoutService
{
    // Private field to hold the reference to the database context
    private readonly BoundlessBooksDBContext _dbContext;

    // Constructor for CheckoutService, which takes a BoundlessBooksDBContext as a dependency
    public CheckoutService(BoundlessBooksDBContext dbContext)
    {
        // Assigning the provided database context to the private field
        _dbContext = dbContext;
    }


    public async Task<int> PlaceOrder(int userId, decimal totalAmount, string address)
    {
        var order = new Order
        {
            Date = DateTime.Now,
            Status = "order-placed",
            UserId = userId,
            TotalAmount = totalAmount,
            Address = address
        };

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();

        return order.Id;
    }

    public async Task AddOrderDetail(int orderId, int bookId, decimal unitPrice)
    {
        var orderDetail = new OrderDetails
        {
            OrderId = orderId,
            BookId = bookId,
            Quantity = 1,
            UnitPrice = unitPrice
        };

        _dbContext.OrderDetails.Add(orderDetail);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateBookStock(int bookId)
    {
        var book = _dbContext.Books.Find(bookId);

        if (book != null && book.StockQty > 0)
        {
            book.StockQty--;
            await _dbContext.SaveChangesAsync();
        }
    }

}