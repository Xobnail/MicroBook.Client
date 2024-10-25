using MicroBook.Client.Application.Repositories;
using MicroBook.Client.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroBook.Client.Application;
public static class Entry
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBooksRepository, BooksRepository>();

        return services;
    }
}
