using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineHotel.BLL.Interfaces;
using OnlineHotel.BLL.Repository;
using OnlineHotel.DAL.Data;
using OnlineHotel.DAL.Entity; // Ensure this is the correct namespace for ApplicationUser
using OnlineHotel.Utility;
using OnlineHotelReservation.Helpers;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
					   ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));

// Use ApplicationUser instead of IdentityUser
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

// Dependency injection for IDbInitializer
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
//builder.Services.AddScoped<IGenericRepository<Room>, GenericRepository<Room>>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));


builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
	name: "default",
	pattern: "{area=Admin}/{controller=roomtype}/{action=Index}/{id?}");

await DataSeeding(app);

app.Run();

// Data seeding
async Task DataSeeding(WebApplication app)
{
	using (var scope = app.Services.CreateScope())
	{
		var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
		await dbInitializer.InitializeAsync();
	}
}
