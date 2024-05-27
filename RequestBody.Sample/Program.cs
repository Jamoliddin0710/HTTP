using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Numerics;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    using(var reader = new StreamReader(context.Request.Body))
    {
        string body = await reader.ReadToEndAsync();
        Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

        if (queryDict.ContainsKey("firstname"))
        {
            string fName = queryDict["firstname"][0];
            await context.Response.WriteAsync(fName);
        }
    }
});
app.Run();

// Postman Request firstname = jamoliddin & phone = 9989379237345 & phone = 9989379237234