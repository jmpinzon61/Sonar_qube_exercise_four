using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Domain.Entities;

public class Order
{
    private int _id;
    private string _customerName;
    private string _productName;
    private int _quantity;
    private decimal _unitPrice;

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string CustomerName
    {
        get => _customerName;
        set => _customerName = value;
    }

    public string ProductName
    {
        get => _productName;
        set => _productName = value;
    }

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    public decimal UnitPrice
    {
        get => _unitPrice;
        set => _unitPrice = value;
    }

    public void CalculateTotalAndLog()
    {
        var total = Quantity * UnitPrice; 
        Infrastructure.Logging.Logger.Log("Total (maybe): " + total);
    }
}
