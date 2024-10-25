using MassTransit;
using MicroBook.Client.Domain.Abstractions;
using MicroBook.Contracts;
using Microsoft.Extensions.Configuration;

namespace MicroBook.Client.Application.Repositories;

public class BooksRepository : IBooksRepository
{
    private readonly IBus _bus;
    private readonly IConfiguration _configuration;

    public BooksRepository(IConfiguration configuration, IBus bus)
    {
        _bus = bus;
        _configuration = configuration;
    }

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