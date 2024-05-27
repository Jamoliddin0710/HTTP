using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    StreamReader stream = new StreamReader(context.Response.Body);
    string body = await stream.ReadToEndAsync();
    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    if (queryDict.ContainsKey("firstname"))
    {
        string fName = queryDict["firstname"][0];
        await context.Response.WriteAsync(fName);
    }

});

app.Run();