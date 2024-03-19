using System.ComponentModel.DataAnnotations;

namespace _5.e_commerce_Orders_App___Model_Binding;

public class Product
{
    [Range(0,1000)]
    public int Code { get; set; }

    [Range(1,int.MaxValue)]
    public double Price { get; set; }

    [Range(1,int.MaxValue)]
    public int Quantity { get; set; }

    public override string ToString()
    {
        return $"Order -> {Code} :{Price} :{Quantity}";
    }
}
