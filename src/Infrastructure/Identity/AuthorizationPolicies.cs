using Microsoft.AspNetCore.Authorization;

namespace MovieManagementSystem.Infrastructure.Identity;

public static class AuthorizationPolicies
{
    public static void ConfigurePolicies(AuthorizationOptions options)
    {
        // Content Management Policies
        options.AddPolicy("CanManageContent", policy =>
            policy.RequireClaim("permission", "content.create", "content.update", "content.delete"));

        options.AddPolicy("CanViewContent", policy =>
            policy.RequireClaim("permission", "content.read"));

        options.AddPolicy("CanCreateContent", policy =>
            policy.RequireClaim("permission", "content.create"));

        options.AddPolicy("CanUpdateContent", policy =>
            policy.RequireClaim("permission", "content.update"));

        options.AddPolicy("CanDeleteContent", policy =>
            policy.RequireClaim("permission", "content.delete"));

        // Movie Management Policies
        options.AddPolicy("CanManageMovies", policy =>
            policy.RequireClaim("permission", "movies.create", "movies.update", "movies.delete"));

        options.AddPolicy("CanViewMovies", policy =>
            policy.RequireClaim("permission", "movies.read"));

        // Anime Management Policies
        options.AddPolicy("CanManageAnime", policy =>
            policy.RequireClaim("permission", "anime.create", "anime.update", "anime.delete"));

        options.AddPolicy("CanViewAnime", policy =>
            policy.RequireClaim("permission", "anime.read"));

        // Series Management Policies
        options.AddPolicy("CanManageSeries", policy =>
            policy.RequireClaim("permission", "series.create", "series.update", "series.delete"));

        options.AddPolicy("CanViewSeries", policy =>
            policy.RequireClaim("permission", "series.read"));

        // Episode Management Policies
        options.AddPolicy("CanManageEpisodes", policy =>
            policy.RequireClaim("permission", "episodes.create", "episodes.update", "episodes.delete"));

        options.AddPolicy("CanViewEpisodes", policy =>
            policy.RequireClaim("permission", "episodes.read"));

        // User Management Policies
        options.AddPolicy("CanManageUsers", policy =>
            policy.RequireClaim("permission", "users.create", "users.update", "users.delete"));

        options.AddPolicy("CanViewUsers", policy =>
            policy.RequireClaim("permission", "users.read"));

        options.AddPolicy("CanBanUsers", policy =>
            policy.RequireClaim("permission", "users.ban", "users.unban"));

        // Review Management Policies
        options.AddPolicy("CanModerateReviews", policy =>
            policy.RequireClaim("permission", "reviews.moderate", "reviews.approve", "reviews.reject"));

        options.AddPolicy("CanManageReviews", policy =>
            policy.RequireClaim("permission", "reviews.create", "reviews.update", "reviews.delete"));

        options.AddPolicy("CanViewReviews", policy =>
            policy.RequireClaim("permission", "reviews.read"));

        // Comment Management Policies
        options.AddPolicy("CanModerateComments", policy =>
            policy.RequireClaim("permission", "comments.moderate", "comments.approve", "comments.reject"));

        options.AddPolicy("CanManageComments", policy =>
            policy.RequireClaim("permission", "comments.create", "comments.update", "comments.delete"));

        // Premium Content Policies
        options.AddPolicy("CanAccessPremiumContent", policy =>
            policy.RequireClaim("permission", "content.premium.access"));

        options.AddPolicy("CanAccessVIPContent", policy =>
            policy.RequireClaim("permission", "content.vip.access"));

        options.AddPolicy("CanAccessEarlyContent", policy =>
            policy.RequireClaim("permission", "content.early.access"));

        // Quality Policies
        options.AddPolicy("CanAccessHDQuality", policy =>
            policy.RequireClaim("permission", "quality.hd", "quality.4k", "quality.8k"));

        options.AddPolicy("CanAccess4KQuality", policy =>
            policy.RequireClaim("permission", "quality.4k", "quality.8k"));

        options.AddPolicy("CanAccess8KQuality", policy =>
            policy.RequireClaim("permission", "quality.8k"));

        // Download Policies
        options.AddPolicy("CanDownloadContent", policy =>
            policy.RequireClaim("permission", "downloads.enable"));

        // File Management Policies
        options.AddPolicy("CanManageFiles", policy =>
            policy.RequireClaim("permission", "files.upload", "files.delete", "files.manage"));

        options.AddPolicy("CanUploadFiles", policy =>
            policy.RequireClaim("permission", "files.upload"));

        // Analytics Policies
        options.AddPolicy("CanViewAnalytics", policy =>
            policy.RequireClaim("permission", "analytics.view"));

        options.AddPolicy("CanExportAnalytics", policy =>
            policy.RequireClaim("permission", "analytics.export"));

        // System Policies
        options.AddPolicy("CanManageSystem", policy =>
            policy.RequireClaim("permission", "system.manage", "system.configure"));

        options.AddPolicy("CanViewSystemLogs", policy =>
            policy.RequireClaim("permission", "system.logs.view"));

        // Subscription Policies
        options.AddPolicy("CanManageSubscriptions", policy =>
            policy.RequireClaim("permission", "subscriptions.manage"));

        options.AddPolicy("CanViewSubscriptions", policy =>
            policy.RequireClaim("permission", "subscriptions.view"));

        // Role-based Policies
        options.AddPolicy("RequireAdminRole", policy =>
            policy.RequireRole("Admin", "SuperAdmin"));

        options.AddPolicy("RequireContentManagerRole", policy =>
            policy.RequireRole("ContentManager", "Admin", "SuperAdmin"));

        options.AddPolicy("RequireModeratorRole", policy =>
            policy.RequireRole("ContentModerator", "CommunityManager", "Admin", "SuperAdmin"));

        options.AddPolicy("RequirePremiumRole", policy =>
            policy.RequireRole("PremiumUser", "VIPUser", "Admin", "SuperAdmin"));

        options.AddPolicy("RequireVIPRole", policy =>
            policy.RequireRole("VIPUser", "Admin", "SuperAdmin"));
    }
}
