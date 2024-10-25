using MicroBook.Client.Application.Repositories;
using MicroBook.Client.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace MicroBook.Client.Application;

/// <summary>
/// Entry class for Application layer.
/// </summary>
public static class Entry
{
    /// <summary>
    /// Registers services for application layer.
    /// </summary>
    /// <param name="services">Services to add to.</param>
    /// <returns>The same service collection.</returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBooksRepository, BooksRepository>();

        return services;
    }
}
