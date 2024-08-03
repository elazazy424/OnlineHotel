using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineHotel.DAL.Data;
using OnlineHotel.DAL.Entity;
using OnlineHotel.Utility;
using System.Threading.Tasks;

public class DbInitializer : IDbInitializer
{
	private readonly ApplicationDbContext _context;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly UserManager<ApplicationUser> _userManager;

	public DbInitializer(
		ApplicationDbContext context,
		RoleManager<IdentityRole> roleManager,
		UserManager<ApplicationUser> userManager)
	{
		_context = context;
		_roleManager = roleManager;
		_userManager = userManager;
	}

	public async Task InitializeAsync()
	{
		try
		{
			if ((await _context.Database.GetPendingMigrationsAsync()).Any())
			{
				await _context.Database.MigrateAsync();
			}
		}
		catch (Exception ex)
		{
			throw;
		}

		if (!await _roleManager.RoleExistsAsync(WebSiteRoles.HotelAdmin))
		{
			await _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.HotelAdmin));
			await _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.HotelCustomer));

			var adminUser = new ApplicationUser
			{
				UserName = "admin@gmail.com",
				Email = "admin@gmail.com",
				Name = "Admin"
			};

			await _userManager.CreateAsync(adminUser, "Admin@123");
			await _userManager.AddToRoleAsync(adminUser, WebSiteRoles.HotelAdmin);
		}
	}
}
