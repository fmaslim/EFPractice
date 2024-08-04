using EFPractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//var app = builder.Build();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the db context
builder.Services.AddDbContext<AdventureWorks2019DBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AdventureWorks2019")
));


// Add Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EFPractice Swagger API",
        Description = "An ASP.NET Core Web API for EFPractice",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "EF Practice",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "EFPractice License",
            Url = new Uri("https://example.com/license")
        }
    });
});

/*
 * EF tool to generate models
 * https://www.learnentityframeworkcore.com/walkthroughs/existing-database
 * dotnet ef dbcontext scaffold "(Server=.\;Database=AdventureWorksLT2012;Trusted_Connection=True;") Microsoft.EntityFrameworkCore.SqlServer -o Model
 */

var app = builder.Build();

app.MapDefaultControllerRoute();// {controller=Home} / {action=Index} / {id?}
app.MapControllerRoute("default", "{controller}/{action}/{id:int?}");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    // Add Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
    if (builder.Environment.IsDevelopment())
    {
        app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // matches incoming request with an endpoint
//app.useEndPoint(); //

app.UseAuthorization();

app.MapRazorPages();

app.Run();
