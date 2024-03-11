var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.UseWhen((context) => context.Request.Method == "Post", app =>
                app.Use(async (HttpContext context, RequestDelegate next) =>
                {
                    string? userName = context.Request.Form["username"];
                    string? password = context.Request.Form["password"];

                    if (userName != null && password != null)
                    {
                        await context.Response.WriteAsync($"userName :{userName}\nPassword :{password}");
                        context.Response.StatusCode = 200;
                    }
                    else
                    {
                        Console.WriteLine("Hello");
                        context.Response.StatusCode = 404;
                    }
                }));



app.Run();
