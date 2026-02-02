using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: Customer from USA
        Address addr1 = new Address("456 Lincoln Ave", "Chicago", "IL", "USA");
        Customer cust1 = new Customer("Alice Smith", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Webcam 1080p", "W-20", 45.99, 1));
        order1.AddProduct(new Product("USB Hub", "U-05", 15.00, 2));

        // Order 2: International Client
        Address addr2 = new Address("Calle 10 #45", "Bogotá", "DC", "Colombia");
        Customer cust2 = new Customer("Juan Pérez", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Mechanical Keyboard", "K-99", 89.00, 1));
        order2.AddProduct(new Product("Mouse Pad", "P-01", 10.00, 3));
        order2.AddProduct(new Product("HDMI Cable", "C-12", 8.50, 1));

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (var order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.CalculateTotal():0.00}\n");
            Console.WriteLine(new string('=', 40) + "\n");
        }
    }
}