using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("CompaniesClient", config =>
{
    config.BaseAddress = new Uri("https://localhost:5001/api/");
    config.Timeout = new TimeSpan(0, 0, 30);
    config.DefaultRequestHeaders.Clear();
})
    .ConfigureHttpClient(c =>
    {
        c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
        c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
    });


builder.Services.AddHttpClient("BookLibApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("BookLibApiUrl").Value);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

});

//builder.Services.AddHttpClient("authorizedClient", client =>
//{
//    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//}).AddHttpMessageHandler<AuthorizedHandler>();


//builder.Services.AddHttpClient<IDataClient, DataClient>(client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration.GetSection("DataClientSectionName").Value);
//});

//builder.Services.AddHttpClient<StreamingClient>(client =>
//{
//    client.BaseAddress = new Uri(builder.Configuration.GetSection("StreamingClientSectionName").Value);
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
