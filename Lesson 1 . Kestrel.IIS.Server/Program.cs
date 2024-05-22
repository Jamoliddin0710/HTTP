
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
        string operation = context.Request.Query["operation"];
        var errors = Checked(context.Request.Query);
        if(errors.Any())
        {
            context.Response.StatusCode = 400;
            foreach (var item in errors)
            {
                await context.Response.WriteAsync($"<h1> Invalid input for '{item}'</h1>");
            }
        }
        else if (!operators.Contains(operation))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync($"<h1> Invalid input for 'operation' </h1>");
        }
        else
        {
            int firstNumber = int.Parse(context.Request.Query["firstNumber"]);
            int secondNumber = int.Parse(context.Request.Query["secondNumber"]);
            int  finallyresult =  result(firstNumber, secondNumber , operation);
             context.Response.StatusCode = 200;
            await context.Response.WriteAsync($"<h1>{finallyresult}</h1>");
        }
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

app.Run();



