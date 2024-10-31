namespace MicroBook.Contracts;

/// <summary>
/// Contract for updating book after order.
/// </summary>
public record UpdateBook
{
    /// <summary>
    /// Book Id.
    /// </summary>
    public int BookId { get; init; }
    /// <summary>
    /// Number of books ordered 
    /// </summary>
    public int Amount { get; init; }
}