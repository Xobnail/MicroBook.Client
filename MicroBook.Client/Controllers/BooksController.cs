using MicroBook.Client.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MicroBook.Client.Host.Controllers;

/// <summary>
/// Controller for working with books. 
/// </summary>
public class BooksController : ControllerBase
{
    private readonly IBooksRepository _booksRepository;

    public BooksController(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    /// <summary>
    /// Buys a book and decrease its amount on storage.
    /// </summary>
    /// <param name="id">Book Id.</param>
    /// <param name="amount">Number of books ordered.</param>
    /// <returns>Ok.</returns>
    [HttpPost]
    [Route("Books/Buy")]
    public async Task<IActionResult> BuyBookAsync(int id, int amount)
    {
        await _booksRepository.BuyBookAsync(id, amount);

        return Ok();
    }
}
