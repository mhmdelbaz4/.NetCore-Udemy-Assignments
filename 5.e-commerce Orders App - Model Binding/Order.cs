using _5.e_commerce_Orders_App___Model_Binding.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _5.e_commerce_Orders_App___Model_Binding;

public class Order
{
    [BindNever]
    public int? OrderNo { get; set; }

    [Required]
    [OrderDateValidator]
    public DateTime OrderDate { get; set; }


    [InvoicePriceValidator(nameof(Products))]
    public double? InvoicePrice { get; set; }

    [Required]
    public List<Product> Products { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"{OrderNo} : {OrderDate} :{InvoicePrice}\n");

        foreach ( var item in Products )
        {
            sb.Append( item.ToString() );
        }

        return sb.ToString();
    }
}
