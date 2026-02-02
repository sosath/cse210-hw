using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        double shipping = _customer.LivesInUSA() ? 5.00 : 35.00;
        return total + shipping;
    }

    public string GetPackingLabel()
    {
        string label = "--- Packing Label ---\n";
        foreach (var p in _products)
        {
            label += p.GetPackingInfo() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"--- Shipping Label ---\n{_customer.GetName()}\n{_customer.GetAddressDetails()}\n";
    }
}