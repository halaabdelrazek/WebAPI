using BusinessLayer.OrderBL;
using BusinessLayer.ProductBL;
using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.DataBaseModels;
using DataAccessLayer.Repositories.Order_Repository;
using DataAccessLayer.Repositories.Product_Repository;
using DataAccessLayer.Repositories.ProductOrder_Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<MyContext, MyContext>();
builder.Services.AddScoped<IProduct_Repository, Product_Repository>();
builder.Services.AddScoped<IOrder_Repository, Order_Repository>();
builder.Services.AddScoped<IProductOrder_Repository, ProductOrder_Repository>();
builder.Services.AddScoped<IOrderBL, OrderBL>();
builder.Services.AddScoped<IProductBL, ProductBL>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Context

var connectionString = builder.Configuration.GetConnectionString("DBConnectionString");
builder.Services.AddDbContext<MyContext>(option =>
option.UseLazyLoadingProxies()
      .UseSqlServer(connectionString));


#endregion


#region ASP Identity
builder.Services.AddIdentity<User,IdentityRole>(options =>
{
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

    options.User.RequireUniqueEmail = true;


    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
})
    .AddEntityFrameworkStores<MyContext>();
#endregion

#region Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Default";
    options.DefaultChallengeScheme = "Default";
})
    .AddJwtBearer("Default", options =>
    {
        var secretKey = builder.Configuration.GetValue<string>("SecretKey");
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKey);
        var key = new SymmetricSecurityKey(secretKeyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = key,
            ValidateIssuer = true,
            ValidIssuer = "AuthServer1",
            ValidateAudience = true,
            ValidAudience = "Service1"
        };
    });
#endregion



#region Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy
        .RequireClaim(ClaimTypes.Role, "Admin"));

    options.AddPolicy("Customer", policy => policy
        .RequireClaim(ClaimTypes.Role, "Customer"));

});

#endregion


#region RegisteringAutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
