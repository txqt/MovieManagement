using MovieManagementSystem.Application.Common.Security;

namespace MovieManagementSystem.Web.Endpoints;

public class TestEndpoints : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup("/test")
            .RequireAuthorization()
            .MapGet(GetPublic)
            .MapGet(GetSecure, "secure")
            .MapGet(GetWithPolicy, "policy");
    }

    public static IResult GetPublic()
    {
        return Results.Ok("✅ Public access");
    }

    public static IResult GetSecure(HttpContext context)
    {
        return Results.Ok($"🔐 Authenticated: {context.User.Identity?.Name}");
    }

    public static IResult GetWithPolicy(HttpContext context)
    {
        return Results.Ok($"🛡️ Access granted via policy: {context.User.Identity?.Name}");
    }
}
