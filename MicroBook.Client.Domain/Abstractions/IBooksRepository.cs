namespace MicroBook.Client.Domain.Abstractions;

/// <summary>
/// Repository for working with books.
/// </summary>
public interface IBooksRepository
{
    /// <summary>
    /// Buys a book and decrese its amount on storage.
    /// </summary>
    /// <param name="id">Book Id.</param>
    /// <param name="amount">Number of books ordered.</param>
    /// <returns></returns>
    public Task BuyBookAsync(int id, int amount);
}
