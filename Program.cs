using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Context;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Password_Crypth_Implementations;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt => opt.LoginPath = "/Auth/Login");

builder.Services.
              AddAuthorization(opt =>
              {
                  opt.AddPolicy(Policies.LoggedIn, cfg => cfg.RequireAuthenticatedUser());
                  opt.AddPolicy(Policies.IsAdmin, cfg => cfg.RequireRole("Admin"));
                  opt.AddPolicy(Policies.IsUser, cfg => cfg.RequireRole("User"));
              });


var conn = builder.Configuration.GetConnectionString("SqlServer")!;
builder.Services
    .AddDbContext<DataContext>(opt => opt.UseSqlServer(conn))
    ;

builder.Services
    .AddScoped<IProductService, ProductService>()
    .AddScoped<IIngredientsService, IngredientService>()
    .AddScoped<IRoleService, RoleService>()
    .AddScoped<IAuthService, AuthService>()
    .AddScoped<IPasswordEncoder, PasswordEncoders>()
    .AddScoped<IOrderService, OrderService>()
    ;


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
