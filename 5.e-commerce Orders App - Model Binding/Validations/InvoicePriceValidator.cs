using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _5.e_commerce_Orders_App___Model_Binding.Validations;

public class InvoicePriceValidator : ValidationAttribute
{

    public InvoicePriceValidator(string otherPropertyName)
    {
        this.OtherPropertyName = otherPropertyName;
    }
    public string OtherPropertyName { get; set; }
    public string DefaultErrorMessage { get; set; } = "Invalid invoice price!";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(! int.TryParse(value?.ToString() ,out int invoicePrice))
        {
            return new ValidationResult("invoice price is required!");
        }

        PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);
        if (otherProperty is null)
            return new ValidationResult(ErrorMessage ?? "other property name is invalid");


        List<Product>? products=  otherProperty.GetValue(validationContext.ObjectInstance) as List<Product>;

        double totalProductsPrice = 0;

        foreach (Product product in products)
        {
            totalProductsPrice += (product.Price * product.Quantity);
        }

        if (invoicePrice == totalProductsPrice)
            return ValidationResult.Success;
        else
            return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
   
    
    }

}
