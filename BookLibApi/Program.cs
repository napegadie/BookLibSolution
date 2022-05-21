using BookLibApi.DataStore;
using BookLibApi.Repository;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("https://localhost:7283", "https://calm-water-04859b403.azurestaticapps.net");
        });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IGenreRepo, GenreRepo>();
builder.Services.AddTransient<IPublisherRepo, PublisherRepo>();
builder.Services.AddTransient<IAuthorRepo, AuthorRepo>();
builder.Services.AddTransient<IBookRepo, BookRepo>();
builder.Services.AddTransient<IBookAuthorRepo, BookAuthorRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //app.UseSwaggerUI(swaggerUIOptions =>
    //{
    //    swaggerUIOptions.DocumentTitle = "ASP.NET React Tutorial";
    //    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API serving a very simple Post model.");
    //    swaggerUIOptions.RoutePrefix = string.Empty;
    //});
}

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
