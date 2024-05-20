var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();
app.Run( async (HttpContext context) =>
{
    var firstNumber = context.Request.Query["firstNumber"];
    var secondNumber = context.Request.Query["secondNumber"];
    var operation = context.Request.Query["add"];
  await  context.Response.WriteAsync($"<h1>{firstNumber + secondNumber}</h1>");
});