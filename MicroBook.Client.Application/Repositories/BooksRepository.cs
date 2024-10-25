using MassTransit;
using MicroBook.Client.Domain.Abstractions;
using MicroBook.Contracts;
using Microsoft.Extensions.Configuration;

namespace MicroBook.Client.Application.Repositories;

/// <summary>
/// Repository for working with books.
/// </summary>
public class BooksRepository : IBooksRepository
{
    private readonly IBus _bus;
    private readonly IConfiguration _configuration;

    public BooksRepository(IConfiguration configuration, IBus bus)
    {
        _bus = bus;
        _configuration = configuration;
    }

    /// <summary>
    /// Buys a book and decrese its amount on storage.
    /// </summary>
    /// <param name="id">Book Id.</param>
    /// <param name="amount">Number of books ordered.</param>
    /// <returns></returns>
    public async Task BuyBookAsync(int id, int amount)
    {
        var exchangeUri = new Uri($"exchange:{_configuration["RabbitMQ:Exchanges:Books"]!}");
        var endpoint = await _bus.GetSendEndpoint(exchangeUri);

        await endpoint.Send(new UpdateBook
        {
            BookId = id,
            Amount = amount
        });
    }
}