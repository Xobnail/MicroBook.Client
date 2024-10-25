namespace MicroBook.Client.Domain.Abstractions;

public interface IBooksRepository
{
    public Task BuyBookAsync(int id, int amount);
}
