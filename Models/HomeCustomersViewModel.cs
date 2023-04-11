using Northwind.DataContext;

namespace AspNetMVC.Models;

// Model with Customers
public record HomeCustomersViewModel
(
    IList<Customer> Customers
);