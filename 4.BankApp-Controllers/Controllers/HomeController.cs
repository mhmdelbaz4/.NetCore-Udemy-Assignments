using Microsoft.AspNetCore.Mvc;

namespace _4.BankApp_Controllers.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    [Route("/")]
    public IActionResult Home()
    {
        return Content("Hello World", "text/plain");
    }

    [HttpGet]
    [Route("/account-details")]
    public IActionResult Details()
    {
        var obj = new { accountNumber = 1001, accountHolderName = "Example Name", currentBalance = 5000 };
        return Json(obj);
    }

    [HttpGet]
    [Route("/account-statement")]
    public IActionResult AccountStatement()
    {
        return Content("~/SQL Server Fundamentals.pdf", "application/pdf");
    }

    [HttpGet]
    [Route("/get-current-balance/{accountNumber:int?}")]
    public IActionResult AccountBalance()
    {
        if (Request.RouteValues["accountNumber"] == null)
        {
            return NotFound("Account Number should be supplied");
        }

        int num =int.Parse(Request.RouteValues["accountNumber"].ToString());

        if(num == 1001)
        {
            return Content("5000", "text/plain");
        }
        else
        {
            return BadRequest("Account Number should be 1001");
        }
    }
}
