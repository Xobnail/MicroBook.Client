using MicroBook.Client.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MicroBook.Client.Host.Controllers;

public class BooksController : ControllerBase
{
    private readonly IBooksRepository _booksRepository;

    public BooksController(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    [HttpPost]
    [Route("Books/Buy")]
    public async Task<IActionResult> BuyBookAsync(int id, int amount)
    {
        await _booksRepository.BuyBookAsync(id, amount);

        return Ok();
    }
}
