using System.Collections.Generic;

namespace MovieManagementSystem.Application.Common.Security;
public static class Permissions
{
    public static class System
    {
        public const string Manage = "system.manage";
        public const string Configure = "system.configure";
        public const string Backup = "system.backup";
        public const string ViewLogs = "system.logs.view";
    }

    public static class Content
    {
        public const string Create = "content.create";
        public const string Read = "content.read";
        public const string Update = "content.update";
        public const string Delete = "content.delete";

        public const string MoviesCreate = "movies.create";
        public const string MoviesRead = "movies.read";
        public const string MoviesUpdate = "movies.update";
        public const string MoviesDelete = "movies.delete";

        public const string AnimeCreate = "anime.create";
        public const string AnimeRead = "anime.read";
        public const string AnimeUpdate = "anime.update";
        public const string AnimeDelete = "anime.delete";

        public const string SeriesCreate = "series.create";
        public const string SeriesRead = "series.read";
        public const string SeriesUpdate = "series.update";
        public const string SeriesDelete = "series.delete";

        public const string EpisodesCreate = "episodes.create";
        public const string EpisodesRead = "episodes.read";
        public const string EpisodesUpdate = "episodes.update";
        public const string EpisodesDelete = "episodes.delete";

        public const string GenresCreate = "genres.create";
        public const string GenresRead = "genres.read";
        public const string GenresUpdate = "genres.update";
        public const string GenresDelete = "genres.delete";

        public const string CategoriesCreate = "categories.create";
        public const string CategoriesRead = "categories.read";
        public const string CategoriesUpdate = "categories.update";
        public const string CategoriesDelete = "categories.delete";
    }

    public static class Users
    {
        public const string Create = "users.create";
        public const string Read = "users.read";
        public const string Update = "users.update";
        public const string Delete = "users.delete";
        public const string Ban = "users.ban";
        public const string Unban = "users.unban";
        public const string ManageRoles = "users.roles.manage";
    }

    public static class Reviews
    {
        public const string Create = "reviews.create";
        public const string Read = "reviews.read";
        public const string Update = "reviews.update";
        public const string Delete = "reviews.delete";
        public const string Moderate = "reviews.moderate";
        public const string Approve = "reviews.approve";
        public const string Reject = "reviews.reject";
    }

    public static class Ratings
    {
        public const string Create = "ratings.create";
        public const string Read = "ratings.read";
        public const string Update = "ratings.update";
        public const string Delete = "ratings.delete";
    }

    public static class Comments
    {
        public const string Create = "comments.create";
        public const string Read = "comments.read";
        public const string Update = "comments.update";
        public const string Delete = "comments.delete";
        public const string Moderate = "comments.moderate";
        public const string Approve = "comments.approve";
        public const string Reject = "comments.reject";
    }

    public static class Subscriptions
    {
        public const string Manage = "subscriptions.manage";
        public const string View = "subscriptions.view";
    }

    public static class Analytics
    {
        public const string View = "analytics.view";
        public const string Export = "analytics.export";
    }

    public static class Files
    {
        public const string Upload = "files.upload";
        public const string Delete = "files.delete";
        public const string Manage = "files.manage";
    }

    public static class Watchlist
    {
        public const string Create = "watchlist.create";
        public const string Read = "watchlist.read";
        public const string Update = "watchlist.update";
        public const string Delete = "watchlist.delete";
    }

    public static class Favorites
    {
        public const string Create = "favorites.create";
        public const string Read = "favorites.read";
        public const string Update = "favorites.update";
        public const string Delete = "favorites.delete";
    }

    public static class Quality
    {
        public const string SD = "quality.sd";
        public const string HD = "quality.hd";
        public const string UHD4K = "quality.4k";
        public const string UHD8K = "quality.8k";
    }
}

public static class RoleDefinitions
{
    // Base role với permissions cơ bản nhất
    public static readonly RoleDefinition User = new RoleDefinition
    {
        Name = "User",
        Description = "Basic registered user with limited access",
        Permissions = new[]
        {
            Permissions.Content.Read,
            Permissions.Content.MoviesRead,
            Permissions.Content.AnimeRead,
            Permissions.Content.SeriesRead,
            Permissions.Content.EpisodesRead,
            Permissions.Reviews.Create,
            Permissions.Reviews.Read,
            Permissions.Comments.Create,
            Permissions.Comments.Read,
            Permissions.Ratings.Create,
            Permissions.Ratings.Read,
            Permissions.Watchlist.Read,
            Permissions.Favorites.Read,
            Permissions.Quality.SD
        }
    };

    // VIP User inherit từ User và thêm permissions
    public static readonly RoleDefinition VIPUser = new RoleDefinition
    {
        Name = "VIPUser",
        Description = "VIP user with special privileges",
        InheritFrom = User,
        AdditionalPermissions = new[]
        {
            Permissions.Reviews.Update,
            Permissions.Reviews.Delete,
            Permissions.Comments.Update
        }
    };

    // Premium User inherit từ VIP User và thêm permissions
    public static readonly RoleDefinition PremiumUser = new RoleDefinition
    {
        Name = "PremiumUser",
        Description = "Premium subscription user",
        InheritFrom = VIPUser,
        AdditionalPermissions = new[]
        {
            Permissions.Comments.Delete,
            Permissions.Ratings.Update,
            Permissions.Ratings.Delete,
            Permissions.Watchlist.Create,
            Permissions.Watchlist.Update,
            Permissions.Watchlist.Delete,
            Permissions.Favorites.Create,
            Permissions.Favorites.Update,
            Permissions.Favorites.Delete,
            Permissions.Subscriptions.View,
            Permissions.Quality.HD,
            Permissions.Quality.UHD4K,
            "ads.disable"
        }
    };

    // Content Editor inherit từ Premium User
    public static readonly RoleDefinition ContentEditor = new RoleDefinition
    {
        Name = "ContentEditor",
        Description = "Edit and update content information",
        InheritFrom = PremiumUser,
        AdditionalPermissions = new[]
        {
            Permissions.Content.Update,
            Permissions.Content.MoviesUpdate,
            Permissions.Content.AnimeUpdate,
            Permissions.Content.SeriesUpdate,
            Permissions.Content.EpisodesUpdate,
            Permissions.Content.GenresRead,
            Permissions.Content.GenresUpdate,
            Permissions.Content.CategoriesRead,
            Permissions.Content.CategoriesUpdate,
            Permissions.Files.Upload
        }
    };

    // Content Moderator inherit từ Content Editor
    public static readonly RoleDefinition ContentModerator = new RoleDefinition
    {
        Name = "ContentModerator",
        Description = "Moderate content and reviews",
        InheritFrom = ContentEditor,
        AdditionalPermissions = new[]
        {
            Permissions.Reviews.Moderate,
            Permissions.Reviews.Approve,
            Permissions.Reviews.Reject,
            Permissions.Comments.Moderate,
            Permissions.Comments.Approve,
            Permissions.Comments.Reject
        }
    };

    // Community Manager inherit từ Content Moderator
    public static readonly RoleDefinition CommunityManager = new RoleDefinition
    {
        Name = "CommunityManager",
        Description = "Manage community features and interactions",
        InheritFrom = ContentModerator,
        AdditionalPermissions = new[]
        {
            Permissions.Users.Read,
            Permissions.Users.Update,
            Permissions.Users.Ban,
            Permissions.Users.Unban
        }
    };

    // Content Manager inherit từ Content Editor
    public static readonly RoleDefinition ContentManager = new RoleDefinition
    {
        Name = "ContentManager",
        Description = "Manage movies, anime, and content",
        InheritFrom = ContentEditor,
        AdditionalPermissions = new[]
        {
            Permissions.Content.Create,
            Permissions.Content.Delete,
            Permissions.Content.MoviesCreate,
            Permissions.Content.MoviesDelete,
            Permissions.Content.AnimeCreate,
            Permissions.Content.AnimeDelete,
            Permissions.Content.SeriesCreate,
            Permissions.Content.SeriesDelete,
            Permissions.Content.EpisodesCreate,
            Permissions.Content.EpisodesDelete,
            Permissions.Content.GenresCreate,
            Permissions.Content.GenresDelete,
            Permissions.Content.CategoriesCreate,
            Permissions.Content.CategoriesDelete,
            Permissions.Files.Delete,
            Permissions.Files.Manage
        }
    };

    // User Manager inherit từ Premium User
    public static readonly RoleDefinition UserManager = new RoleDefinition
    {
        Name = "UserManager",
        Description = "Manage user accounts and permissions",
        InheritFrom = PremiumUser,
        AdditionalPermissions = new[]
        {
            Permissions.Users.Create,
            Permissions.Users.Read,
            Permissions.Users.Update,
            Permissions.Users.Delete,
            Permissions.Users.Ban,
            Permissions.Users.Unban,
            Permissions.Users.ManageRoles,
            Permissions.Analytics.View
        }
    };

    // Admin inherit từ multiple roles (Content Manager + Community Manager + User Manager)
    public static readonly RoleDefinition Admin = new RoleDefinition
    {
        Name = "Admin",
        Description = "Site Administrator",
        InheritFrom = ContentManager,
        AdditionalInheritFrom = new[] { CommunityManager, UserManager },
        AdditionalPermissions = new[]
        {
            Permissions.Analytics.View
        }
    };

    // Super Admin inherit từ Admin và có tất cả permissions
    public static readonly RoleDefinition SuperAdmin = new RoleDefinition
    {
        Name = "SuperAdmin",
        Description = "System Administrator with full access",
        InheritFrom = Admin,
        AdditionalPermissions = new[]
        {
            Permissions.System.Manage,
            Permissions.System.Configure,
            Permissions.System.Backup,
            Permissions.System.ViewLogs,
            Permissions.Analytics.Export,
            Permissions.Quality.UHD8K
        }
    };

    public static readonly List<RoleDefinition> AllRoles = new List<RoleDefinition>
    {
        User,
        VIPUser,
        PremiumUser,
        ContentEditor,
        ContentModerator,
        ContentManager,
        CommunityManager,
        UserManager,
        Admin,
        SuperAdmin
    };
}

// Cập nhật RoleDefinition class để support inheritance
public class RoleDefinition
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] Permissions { get; set; } = Array.Empty<string>();
    public RoleDefinition InheritFrom { get; set; } = null!;
    public RoleDefinition[] AdditionalInheritFrom { get; set; } = Array.Empty<RoleDefinition>();
    public string[] AdditionalPermissions { get; set; } = Array.Empty<string>();

    // Lazy loading computed permissions
    private string[]? _computedPermissions;
    public string[] ComputedPermissions
    {
        get
        {
            if (_computedPermissions == null)
            {
                _computedPermissions = ComputeAllPermissions();
            }
            return _computedPermissions;
        }
    }

    private string[] ComputeAllPermissions()
    {
        var allPermissions = new HashSet<string>();

        // Thêm permissions trực tiếp
        foreach (var permission in Permissions)
        {
            allPermissions.Add(permission);
        }

        // Thêm permissions từ role kế thừa chính
        if (InheritFrom != null)
        {
            foreach (var permission in InheritFrom.ComputedPermissions)
            {
                allPermissions.Add(permission);
            }
        }

        // Thêm permissions từ các role kế thừa bổ sung
        foreach (var inheritedRole in AdditionalInheritFrom)
        {
            foreach (var permission in inheritedRole.ComputedPermissions)
            {
                allPermissions.Add(permission);
            }
        }

        // Thêm permissions bổ sung
        foreach (var permission in AdditionalPermissions)
        {
            allPermissions.Add(permission);
        }

        return allPermissions.ToArray();
    }

    // Method để check permission
    public bool HasPermission(string permission)
    {
        return ComputedPermissions.Contains(permission);
    }

    // Method để reset computed permissions (nếu cần update)
    public void ResetComputedPermissions()
    {
        _computedPermissions = null;
    }
}
