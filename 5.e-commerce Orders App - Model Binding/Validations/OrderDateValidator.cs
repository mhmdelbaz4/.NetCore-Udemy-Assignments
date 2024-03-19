using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace _5.e_commerce_Orders_App___Model_Binding.Validations;

public class OrderDateValidator :ValidationAttribute
{
    public string DefaultErrorMessage { get; set; } = "Invalid Order Date";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        DateTime? orderDate = value as DateTime?;
 
        if (! orderDate.HasValue)
        {
            DefaultErrorMessage = "Order Date can't be null";
           return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
        }

        if(orderDate.Value.CompareTo(DateTime.Now) <0 )
        {
            DefaultErrorMessage = "Invalid order Date";
            return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
        }

        if((orderDate - DateTime.Now).Value.Days > 30)
        {
            DefaultErrorMessage = "Can't accept order date more than 30 days";
            return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
        }

        return ValidationResult.Success;
    }
}
