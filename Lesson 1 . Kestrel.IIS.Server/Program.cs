
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    var operators = new List<string>()
    {
        "add",
        "multiply",
        "division",
        "subtraction",
        "residual",
    };

    if (context.Request.Method == "GET")
    {
        var result = Checked(context.Request.Query);
        if (result.Any())
        {
            context.Response.StatusCode = 400;
        }
        foreach (var item in result)
        {
            await context.Response.WriteAsync($"<h1> Invalid input for '{item}'</h1>");
        }
    }
    else if (!operators.Contains(context.Request.Query["operation"]))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync($"<h1> Invalid input for 'operation' </h1>");
    }
    else
    {
        var firstNumber = context.Request.Query["firstNumber"];
        var secondNumber = context.Request.Query["secondNumber"];
        var operation = context.Request.Query["operation"];

    }
});

List<string> Checked(IQueryCollection query)
{

    List<string> errors = new List<string>();
    if (!query.ContainsKey("firstNumber"))
        errors.Add("firstNumber");
    if (!query.ContainsKey("secondNumber"))
        errors.Add("secondNumber");
    if (!query.ContainsKey("operation"))
        errors.Add("operation");

    return errors;
}

int result(int first, int second, string operation) =>
    operation switch
    {
        "add" => first + second,
        "multiply" => first * second,
        "division" => first / second,
        "subtraction" => first - second,
        "residual" => first % second,
    };




    //app.MapGet("/", () => "Hello world");
    /*app.Run(async (HttpContext context)
        =>
    {
        var path = context.Request.Path;
        context.Response.Headers["MyKey"] = "My value";
        context.Response.Headers["Server"] = "knskdjnksjd";
        context.Response.StatusCode = StatusCodes.Status404NotFound;
        await context.Response.WriteAsync($"<h1>{path}</h1>");
    });
    */
app.Run();