using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using API.Filters;
using Application;
using Infrastructure;
using Microsoft.Extensions.FileProviders;


var builder = WebApplication.CreateBuilder(args);

// Modules
builder.Services
    .AddInfrastructure()
    .AddApplication();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAtribute>());

// Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "HandsOn API",
        Version = "v1",
        Description = "API from HandsOn Project",
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme. Put **_ONLY_** your JWT token on textbox below.",
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
                Scheme = "Bearer",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });

    options.CustomSchemaIds(type => type.Name);

    var xmlFile = "API.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.MapOpenApi();
    
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "HandsOn API v1");
        options.RoutePrefix = string.Empty;
        options.DocumentTitle = "HandsOn API Documentation";
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
        options.DisplayRequestDuration();
        options.EnableFilter();
        options.EnableDeepLinking();
        options.ShowExtensions();
        options.EnableValidator();
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())!.FullName, "Infrastructure", "Comprovantes")
    ),
    RequestPath = "/files"
});

app.MapControllers();

app.Run();