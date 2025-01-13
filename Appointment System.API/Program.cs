using Appointment_System.API;
using AppointmentSystem.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.OpenApi.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Hello World
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
// Configure supported cultures
var supportedCultures = new[] { "en-US", "de-DE" };
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
    options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
});
builder.Services.AddSwaggerGen(c =>
{
    // Add Accept-Language parameter to Swagger UI
    c.AddSecurityDefinition("Accept-Language", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Accept-Language",
        Type = SecuritySchemeType.ApiKey,
        Description = "Add the language code (e.g., 'de' for German) to this header",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Accept-Language"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddAppDI(builder.Configuration);


var app = builder.Build();
app.UseRequestLocalization();

app.UseRequestLocalization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(appBuilder =>

appBuilder.Run(async context =>
{
    context.Response.StatusCode = 400; // Bad Request
    context.Response.ContentType = "application/json";

    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
    var excDetails = exception switch
    {
        ValidationAppException => (Detail: exception.Message, StatusCode: StatusCodes.Status422UnprocessableEntity),
        _ => (Detail: exception?.Message, StatusCode: StatusCodes.Status500InternalServerError)
    };
    context.Response.StatusCode = excDetails.StatusCode;
    if (exception is ValidationAppException validationAppException)
    {
        await context.Response.WriteAsJsonAsync(new { validationAppException.Errors });
    }
}));
app.Run();
