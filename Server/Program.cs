using Microsoft.AspNetCore.ResponseCompression;
using J2S.Server.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<UserContext>(options => { 

    options.UseSqlite("Data Source=J2S.db");
 });


builder.Services.AddSwaggerGen(opt => opt.SwaggerDoc("j2s-v1", new Microsoft.OpenApi.Models.OpenApiInfo() 
{
    Version = "v0.1",
    Title = "J2S-v0.1"

}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/v0.1/swagger.json", "J2S v0.1"));

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
