using MovieManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieManagementSystem.Application.Common.Security;

namespace MovieManagementSystem.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static void AddAsyncSeeding(this DbContextOptionsBuilder builder, IServiceProvider serviceProvider)
    {
        builder.UseAsyncSeeding(async (context, _, ct) =>
        {
            var initialiser = serviceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

            await initialiser.SeedAsync();
        });
    }

    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Seed Roles first
        await SeedRolesAsync(_roleManager);

        // Seed Users with roles
        await SeedUsersAsync(_userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        var roles = RoleDefinitions.AllRoles;

        foreach (var role in roles)
        {
            var existingRole = await roleManager.FindByNameAsync(role.Name);
            if (existingRole == null)
            {
                var newRole = new IdentityRole(role.Name);
                await roleManager.CreateAsync(newRole);

                // Add claims/permissions to roles
                await AddRoleClaimsAsync(roleManager, role);
            }
        }
    }

    private static async Task AddRoleClaimsAsync(RoleManager<IdentityRole> roleManager, RoleDefinition roleDefinition)
    {
        var role = await roleManager.FindByNameAsync(roleDefinition.Name);
        if (role == null) return;

        // Define permissions for each role
        var permissions = roleDefinition.Permissions;

        foreach (var permission in permissions)
        {
            var existingClaim = await roleManager.GetClaimsAsync(role);
            if (!existingClaim.Any(c => c.Type == "permission" && c.Value == permission))
            {
                await roleManager.AddClaimAsync(role, new System.Security.Claims.Claim("permission", permission));
            }
        }
    }

    private static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
    {
        // Seed Super Admin
        var superAdmin = new ApplicationUser
        {
            UserName = "superadmin@movieanime.com",
            Email = "superadmin@movieanime.com",
            EmailConfirmed = true,
            FullName = "Super Admin",
        };

        if (await userManager.FindByEmailAsync(superAdmin.Email) == null)
        {
            await userManager.CreateAsync(superAdmin, "SuperAdmin123!");
            await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
        }

        // Seed Admin
        var admin = new ApplicationUser
        {
            UserName = "admin@movieanime.com",
            Email = "admin@movieanime.com",
            EmailConfirmed = true,
            FullName = "Admin User",
        };

        if (await userManager.FindByEmailAsync(admin.Email) == null)
        {
            await userManager.CreateAsync(admin, "Admin123!");
            await userManager.AddToRoleAsync(admin, "Admin");
        }

        // Seed Content Manager
        var contentManager = new ApplicationUser
        {
            UserName = "content@movieanime.com",
            Email = "content@movieanime.com",
            EmailConfirmed = true,
            FullName = "Content Manager",
        };

        if (await userManager.FindByEmailAsync(contentManager.Email) == null)
        {
            await userManager.CreateAsync(contentManager, "Content123!");
            await userManager.AddToRoleAsync(contentManager, "ContentManager");
        }

        // Seed Demo Premium User
        var premiumUser = new ApplicationUser
        {
            UserName = "premium@movieanime.com",
            Email = "premium@movieanime.com",
            EmailConfirmed = true,
            FullName = "Premium User",
        };

        if (await userManager.FindByEmailAsync(premiumUser.Email) == null)
        {
            await userManager.CreateAsync(premiumUser, "Premium123!");
            await userManager.AddToRoleAsync(premiumUser, "PremiumUser");
        }

        // Seed Demo Regular User
        var regularUser = new ApplicationUser
        {
            UserName = "user@movieanime.com",
            Email = "user@movieanime.com",
            EmailConfirmed = true,
            FullName = "Regular User",
        };

        if (await userManager.FindByEmailAsync(regularUser.Email) == null)
        {
            await userManager.CreateAsync(regularUser, "User123!");
            await userManager.AddToRoleAsync(regularUser, "User");
        }
    }
}
