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

// Định nghĩa role cùng danh sách permission
public class RoleDefinition
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IEnumerable<string> Permissions { get; set; } = new List<string>();
}

public static class RoleDefinitions
{
    public static readonly RoleDefinition SuperAdmin = new RoleDefinition
    {
        Name = "SuperAdmin",
        Description = "System Administrator with full access",
        Permissions = new[]
        {
                Permissions.System.Manage,
                Permissions.System.Configure,
                Permissions.System.Backup,
                Permissions.System.ViewLogs,
                Permissions.Content.Create,
                Permissions.Content.Read,
                Permissions.Content.Update,
                Permissions.Content.Delete,
                Permissions.Content.MoviesCreate,
                Permissions.Content.MoviesRead,
                Permissions.Content.MoviesUpdate,
                Permissions.Content.MoviesDelete,
                Permissions.Content.AnimeCreate,
                Permissions.Content.AnimeRead,
                Permissions.Content.AnimeUpdate,
                Permissions.Content.AnimeDelete,
                Permissions.Content.SeriesCreate,
                Permissions.Content.SeriesRead,
                Permissions.Content.SeriesUpdate,
                Permissions.Content.SeriesDelete,
                Permissions.Content.EpisodesCreate,
                Permissions.Content.EpisodesRead,
                Permissions.Content.EpisodesUpdate,
                Permissions.Content.EpisodesDelete,
                Permissions.Content.GenresCreate,
                Permissions.Content.GenresRead,
                Permissions.Content.GenresUpdate,
                Permissions.Content.GenresDelete,
                Permissions.Content.CategoriesCreate,
                Permissions.Content.CategoriesRead,
                Permissions.Content.CategoriesUpdate,
                Permissions.Content.CategoriesDelete,
                Permissions.Users.Create,
                Permissions.Users.Read,
                Permissions.Users.Update,
                Permissions.Users.Delete,
                Permissions.Users.Ban,
                Permissions.Users.Unban,
                Permissions.Users.ManageRoles,
                Permissions.Reviews.Create,
                Permissions.Reviews.Read,
                Permissions.Reviews.Update,
                Permissions.Reviews.Delete,
                Permissions.Reviews.Moderate,
                Permissions.Reviews.Approve,
                Permissions.Reviews.Reject,
                Permissions.Ratings.Create,
                Permissions.Ratings.Read,
                Permissions.Ratings.Update,
                Permissions.Ratings.Delete,
                Permissions.Comments.Create,
                Permissions.Comments.Read,
                Permissions.Comments.Update,
                Permissions.Comments.Delete,
                Permissions.Comments.Moderate,
                Permissions.Comments.Approve,
                Permissions.Comments.Reject,
                Permissions.Subscriptions.Manage,
                Permissions.Subscriptions.View,
                Permissions.Analytics.View,
                Permissions.Analytics.Export,
                Permissions.Files.Upload,
                Permissions.Files.Delete,
                Permissions.Files.Manage,
                Permissions.Watchlist.Create,
                Permissions.Watchlist.Read,
                Permissions.Watchlist.Update,
                Permissions.Watchlist.Delete,
                Permissions.Favorites.Create,
                Permissions.Favorites.Read,
                Permissions.Favorites.Update,
                Permissions.Favorites.Delete,
                Permissions.Quality.SD,
                Permissions.Quality.HD,
                Permissions.Quality.UHD4K,
                Permissions.Quality.UHD8K
            }
    };

    public static readonly RoleDefinition Admin = new RoleDefinition
    {
        Name = "Admin",
        Description = "Site Administrator",
        Permissions = new[]
        {
                Permissions.Content.Create,
                Permissions.Content.Read,
                Permissions.Content.Update,
                Permissions.Content.Delete,
                Permissions.Content.MoviesRead,
                Permissions.Content.MoviesUpdate,
                Permissions.Content.AnimeRead,
                Permissions.Content.AnimeUpdate,
                Permissions.Content.SeriesRead,
                Permissions.Content.SeriesUpdate,
                Permissions.Content.EpisodesRead,
                Permissions.Content.EpisodesUpdate,
                Permissions.Content.GenresRead,
                Permissions.Content.GenresUpdate,
                Permissions.Content.CategoriesRead,
                Permissions.Content.CategoriesUpdate,
                Permissions.Users.Read,
                Permissions.Users.Update,
                Permissions.Users.Ban,
                Permissions.Users.Unban,
                Permissions.Reviews.Read,
                Permissions.Reviews.Update,
                Permissions.Reviews.Delete,
                Permissions.Reviews.Moderate,
                Permissions.Reviews.Approve,
                Permissions.Reviews.Reject,
                Permissions.Ratings.Read,
                Permissions.Ratings.Update,
                Permissions.Ratings.Delete,
                Permissions.Comments.Read,
                Permissions.Comments.Update,
                Permissions.Comments.Delete,
                Permissions.Comments.Moderate,
                Permissions.Comments.Approve,
                Permissions.Comments.Reject,
                Permissions.Analytics.View,
                Permissions.Files.Upload,
                Permissions.Files.Delete,
                Permissions.Files.Manage
            }
    };

    public static readonly RoleDefinition ContentManager = new RoleDefinition
    {
        Name = "ContentManager",
        Description = "Manage movies, anime, and content",
        Permissions = new[]
        {
                Permissions.Content.Create,
                Permissions.Content.Read,
                Permissions.Content.Update,
                Permissions.Content.Delete,
                Permissions.Content.MoviesCreate,
                Permissions.Content.MoviesRead,
                Permissions.Content.MoviesUpdate,
                Permissions.Content.MoviesDelete,
                Permissions.Content.AnimeCreate,
                Permissions.Content.AnimeRead,
                Permissions.Content.AnimeUpdate,
                Permissions.Content.AnimeDelete,
                Permissions.Content.SeriesCreate,
                Permissions.Content.SeriesRead,
                Permissions.Content.SeriesUpdate,
                Permissions.Content.SeriesDelete,
                Permissions.Content.EpisodesCreate,
                Permissions.Content.EpisodesRead,
                Permissions.Content.EpisodesUpdate,
                Permissions.Content.EpisodesDelete,
                Permissions.Content.GenresCreate,
                Permissions.Content.GenresRead,
                Permissions.Content.GenresUpdate,
                Permissions.Content.GenresDelete,
                Permissions.Content.CategoriesCreate,
                Permissions.Content.CategoriesRead,
                Permissions.Content.CategoriesUpdate,
                Permissions.Content.CategoriesDelete,
                Permissions.Files.Upload,
                Permissions.Files.Delete,
                Permissions.Files.Manage
            }
    };

    public static readonly RoleDefinition ContentModerator = new RoleDefinition
    {
        Name = "ContentModerator",
        Description = "Moderate content and reviews",
        Permissions = new[]
        {
                Permissions.Content.Read,
                Permissions.Content.Update,
                Permissions.Content.MoviesRead,
                Permissions.Content.MoviesUpdate,
                Permissions.Content.AnimeRead,
                Permissions.Content.AnimeUpdate,
                Permissions.Content.SeriesRead,
                Permissions.Content.SeriesUpdate,
                Permissions.Content.EpisodesRead,
                Permissions.Content.EpisodesUpdate,
                Permissions.Reviews.Read,
                Permissions.Reviews.Update,
                Permissions.Reviews.Delete,
                Permissions.Reviews.Moderate,
                Permissions.Reviews.Approve,
                Permissions.Reviews.Reject,
                Permissions.Ratings.Read,
                Permissions.Ratings.Update,
                Permissions.Ratings.Delete,
                Permissions.Comments.Read,
                Permissions.Comments.Update,
                Permissions.Comments.Delete,
                Permissions.Comments.Moderate,
                Permissions.Comments.Approve,
                Permissions.Comments.Reject
            }
    };

    public static readonly RoleDefinition ContentEditor = new RoleDefinition
    {
        Name = "ContentEditor",
        Description = "Edit and update content information",
        Permissions = new[]
        {
                Permissions.Content.Read,
                Permissions.Content.Update,
                Permissions.Content.MoviesRead,
                Permissions.Content.MoviesUpdate,
                Permissions.Content.AnimeRead,
                Permissions.Content.AnimeUpdate,
                Permissions.Content.SeriesRead,
                Permissions.Content.SeriesUpdate,
                Permissions.Content.EpisodesRead,
                Permissions.Content.EpisodesUpdate,
                Permissions.Content.GenresRead,
                Permissions.Content.GenresUpdate,
                Permissions.Content.CategoriesRead,
                Permissions.Content.CategoriesUpdate,
                Permissions.Files.Upload
            }
    };

    public static readonly RoleDefinition UserManager = new RoleDefinition
    {
        Name = "UserManager",
        Description = "Manage user accounts and permissions",
        Permissions = new[]
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

    public static readonly RoleDefinition CommunityManager = new RoleDefinition
    {
        Name = "CommunityManager",
        Description = "Manage community features and interactions",
        Permissions = new[]
        {
                Permissions.Reviews.Read,
                Permissions.Reviews.Update,
                Permissions.Reviews.Delete,
                Permissions.Reviews.Moderate,
                Permissions.Reviews.Approve,
                Permissions.Reviews.Reject,
                Permissions.Comments.Read,
                Permissions.Comments.Update,
                Permissions.Comments.Delete,
                Permissions.Comments.Moderate,
                Permissions.Comments.Approve,
                Permissions.Comments.Reject,
                Permissions.Users.Read,
                Permissions.Users.Update,
                Permissions.Users.Ban,
                Permissions.Users.Unban
            }
    };

    public static readonly RoleDefinition PremiumUser = new RoleDefinition
    {
        Name = "PremiumUser",
        Description = "Premium subscription user",
        Permissions = new[]
        {
                Permissions.Content.Read,
                Permissions.Content.MoviesRead,
                Permissions.Content.AnimeRead,
                Permissions.Content.SeriesRead,
                Permissions.Content.EpisodesRead,
                Permissions.Reviews.Create,
                Permissions.Reviews.Read,
                Permissions.Reviews.Update,
                Permissions.Reviews.Delete,
                Permissions.Comments.Create,
                Permissions.Comments.Read,
                Permissions.Comments.Update,
                Permissions.Comments.Delete,
                Permissions.Ratings.Create,
                Permissions.Ratings.Read,
                Permissions.Ratings.Update,
                Permissions.Ratings.Delete,
                Permissions.Watchlist.Create,
                Permissions.Watchlist.Read,
                Permissions.Watchlist.Update,
                Permissions.Watchlist.Delete,
                Permissions.Favorites.Create,
                Permissions.Favorites.Read,
                Permissions.Favorites.Update,
                Permissions.Favorites.Delete,
                Permissions.Subscriptions.View,
                Permissions.Quality.HD,
                Permissions.Quality.UHD4K,
                "ads.disable"
            }
    };

    public static readonly RoleDefinition VIPUser = new RoleDefinition
    {
        Name = "VIPUser",
        Description = "VIP user with special privileges",
        Permissions = new[]
        {
                Permissions.Content.Read,
                Permissions.Content.MoviesRead,
                Permissions.Content.AnimeRead,
                Permissions.Content.SeriesRead,
                Permissions.Content.EpisodesRead,
                Permissions.Reviews.Create,
                Permissions.Reviews.Read,
                Permissions.Reviews.Update,
                Permissions.Reviews.Delete,
                Permissions.Comments.Create,
                Permissions.Comments.Read,
            }
    };
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


    public static readonly List<RoleDefinition> AllRoles = new List<RoleDefinition>
    {
        SuperAdmin,
        Admin,
        ContentManager,
        ContentModerator,
        ContentEditor,
        UserManager,
        CommunityManager,
        PremiumUser,
        VIPUser,
        User
    };
}
