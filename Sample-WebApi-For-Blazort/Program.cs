#region Usings
using Application.Services.Implement.Course;
using Application.Services.Implement.Drilll;
using Application.Services.Implement.Product;
using Application.Services.Implement.User;
using Application.Services.Implement;
using Application.Services.Interface.Course;
using Application.Services.Interface.Drill;
using Application.Services.Interface.Product;
using Application.Services.Interface.User;
using Application.Services.Interface;
using Application.Utilities.AutoMapper;
using Domain.IRepository;
using Domain.IRepository.Course;
using Domain.IRepository.Drill;
using Domain.IRepository.Product;
using Domain.IRepository.User;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Course;
using Infrastructure.Repository.Drill;
using Infrastructure.Repository.Product;
using Infrastructure.Repository.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using Application.Services.Interfaces;
using Application.Services.implements;
using Domain.IRepository.Payment;
using Infrastructure.Repository.Payment;
using Application.Services.Interface.Payment;
using Application.Services.Implement.Payment;
using Application.Services.Interface.Artic;
using Domain.IRepository.Article;
using Infrastructure.Repository.Article;
using Application.Services.Implement.Artic;
#endregion

#region Services

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//Services

//User
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();


//Order
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

//Drill
builder.Services.AddScoped<IDrillRepository, DrillRepository>();
builder.Services.AddScoped<IDrillService, DrillService>();

//Course
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

//Payment
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

//Article
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleService, ArticleService>();


//Serilog
builder.Host.UseSerilog((ctx, lc) =>
{
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration);

});


//Cors
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", b => b.AllowAnyMethod().
                                        AllowAnyHeader().
                                        AllowAnyOrigin());

});

//AutoMapper
builder.Services.AddAutoMapper(typeof(MapperConfig));


//Add dbContext
builder.Services.AddDbContext<DataContext>(option =>
{

    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));

}
);

//JWT
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,

        ValidIssuer = builder.Configuration["JWTSettings:Issuer"],
        ValidAudience = builder.Configuration["JWTSettings:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWTSettings:Key"])),

    };

});








#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
