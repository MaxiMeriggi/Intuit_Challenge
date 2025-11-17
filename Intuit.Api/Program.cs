using Intuit.Application;
using Intuit.Infrastructure;
using Intuit.Infrastructure.Database;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

#region swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cliente API",
        Version = "v1",
        Description = "API for managing Clients"
    });

    var xmlFile = $"{AppDomain.CurrentDomain.BaseDirectory}/Intuit.Api.xml";
    c.IncludeXmlComments(xmlFile);
});


#endregion



builder.Services.ConfigureApplicationLayer()
                .ConfigureInfraLayer(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cliente API V1");
    c.RoutePrefix = string.Empty; 
});

var scriptPath = Path.Combine(AppContext.BaseDirectory, "Database", "Scripts");

var initializer = new DatabaseInitializer(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    scriptPath
    );
initializer.InitializeDatabase();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseMiddleware<ExceptionInterceptor>();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
