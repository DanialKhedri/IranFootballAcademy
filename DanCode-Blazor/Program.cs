#region usings

using Blazored.LocalStorage;
using DanCode_Blazor;
using DanCode_Blazor.Components;
using DanCode_Blazor.Providers;
using DanCode_Blazor.Services.ArticleService;
using DanCode_Blazor.Services.Authentication;
using DanCode_Blazor.Services.Base;
using DanCode_Blazor.Services.Base.interfaces;
using DanCode_Blazor.Services.CourseService;
using DanCode_Blazor.Services.DrillService;
using DanCode_Blazor.Services.OrderService;
using DanCode_Blazor.Services.PaymentService;
using DanCode_Blazor.Services.ProductService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.IdentityModel.Tokens;
using Services.Base.interfaces;
using Services.UserService;
using System.Text;

#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddServerSideBlazor().AddCircuitOptions(o =>
{
    //only add details when debugging
    o.DetailedErrors = true;
});


string baseAddress = builder.Configuration.GetValue<string>("Url:BaseUrl");

builder.Services.AddHttpClient<IClient, Client>(cli => cli.BaseAddress = new Uri(baseAddress));

builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri(baseAddress)
});


builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDrillService, DrillService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IArticleService, ArticlesService>();


builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetRequiredService<ApiAuthenticationStateProvider>());

builder.Services.AddAuthenticationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazorBootstrap();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
