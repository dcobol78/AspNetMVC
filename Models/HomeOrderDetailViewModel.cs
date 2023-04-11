using Northwind.DataContext;

namespace AspNetMVC.Models;

public record HomeOrderDetailViewModel(
    Order CustomersOrder,
    Customer OrdersCustomer
);