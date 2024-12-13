using RandomPos;
using Microsoft.AspNetCore.Mvc;
using Sprache;
using FireSharp.Extensions;
using FirebaseMedium;
[assembly: ApiController]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapPost("/A1", async (HttpContext context) => {  
    var result = await Desserilize.A2(context);
    if (result != null && result.Any())
    {
       Randominator.randomize(result);
    }
    return Results.Ok(result);
});

app.MapPost("/A2", async (HttpContext context) => { 
    //await FirebaseMedium.Program.Main();
    Data takeReturn = new Data{};

    FirebaseMedium.Data res = new Data{ CaracsGenerateds = await Desserilize.A3(context), PasswordName = null};
    
     if (res != null)
    {
        takeReturn = await Randominator.Click(res);
    }
    
    return Results.Ok(takeReturn);
});


app.MapGet("/A3", async () =>{
        var res = await FirebaseMedium.Crud.Consult();
        System.Console.WriteLine("this is res: " + res);
        return Results.Ok(res);
});
app.Run();
