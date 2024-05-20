var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();
app.Run(async (HttpContext context) =>
{
    var firstNumber = context.Request.Query["firstNumber"];
    var secondNumber = context.Request.Query["secondNumber"];
    var operation = context.Request.Query["add"];
    await context.Response.WriteAsync($"<h1>{firstNumber + secondNumber}</h1>");
});

/*
var app = builder.Build();
app.MapGet("/", () => "jhdfhvbehjdsbfbdsf");
app.Run();*/
// Add services to the container.
/*
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
*/