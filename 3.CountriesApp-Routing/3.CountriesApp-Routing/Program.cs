using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


Dictionary<int, string> countries = new Dictionary<int, string>()
{
    {1 , "USA" },
    {2 , "Canada" },
    {3 , "United Kingdom" },
    {4 , "India" },
    {5 , "Japan" }
};

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/countries", context =>
    {

        StringBuilder result = new StringBuilder();
        foreach (var country in countries)
        {
            result.Append(country.Key + ", "+ country.Value +"\n");
        }

        context.Response.StatusCode = 200;
        return  context.Response.WriteAsync($"{result}");
    });

    endpoints.Map("/countries/{key:int}", context =>
    {
        Console.WriteLine(context.Request.RouteValues["key"]);
        int key =int.Parse(context.Request.RouteValues["key"].ToString());
        if(key >0 && key <6)
        {
            context.Response.StatusCode = 200;
            return context.Response.WriteAsync($"{countries[key]}");
        }
        else if(key >=6 && key<=100)
        {
            context.Response.StatusCode = 404;
            return context.Response.WriteAsync($"[No Country]");
        }else {
            context.Response.StatusCode = 400;
            return context.Response.WriteAsync($"The CountryID should be between 1 and 100");

        }
    });

    endpoints.Map("/", context =>
    {
       return context.Response.WriteAsync("Hello World!");
    });
});



app.Run();
