using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetMVC.Models;
using Northwind.DataContext;
using Microsoft.EntityFrameworkCore;

namespace AspNetMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly NorthwindContext _db;

    public HomeController(ILogger<HomeController> logger,
    NorthwindContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any)]
    public async Task<IActionResult> Customers()
    {
        HomeCustomersViewModel model = new(
            Customers: await _db
            .Customers.ToListAsync()
        );
        return View(model);
    }

    public async Task<IActionResult> CustomerOrders(string? id)
    {
        HomeOrdersByCustomersViewModel model = new(
            Orders: await _db.Orders
            .OrderBy(o => o.ShipName).ToListAsync(),
            OrdersCustomer: await _db.Customers
            .SingleOrDefaultAsync(c => c.CustomerId == id)
        );

        if (id == null) return NotFound($"Customer with {id} was not found.");

        return View(model);
    }

    public async Task<IActionResult> OrderDetails(int? id, string? customerId)
    {
        HomeOrderDetailViewModel model = new(
            CustomersOrder: await _db.Orders
            .SingleOrDefaultAsync(o => o.OrderId == id),
            OrdersCustomer: await _db.Customers
            .SingleOrDefaultAsync(c => c.CustomerId == customerId)
        );

        if (id == null) return NotFound($"Customer with {id} was not found.");

        return View(model);
    }

    public async Task<IActionResult> CustomersThatInCountry(string? country)
    {
        HomeCustomersViewModel model = new(
            Customers: await _db
            .Customers.Where(c => c.Country == country)
            .ToListAsync()
        );
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
