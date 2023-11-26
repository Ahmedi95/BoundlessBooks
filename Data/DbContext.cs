using Microsoft.EntityFrameworkCore;
using BoundlessBooks.Models;

namespace BoundlessBooks.Data;

public partial class BoundlessBooksDBContext : DbContext
{
    public BoundlessBooksDBContext()
    {

    }

    public BoundlessBooksDBContext(DbContextOptions<BoundlessBooksDBContext> options) : base(options)
    {

    }

    public virtual DbSet<Author> Authors { get; set; } = null!;
    public virtual DbSet<Book> Books { get; set; } = null!;
    public virtual DbSet<Order> Orders { get; set; } = null!;
    public virtual DbSet<OrderDetails> OrderDetails { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        // create author table
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("author");

            entity.Property(e => e.Id)
               .HasColumnType("int(11)")
               .HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        // create book table
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("book");
            entity.HasIndex(e => e.ISBN, "isbn").IsUnique();

            entity.Property(e => e.Id)
               .HasColumnType("int(11)")
               .HasColumnName("id");

            entity.Property(e => e.Title)
                .HasMaxLength(250)
                .HasColumnName("title");

            entity.Property(e => e.ISBN)
                .HasMaxLength(100)
                .HasColumnName("isbn");

            entity.Property(e => e.Price)
                .HasColumnType("decimal")
                .HasColumnName("price");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");

            entity.Property(e => e.Image)
                .HasMaxLength(20)
                .HasColumnName("image");

            entity.Property(e => e.StockQty)
               .HasColumnType("int(11)")
               .HasColumnName("stock_qty");

            entity.Property(e => e.AuthorId)
                .HasColumnType("int(11)")
                .HasColumnName("author_id");

            // Configuring the relationship between Book and Author
            entity.HasOne(e => e.AuthorNavigation)
                .WithMany(a => a.Books)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if an author is deleted
        });

        // create user table
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("user");
            entity.HasIndex(e => e.UserName, "user_name").IsUnique();

            entity.Property(e => e.Id)
               .HasColumnType("int(11)")
               .HasColumnName("id");

            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");

            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .HasColumnName("password");

            entity.Property(e => e.Salt)
                .HasMaxLength(64)
                .HasColumnName("salt");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");

            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .HasColumnName("phone_number");
        });

        // create order table
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("order");

            entity.Property(e => e.Id)
               .HasColumnType("int(11)")
               .HasColumnName("id");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal")
                .HasColumnName("total_amount");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");

            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            // Configuring the relationship between Book and Author
            entity.HasOne(e => e.UserNavigation)
                .WithMany(a => a.Orders)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if an author is deleted
        });

        // create order details table
        modelBuilder.Entity<OrderDetails>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("order_details");

            entity.Property(e => e.Id)
               .HasColumnType("int(11)")
               .HasColumnName("id");

            entity.Property(e => e.UnitPrice)
            .HasColumnType("decimal")
            .HasColumnName("unit_price");

            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");

            entity.Property(e => e.BookId)
                .HasColumnType("int(11)")
                .HasColumnName("book_id");

            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("order_id");

            // Configure foreign key for Book
            entity.HasOne(od => od.BookNavigation)
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(od => od.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure foreign key for Order
            entity.HasOne(od => od.OrderNavigation)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}