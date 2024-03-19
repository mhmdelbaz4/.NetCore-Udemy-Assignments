using Microsoft.AspNetCore.Mvc;

namespace _5.e_commerce_Orders_App___Model_Binding;

public class OrderController : Controller
{

    Random random = new Random(); 

    [Route("/order")]
    public IActionResult MakeOrder([FromForm] Order order)
    {
       
        if(ModelState.IsValid)
        {
            order.OrderNo = random.Next(0, 9999);
            return Content($"{order.OrderNo}");
        }
        else
        {
            string errors = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors)
                                                            .Select(error => error.ErrorMessage.ToString()));
            return BadRequest(errors);
        }
    }

}
