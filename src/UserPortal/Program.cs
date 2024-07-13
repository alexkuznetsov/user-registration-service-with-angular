using UserPortal.Application;
using UserPortal.Endpoints;
using UserPortal.Infrastructure;
using UserPortal.Options;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    WebRootPath = "wwwroot/browser"
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(b =>
    {
        b.ConfigureCorsOptions(builder.Environment, builder.Configuration);
    });
});

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseExceptionHandler("/error");

app.UseCors();
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseApplicationEndpoints();

app.UseDatabaseMigrator();

app.UseStaticFiles();

app.MapFallbackToFile("index.html");

app.Run();