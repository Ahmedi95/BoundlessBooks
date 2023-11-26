namespace BoundlessBooks.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    // Navigation property for the books associated with this author
    public virtual ICollection<Book>? Books { get; set; }
}