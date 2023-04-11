using Northwind.DataContext;

namespace AspNetMVC.Models;

public record HomeOrdersByCustomersViewModel(
    IList<Order> Orders,
    Customer OrdersCustomer
);