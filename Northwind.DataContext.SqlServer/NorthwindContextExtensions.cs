using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.DataContext;

namespace Packt.Shared;

public static class NorthwindContextExtensions
{
    /// <summary>
    /// Adds NorthwindContext to the specified IServiceCollection. Uses the
    /// SqlServer database provider.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString">Source of data. Has defualt set to LocalDB Northwind catalog.".."</param>
    /// <return>An IServiceCollection that can be used to add more services.</return>
    public static IServiceCollection AddNorthwindContext(
        this IServiceCollection services,
        string connectionString =
        @"Data Source=.; 
        Initial Catalog=Northwind; 
        Integrated Security=true; 
        MultipleActiveResultSets=true; 
        Trust Server Certificate=true")
    {
        string connection = connectionString;

        services.AddDbContext<NorthwindContext>(options =>
        {
            options.UseSqlServer(connection);
        });
        return services;
    }
}